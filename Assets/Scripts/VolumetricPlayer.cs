//
// playback a volumetric clip
//

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[System.Serializable]
public class VolumetricPlayEvent : UnityEvent<VolumetricPlayer.PlaybackState, VolumetricPlayer.PlaybackState> { } //old state, new state

[System.Serializable]
public class VolumetricPlayerStepEvent : UnityEvent<int> { } //new step

public class VolumetricPlayer : MonoBehaviour
{
   [Header("Basic Config")]
   public bool PlayAtStart = true;
   //public string AnnotationsPath = "";
   public SequenceType SeqType = SequenceType.MeshSequence;
   public GameObject[] MeshSequence = new GameObject[0];
   public PlayableDirector Timeline;
   public VolumetricPlayer SequenceToSyncWith;
   public int FPS = 30;
   public float PlaybackSpeed = 1.0f;

   [Space(10)]

   public bool BeatSync = false;
   public float NumLoopBeats = 4.0f;

   public enum SequenceType
   {
      MeshSequence,
      Timeline,
      SyncWithOtherSequencer
   }

   [Header("Song Driver")]
   public bool DriveSongPlaybackState = false;


   [Header("Steps")]
   [Tooltip("Set CurStep to -1 if you want to play thru ")]
   public int CurStep = -1;
   public Step[] Steps = new Step[0];


   [System.Serializable]
   public class Step
   {
      public float StartProgress = 0.0f;
      public float EndProgress = 1.0f;

      public float NumLoopBeats = 4.0f;
   }

   [Header("Outputs")]
   public int CurFrame = 0;
   public float CurProgress = 0.0f;
   public int ComputedStep = -1;

   [Header("Debug")]
   [InspectorButton("_DebugPlay")]
   public bool Play;
   [InspectorButton("_DebugPause")]
   public bool Pause;
   [InspectorButton("_DebugStop")]
   public bool Stop;

   [Space(10)]

   [InspectorButton("_DebugStepForward")]
   public bool StepForward;
   [InspectorButton("_DebugStepBackward")]
   public bool StepBackward;

   [Space(10)]

   public bool ApplyMaterialAtStart = false;
   public Material MaterialToApply;
   public string TextureProperty = "";
   [InspectorButton("_DebugApplyMaterial")]
   public bool ApplyMaterial;

   //events
   public VolumetricPlayEvent OnPlaybackStateChanged = new VolumetricPlayEvent();
   public VolumetricPlayerStepEvent OnStepChanged = new VolumetricPlayerStepEvent();


   PlaybackState _playbackState = PlaybackState.Stopped;
   float _lastFrame = 0.0f;
   int _lastFrameIdx = 0;

   float _startTime = 0.0f;

   int _curStepShowing = -1;

   public int GetLastFrameIdx() { return _lastFrameIdx; }

   public bool GotoNextStep()
   {
      if (CurStep < (Steps.Length - 1))
      {
         CurStep++;
         return true;
      }

      return false;
   }

   public bool GotoPreviousStep()
   {
      if(CurStep > 0)
      {
         CurStep--;
         return true;
      }

      return false;
   }

   public enum PlaybackState
   {
      Stopped,
      Playing, 
      Paused
   }

   //what step are we on, based on current frame? (only applicable if CurStep property is -1)
   public int ComputeCurrentStep()
   {
      if (CurStep >= 0)
         return CurStep;

      for(int i = 0; i < Steps.Length; i++)
      {
         var step = Steps[i];
         int startFrameIdx = Mathf.FloorToInt(step.StartProgress * (float)(MeshSequence.Length - 1));
         int endFrameIdx = Mathf.FloorToInt(step.EndProgress * (float)(MeshSequence.Length - 1));

         if ((_lastFrameIdx >= startFrameIdx) && (_lastFrameIdx <= endFrameIdx))
            return i;
      }

      //should never get here
      Debug.LogWarning("ComputeCurrentStep() couldnt figure out which step you were on... (curFrame = " + _lastFrameIdx + ")");
      return 0;
   }

   void Start()
   {
      if (PlayAtStart)
         SetPlaybackState(PlaybackState.Playing);
      if(SeqType == SequenceType.Timeline)
      {
         //we need to scrub the timeline manually because we want to control loop points and speed ourselves
         Timeline.timeUpdateMode = DirectorUpdateMode.Manual;
      }


      if (ApplyMaterialAtStart)
      {
         _DebugApplyMaterial();
      }
   }

   public PlaybackState GetPlaybackState() { return _playbackState; }

   public void SetPlaybackState(PlaybackState newState)
   {
      if (_playbackState == newState)
         return;

      var oldState = _playbackState;
      _playbackState = newState;

      //restart clip when going into play state
      if ((oldState == PlaybackState.Stopped) && (newState == PlaybackState.Playing))
      {
         _startTime = 0.0f;
         _lastFrame = 0.0f;
      }

      if(SeqType == SequenceType.Timeline)
      {
         if (newState == PlaybackState.Playing)
            Timeline.Play();
         else if (newState == PlaybackState.Paused)
            Timeline.Pause();
         else if (newState == PlaybackState.Stopped)
            Timeline.Stop();
      }

      //drive song state in sync with our state, if configured
      if(DriveSongPlaybackState && SongMgr.I)
      {
         if (newState == PlaybackState.Paused)
            SongMgr.I.SetPaused(true);
         else if (oldState == PlaybackState.Paused && newState == PlaybackState.Playing)
            SongMgr.I.SetPaused(false);
         else if (oldState == PlaybackState.Stopped && newState == PlaybackState.Playing)
            SongMgr.I.Play();
         else if (newState == PlaybackState.Stopped)
            SongMgr.I.Stop();
      }

      OnPlaybackStateChanged.Invoke(oldState, newState);
   }

