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

[ExecuteInEditMode]
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
   
   [Space(10)]

   public int LoopStartFrameIdx = 0;
   public bool OverrideEndFrame = false;
   public int LoopEndFrameIdx = 0;

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
   [Tooltip("Do we interpret progress values in steps as frame counts?  if not, then they are percentage of the way thru all the frames")]
   public bool StepProgressIsFrames = false;
   public Step[] Steps = new Step[0];


   [System.Serializable]
   public class Step
   {
      public float StartProgress = 0.0f;
      public float EndProgress = 1.0f;

      public float NumLoopBeats = 4.0f;
      public float WaitBeatsToRepeat = 0.0f;
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

   //when steps have a timeout before they can repeat, we schedule them
   public class ScheduledLoop
   {
      public float StartBeat = 0.0f; //when the loop starts playing
      public float EndBeat = 0.0f; //when the loop is finished
      public int StepIdx = -1; 
      public float PrerollBeats = 0.0f; //the # of beats of "preroll" animation we show leading into the first frame

      public float ScheduleBeat = 0.0f; //what beat were we scheduled on (i.e when did we submit this scheduled loop?)
   }

   public enum ScheduledLoopState
   {
      None,
      Waiting,
      Preroll,
      Playing
   }

   //events
   public VolumetricPlayEvent OnPlaybackStateChanged = new VolumetricPlayEvent();
   public VolumetricPlayerStepEvent OnStepChanged = new VolumetricPlayerStepEvent();

   ScheduledLoop _curScheduledLoop = null;
   PlaybackState _playbackState = PlaybackState.Stopped;
   float _lastFrame = 0.0f;
   int _lastFrameIdx = 0;
   float _lastLoopProgress = 0.0f;

   float _startTime = 0.0f;

   int _curStepShowing = -1;

   int _numRepeatsShown = 0;

   ScheduledLoopState _curScheduledState = ScheduledLoopState.None;

   //how many preroll beats do we want to show when playing a scheduled loop?
   const float kNumPrerollBeats = 2.0f;

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

   public ScheduledLoopState GetScheduledState() { return _curScheduledState; }
   public ScheduledLoop GetScheduledLoop() { return _curScheduledLoop; }

   public float GetLoopProgress() { return _lastLoopProgress; }

   //schedule the given step to play at the given beat
   public void ScheduleStep(int stepIdx, float relativeToBeat = -1.0f)
   {
      //schedule start of loop on nearest downbeat that also gives time for our preroll beats to play
      float scheduledBeat = (relativeToBeat >= 0.0f) ? relativeToBeat : SongMgr.I.CurBeat; 
      float startBeat = scheduledBeat;
      startBeat += kNumPrerollBeats;
      //quantize to nearest downbeat (assuming 4/4 time signature!)
      const float kQuantizeBeats = 4.0f;
      float mod = startBeat % kQuantizeBeats;
      startBeat += (kQuantizeBeats - mod);


      ScheduledLoop sl = new ScheduledLoop();
      sl.ScheduleBeat = scheduledBeat;
      sl.StartBeat = startBeat;
      sl.EndBeat = startBeat + Steps[stepIdx].NumLoopBeats;
      sl.StepIdx = stepIdx;
      //show the preroll for a fixed # of beats or half the wait beats (if smaller than our ideal preroll)      
      sl.PrerollBeats = Mathf.Min(kNumPrerollBeats, Steps[stepIdx].WaitBeatsToRepeat * .5f);

      _curScheduledLoop = sl;

      _curScheduledState = ScheduledLoopState.Waiting;
   }

   public void CancelScheduledStep()
   {
      _curScheduledLoop = null;
      _curScheduledState = ScheduledLoopState.None;
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
         int startFrameIdx = _StepToStartFrame(step);
         int endFrameIdx = _StepToEndFrame(step);

         if ((_lastFrameIdx >= startFrameIdx) && (_lastFrameIdx <= endFrameIdx))
            return i;
      }

      //should never get here
      Debug.LogWarning("ComputeCurrentStep() couldnt figure out which step you were on... (curFrame = " + _lastFrameIdx + ")");
      return 0;
   }

   int _StepToStartFrame(Step step)
   {
      if (StepProgressIsFrames)
         return Mathf.RoundToInt(step.StartProgress);
      else
         return Mathf.FloorToInt(step.StartProgress * (float)(MeshSequence.Length - 1));
   }

   int _StepToEndFrame(Step step)
   {
      if (StepProgressIsFrames)
         return Mathf.RoundToInt(step.EndProgress);
      else
         return Mathf.FloorToInt(step.EndProgress * (float)(MeshSequence.Length - 1));
   }

   void Start()
   {
      if(!Application.isPlaying)
         return;

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
         _lastLoopProgress = 0.0f;
         //reschedule loop if we were in the middle of a scheduled loop when playback stopped
         if (_curScheduledLoop != null)
         {
            if (CurStep == _curScheduledLoop.StepIdx)
               ScheduleStep(CurStep);
            else
               CancelScheduledStep();
         }
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
      if(DriveSongPlaybackState && SongMgr.I && (SeqType != SequenceType.SyncWithOtherSequencer))
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
      //when not playing, just drive frame with debug properties
      if (!Application.isPlaying)
      {
         if(CurFrame != _lastFrameIdx)
         {
            _ShowFrame(CurFrame);
         }

         return;
      }

      //keep song speed in sync with animation speed
      if (DriveSongPlaybackState && (SeqType != SequenceType.SyncWithOtherSequencer))
      {
         if (!Mathf.Approximately(PlaybackSpeed, SongMgr.I.GetSpeed()))
            SongMgr.I.SetSpeed(PlaybackSpeed);
      }

      if(CurStep != -1)
      {
         if (_curStepShowing != CurStep)
         {
            OnStepChanged.Invoke(CurStep);
            _curStepShowing = CurStep;

            //this is a step that needs to be scheduled because its not a simple loop
            if ((CurStep >= 0) && (Steps[CurStep].WaitBeatsToRepeat > 0.0f))
               ScheduleStep(CurStep);
            else
               CancelScheduledStep();
         }
      }

      if(SeqType == SequenceType.SyncWithOtherSequencer)
      {
         SetPlaybackState(SequenceToSyncWith.GetPlaybackState());
      }

      if (_playbackState == PlaybackState.Playing)
      {
         if(SeqType == SequenceType.MeshSequence)
         {
            int startFrameIdx = LoopStartFrameIdx;
            int endFrameIdx = OverrideEndFrame ? LoopEndFrameIdx : MeshSequence.Length - 1;
            Step curStep = null;
            if((CurStep >= 0) && (CurStep < Steps.Length))
            {
               curStep = Steps[CurStep];
               startFrameIdx = _StepToStartFrame(curStep);
               endFrameIdx = _StepToEndFrame(curStep);
            }

            int curFrameIdx = _lastFrameIdx;

            if(BeatSync) //scrub in sync with the beat
            {
               if (_curScheduledLoop != null) //specially scheduled playthru
               {
                  Step stepBeingShown = Steps[_curScheduledLoop.StepIdx];
                  startFrameIdx = _StepToStartFrame(stepBeingShown);
                  endFrameIdx = _StepToEndFrame(stepBeingShown);

                  float loopProgress = 0.0f;

                  float curBeat = SongMgr.I.CurBeat;
                  if (curBeat < _curScheduledLoop.StartBeat) //waiting for start, also handle preroll
                  {
                     //keep frozen until our preroll region
                     float prerollStart = _curScheduledLoop.StartBeat - _curScheduledLoop.PrerollBeats;
                     float prerollEnd = _curScheduledLoop.StartBeat;
                     _curScheduledState = ScheduledLoopState.Waiting;
                     if (curBeat >= prerollStart) //play preroll portion
                     {
                        _curScheduledState = ScheduledLoopState.Preroll;

                        //figure out how many preroll frames we have
                        float framesPerBeat = (endFrameIdx - startFrameIdx) / stepBeingShown.NumLoopBeats;
                        int numPrerollFrames = Mathf.RoundToInt(framesPerBeat * _curScheduledLoop.PrerollBeats);
                        int prerollStartFrame = Mathf.Max(0, startFrameIdx - numPrerollFrames);
                        int prerollEndFrame = Mathf.Max(0, startFrameIdx - 1);

                        float prerollProgress = Mathf.InverseLerp(prerollStart, prerollEnd, curBeat);
                        _lastFrame = Mathf.Lerp(prerollStartFrame, prerollEndFrame, prerollProgress);
                        curFrameIdx = Mathf.FloorToInt(_lastFrame);
                     }
                  }
                  else //in scheduled playback region
                  {
                     _curScheduledState = ScheduledLoopState.Playing;

                     loopProgress = Mathf.InverseLerp(_curScheduledLoop.StartBeat, _curScheduledLoop.EndBeat, curBeat);
                     _lastFrame = Mathf.Lerp(startFrameIdx, endFrameIdx, loopProgress);
                     curFrameIdx = Mathf.FloorToInt(_lastFrame);
                  }

                  _lastLoopProgress = loopProgress;

                  //done playing? reschedule!
                  if (Mathf.Approximately(loopProgress, 1.0f))
                     ScheduleStep(_curScheduledLoop.StepIdx, _curScheduledLoop.EndBeat);                  
               }
               else //normal seamless looping step
               {
                  int stepIdxBeingShow = ComputeCurrentStep();
                  Step stepBeingShow = (stepIdxBeingShow >= 0) && (stepIdxBeingShow < Steps.Length) ? Steps[stepIdxBeingShow] : null;

                  float loopBeats = (curStep != null) ? stepBeingShow.NumLoopBeats : NumLoopBeats;

                  float loopProgress = (SongMgr.I.CurBeat % loopBeats) / loopBeats;

                  _lastFrame = Mathf.Lerp(startFrameIdx, endFrameIdx, loopProgress);
                  curFrameIdx = Mathf.FloorToInt(_lastFrame);

                  _lastLoopProgress = loopProgress;
               }
            }
            else //play at desired FPS
            {
               _lastFrame += Time.deltaTime * (float)FPS * PlaybackSpeed;

               int len = Mathf.Max(0, (endFrameIdx - startFrameIdx));
               curFrameIdx = Mathf.FloorToInt(_lastFrame % len);
               curFrameIdx += startFrameIdx;

               _lastLoopProgress = Mathf.InverseLerp(startFrameIdx, endFrameIdx, curFrameIdx);
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

      var prevComputedStep = ComputedStep;
      ComputedStep = ComputeCurrentStep();
      
      if(CurStep == -1)
      {
         if (prevComputedStep != ComputedStep)
            OnStepChanged.Invoke(ComputedStep);
      }
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
