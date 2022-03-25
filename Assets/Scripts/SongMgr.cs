//
// Play music and keep track of where the beat is (via midi)
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;

public class SongMgr : MonoBehaviour
{
   [Header("Config")]
   public bool PlayAtStart = true;
   public AudioSource AudioSourceToPlay;
   public string MidiFilePath = "";

   [Header("Outputs")]
   public float CurSecs = 0.0f;
   public float CurBeat = 0.0f;

   [Header("Debug")]
   [InspectorButton("_OnDebugPlay")]
   public bool PlaySong;
   [InspectorButton("_OnDebugPause")]
   public bool PauseSong;
   [InspectorButton("_OnDebugResume")]
   public bool ResumeSong;
   [InspectorButton("_OnDebugStop")]
   public bool StopSong;

   private MidiFile _midiFile;
   private TempoMap _tempoMap = null;
   private string _loadedMidiPath = "";

   public static SongMgr I { get; private set; }

   void Awake()
   {
      I = this;
   }

   void Start()
   {
      if (PlayAtStart)
         Play();
   }

   public void Play()
   {
      if (!AudioSourceToPlay)
         return;

      //load midi file
      if (!_HasMidiFile())
         _LoadMidiFile(MidiFilePath);

      AudioSourceToPlay.loop = true;
      AudioSourceToPlay.Play();
   }

   public void Stop()
   {
      if (!AudioSourceToPlay)
         return;

      AudioSourceToPlay.Stop();
   }

   public void SetPaused(bool pause)
   {
      if(pause)
      {
         if (AudioSourceToPlay)
            AudioSourceToPlay.Pause();
      }
      else
      {
         if (AudioSourceToPlay)
            AudioSourceToPlay.UnPause();
      }
   }

   public void SetSpeed(float s)
   {
      if (AudioSourceToPlay)
         AudioSourceToPlay.pitch = s;
   }

   public float SecsToBeats(float secs)
   {
      if (!_HasMidiFile())
         return 0.0f;

      long microseconds = (long)(secs * 1000000.0f);

      MetricTimeSpan inputSpan = new MetricTimeSpan(microseconds);
      BeatTimeSpan outputSpan = TimeConverter.ConvertTo<BeatTimeSpan>(inputSpan, _tempoMap);


      float beats = (float)outputSpan.Beats;
      beats += ((float)outputSpan.Ticks / _TicksPerBeat());

      return beats;
   }

   public float BeatsToSecs(float beat)
   {
      if (!_HasMidiFile())
         return 0.0f;

      float frac = beat % 1.0f;
      int beats = (int)beat;
      int ticks = (int)(frac * _TicksPerBeat());
      BeatTimeSpan inputSpan = new BeatTimeSpan(beats, ticks);
      MetricTimeSpan outputSpan = TimeConverter.ConvertTo<MetricTimeSpan>(inputSpan, _tempoMap);

      float secs = outputSpan.TotalMicroseconds / 1000000.0f;

      return secs;
   }

   void Update()
   {
      if (!AudioSourceToPlay)
         return;

      CurSecs = AudioSourceToPlay.timeSamples * (1.0f / AudioSourceToPlay.clip.frequency);
      CurBeat = SecsToBeats(CurSecs);
   }


   int _TicksPerBeat()
   {
      if (!_HasMidiFile())
         return 480;
      var ticksPerQuarterNoteTimeDivision = _tempoMap.TimeDivision as TicksPerQuarterNoteTimeDivision;
      return ticksPerQuarterNoteTimeDivision.ToInt16();
   }

   bool _HasMidiFile()
   {
      return _tempoMap != null;
   }

   bool _LoadMidiFile(string path)
   {
      if (_HasMidiFile() && _loadedMidiPath.Equals(path)) //already loaded?
         return true;

      _tempoMap = null;

      string fullMidiPath = Application.streamingAssetsPath + "/" + path;
      if (Application.platform == RuntimePlatform.Android)
      {
         try
         {
            WWW r = new WWW(fullMidiPath);
            while (!r.isDone) { }

            System.IO.MemoryStream stream = new System.IO.MemoryStream(r.bytes);
            _midiFile = MidiFile.Read(stream);
         }
         catch (System.Exception e)
         {
            Debug.LogWarning("unable to load midi file: " + e.Message);
         }
      }
      else
      {
         try
         {
            _midiFile = MidiFile.Read(fullMidiPath);
         }
         catch (System.Exception e)
         {
            Debug.LogWarning("unable to load midi file: " + e.Message);
         }

      }

      if (_midiFile == null)
      {
         Debug.LogWarning("FAILED to Load '" + fullMidiPath + "'");
         return false;
      }
      else
         Debug.Log("Loaded '" + fullMidiPath + "'");


      _tempoMap = _midiFile.GetTempoMap();


      return true;
   }

   void _OnDebugPlay()
   {
      Play();
   }

   void _OnDebugStop()
   {
      Stop();
   }

   void _OnDebugPause()
   {
      SetPaused(true);
   }

   void _OnDebugResume()
   {
      SetPaused(false);
   }
}