   void _ShowFrame(int frameIdx)
   {
      if (frameIdx < 0 || frameIdx >= MeshSequence.Length)
         return;

      CurFrame = frameIdx;
      CurProgress = Mathf.InverseLerp(0, MeshSequence.Length - 1, frameIdx);

      if(GetPlaybackState() == PlaybackState.Paused)
      {
         _lastFrameIdx = frameIdx;
         _lastFrame = (float)frameIdx;
      }

      for (int i = 0; i < MeshSequence.Length;i++)
      {
         bool active = i == frameIdx;
         if (MeshSequence[i].activeSelf != active)
            MeshSequence[i].SetActive(active);
      }
   }

   void Update()
   {
      //keep song speed in sync with animation speed
      if(DriveSongPlaybackState)
      {
         if (!Mathf.Approximately(PlaybackSpeed, SongMgr.I.GetSpeed()))
            SongMgr.I.SetSpeed(PlaybackSpeed);
      }

      if(_curStepShowing != CurStep)
      {
         OnStepChanged.Invoke(CurStep);
         _curStepShowing = CurStep;
      }

      if(SeqType == SequenceType.SyncWithOtherSequencer)
      {
         SetPlaybackState(SequenceToSyncWith.GetPlaybackState());
      }

      if (_playbackState == PlaybackState.Playing)
      {
         if(SeqType == SequenceType.MeshSequence)
         {
            int startFrameIdx = 0;
            int endFrameIdx = MeshSequence.Length - 1;
            Step curStep = null;
            if((CurStep >= 0) && (CurStep < Steps.Length))
            {
               curStep = Steps[CurStep];
               startFrameIdx = Mathf.FloorToInt(curStep.StartProgress * (float)(MeshSequence.Length - 1));
               endFrameIdx = Mathf.FloorToInt(curStep.EndProgress * (float)(MeshSequence.Length - 1));
            }

            int curFrameIdx = _lastFrameIdx;
            if(BeatSync) //scrub in sync with the beat
            {
               float loopBeats = (curStep != null) ? curStep.NumLoopBeats : NumLoopBeats;

               float loopProgress = (SongMgr.I.CurBeat % loopBeats) / loopBeats;

               _lastFrame = Mathf.Lerp(startFrameIdx, endFrameIdx, loopProgress);
               curFrameIdx = Mathf.FloorToInt(_lastFrame);
            }
            else //play at desired FPS
            {
               _lastFrame += Time.deltaTime * (float)FPS * PlaybackSpeed;

               int len = Mathf.Max(0, (endFrameIdx - startFrameIdx));
               curFrameIdx = Mathf.FloorToInt(_lastFrame % len);
               curFrameIdx += startFrameIdx;
            }

            //int curFrameIdx = Mathf.FloorToInt(_lastFrame % MeshSequence.Length);
            _ShowFrame(curFrameIdx);

            _lastFrameIdx = curFrameIdx;
         }
         else if(SeqType == SequenceType.SyncWithOtherSequencer)
         {
            if(SequenceToSyncWith)
            {
               int frameIdx = SequenceToSyncWith.GetLastFrameIdx();
               _ShowFrame(frameIdx);
            }
         }
         else if(SeqType == SequenceType.Timeline)
         {
            float curTime = (float)Timeline.time;
            curTime += Time.deltaTime *  PlaybackSpeed;
            curTime = (curTime % (float)Timeline.duration); //loop

            Timeline.time = curTime;
         }
      }

      ComputedStep = ComputeCurrentStep();
   }

   void _DebugPlay()
   {
      SetPlaybackState(PlaybackState.Playing);
   }

   void _DebugStop()
   {
      SetPlaybackState(PlaybackState.Stopped);
   }
   void _DebugPause()
   {
      SetPlaybackState(PlaybackState.Paused);
   }

   void _DebugStepForward()
   {
      SetPlaybackState(PlaybackState.Paused);
      _ShowFrame(_lastFrameIdx + 1);
   }

   void _DebugStepBackward()
   {
      SetPlaybackState(PlaybackState.Paused);
      _ShowFrame(_lastFrameIdx - 1);
   }

   //force a different material onto the renderer associated with every mesh in the volumetric sequence
   void _DebugApplyMaterial()
   {
      if (!MaterialToApply)
         return;

      List<Renderer> rnds = new List<Renderer>();
      foreach(var m in MeshSequence)
      {
         Renderer r = m.GetComponentInChildren<Renderer>(true);
         if (r)
            rnds.Add(r);
      }

      foreach(var r in rnds)
      {
         Material oldMat = r.material;
         Texture oldTex = oldMat.mainTexture;

         Material dupedMaterial = Instantiate(MaterialToApply);
         dupedMaterial.SetTexture(TextureProperty, oldTex);
         r.material = dupedMaterial;
      }
   }
}
