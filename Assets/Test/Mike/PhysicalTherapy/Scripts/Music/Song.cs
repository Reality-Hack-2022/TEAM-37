//
//  a song is an audio file paired with a midi file (which contains tempo, and note events)
//

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;

public class Song : MonoBehaviour
{

   [Header("Basic Config")]
   public AudioClip AudioToPlay;
   public bool Loop = true;
   [Tooltip("path to a .mid file, expected to be relative to the StreamingAssets folder")]
   public string PathToMidiFile = "midi/test.mid";
   public bool EnableVolumeOverride = false;
   [Range(0.0f, 1.0f)]
   public float VolumeOverride = 1.0f;

   public struct Mbt
   {
      public Mbt(int m, int b, int t) { measure = m; beat = b; tick = t; }
      public int measure;
      public int beat;
      public int tick;

      public override string ToString()
      {
         return measure + "." + beat + "." + tick;
      }
   };

   AudioSource _source = null; //filled in when we are playing

   private MidiFile _midiFile;
   private TempoMap _tempoMap = null;
   private string _loadedMidiPath = "";

   private bool _isPaused = false;

   private bool _muted = false;

   private float _curContentTime = 0.0f;

   public bool IsPlaying()
   {
      return _source ? _source.isPlaying : false;
   }

   public bool IsPaused()
   {
      return _isPaused;
   }

   public bool IsMuted()
   {
      return _muted;
   }

   public void SetMuted(bool b)
   {
      if (b == IsMuted())
         return;

      _muted = b;

      if (_source)
         _source.mute = b;
   }

   public MidiFile GetMidiFile()
   {
      return _midiFile;
   }

   public TempoMap GetTempoMap()
   {
      return _tempoMap;
   }

   public void SetSpeed(float s, float duration = 0.0f)
   {
      if (_source)
      {
         if(Mathf.Approximately(duration, 0.0f))
           _source.pitch = s;
         else
         {
            StopCoroutine("_RampSpeedTo");
            StartCoroutine(_RampSpeedTo(s, duration));
         }
      }
   }

   IEnumerator _RampSpeedTo(float targetSpeed, float duration)
   {
      float startSpeed = _source.pitch;
      float startTime = Time.realtimeSinceStartup;
      float endTime = startTime + duration;

      float curTime = startTime;
      while(curTime <= endTime)
      {
         curTime = Time.realtimeSinceStartup;
         float u = Mathf.InverseLerp(startTime, endTime, curTime);
         _source.pitch = Mathf.Lerp(startSpeed, targetSpeed, u);

         yield return new WaitForEndOfFrame();
      }

      _source.pitch = targetSpeed;
   }

   public void Prepare()
   {
      _LoadMidiFile(PathToMidiFile);
   }

   public void Play(AudioSource source)
   {
      _isPaused = false;

      _source = source;

      source.clip = AudioToPlay;
      source.loop = Loop;
      source.Play();

      if (EnableVolumeOverride)
         source.volume = VolumeOverride;

      //load midi file
      if (!_HasMidiFile())
         _LoadMidiFile(PathToMidiFile);

      //hook it up to master timeline to expose time
      //if (MasterTimeline.I)
      //   MasterTimeline.I.SongToSyncWith = this;
   }

   public void Pause()
   {
      _isPaused = true;
      if(_source)
         _source.Pause();
   }

   public void Resume()
   {
      _isPaused = false;
      if (_source)
         _source.UnPause();
   }

   public void Stop()
   {
      if (!IsPlaying() && !IsPaused())
         return;

      _source.Stop();
      _source.time = 0.0f;
   }

   bool _HasMidiFile()
   {
      return _tempoMap != null;
   }

   //this is basically here for tools to use outside play mode, to obtain the parsed midi data
   //in game, we go thru the normal path of loading this when the song is "prepared"
   public MidiFile ForceLoadMidiFile()
   {
      _LoadMidiFile(PathToMidiFile);
      return _midiFile;
   }

   bool _LoadMidiFile(string path)
   {
      if (_HasMidiFile() && _loadedMidiPath.Equals(path)) //already loaded?
         return true;

      _tempoMap = null;

      //Read from resources (where midi expected to have .bytes extension) or Streaming Assets?
      const bool kReadFromResources = true;

      if (kReadFromResources)
      {
         //string off extension for loading from resources
         //NOTE: we expect to files in resources folder to have the .bytes extension
         path = path.Replace(".mid", "");

         try
         {
            TextAsset asset = Resources.Load(path) as TextAsset;
            Stream s = new MemoryStream(asset.bytes);
            _midiFile = MidiFile.Read(s);
         }
         catch (System.Exception e)
         {
            Debug.LogWarning("unable to load midi file " + path + " from resources: " + e.Message);
         }

         if (_midiFile == null)
         {
            Debug.LogWarning("FAILED to Load midi resource '" + path + "'");
            return false;
         }
         else
            Debug.Log("Loaded midi resource '" + path + "'");
      }
      else
      {
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
               Debug.LogWarning("Song._LoadMidiFile (ANDROID) is unable to load midi file: " + e.Message);
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
               Debug.LogWarning("Song._LoadMidiFile is unable to load midi file: " + e.Message);
            }

         }

         if (_midiFile == null)
         {
            Debug.LogWarning("FAILED to Load '" + fullMidiPath + "'");
            return false;
         }
         else
            Debug.Log("Loaded '" + fullMidiPath + "'");
      }


      _tempoMap = _midiFile.GetTempoMap();

      //do this someday?
      //_ParseAuthoring();

      return true;
   }

   public float GetCurContentTime()
   {
      return _curContentTime;
   }

   public float GetCurBeat()
   {
      return SecsToBeats(GetCurContentTime());
   }

   public float GetLengthSeconds()
   {
      return AudioToPlay ? AudioToPlay.length : 0.0f;
   }

   int _TicksPerBeat()
   {
      if (!_HasMidiFile())
         return 480;
      var ticksPerQuarterNoteTimeDivision = _tempoMap.TimeDivision as TicksPerQuarterNoteTimeDivision;
      return ticksPerQuarterNoteTimeDivision.ToInt16();
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

   public Mbt BeatsToMBT(float beat)
   {
      if (!_HasMidiFile())
         return new Mbt(0, (int)beat, 0);

      float frac = beat % 1.0f;
      int beats = (int)beat;
      int ticks = (int)(frac * _TicksPerBeat());
      BeatTimeSpan inputSpan = new BeatTimeSpan(beats, ticks);

      BarBeatTimeSpan outputSpan = TimeConverter.ConvertTo<BarBeatTimeSpan>(inputSpan, _tempoMap);

      return new Mbt((int)outputSpan.Bars, (int)outputSpan.Beats, (int)outputSpan.Ticks);
   }

   public float MBTToBeats(Mbt mbt)
   {
      if (!_HasMidiFile())
         return mbt.beat * 4;

      BarBeatTimeSpan inputSpan = new BarBeatTimeSpan(mbt.measure, mbt.beat, mbt.tick);
      BeatTimeSpan outputSpan = TimeConverter.ConvertTo<BeatTimeSpan>(inputSpan, _tempoMap);

      float resultBeats = (float)outputSpan.Beats + ((float)outputSpan.Ticks / _TicksPerBeat());

      return resultBeats;
   }

   void Update()
   {
      //is .time imprecise?
      //return _source ? _source.time : 0.0f;

      float newContentTime = 0.0f;
      if (_source)
      {
         //newContentTime = _source.time; //is .time imprecise?
         newContentTime = _source.timeSamples * (1.0f / _source.clip.frequency);
      }

      //seems like we need to do some smoothing on this...
      const float kTimeSmoothing = .5f;
      _curContentTime = (_curContentTime * (1.0f - kTimeSmoothing)) + (kTimeSmoothing * newContentTime);
   }
}
