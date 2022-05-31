//
// A lane a cue can travel down
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SFLanesLane : MonoBehaviour 
{
   [Header("Config")]
   [Tooltip("Arrival position for cues")]
   public Transform ArrivalPt;
   [Tooltip("The forwar direction of this transform (i.e +Z) defines the direction cues move in")]
   public Transform TravelDir;

   [Header("Selection")]
   public Renderer SelectedRnd;
   public string SelectedColorProp = "";
   public Color SelectedColor = Color.white;
   public Color NotSelectedColor = Color.gray;

   [Header("Lane Length")]
   [Tooltip("Scale this in its +Z direction to the length of the lane (based on look ahead beats)")]
   public Transform ScaleToLaneLength;

   //events
   public UnityEvent OnLaneSelected = new UnityEvent();
   public UnityEvent OnLaneDeselected = new UnityEvent();

   public class TrackedCue
   {
      public SFLanesCue Cue = null;
      public Vector3 StartLaneOffset = Vector3.zero; //offset we need to travel to arrive at the "now" spot
      public Vector3 EndOffset = Vector3.zero; ///offset we need to travel after having arrived to reach our end time
   }

   List<TrackedCue> _trackedCues = new List<TrackedCue>();
   bool _isSelected = false;
   int _laneIdx = -1;

   public int GetNumActiveCues()
   {
      return _trackedCues.Count;
   }

   public SFLanesCue GetActiveCue(int idx)
   {
      if ((idx < 0) || (idx >= GetNumActiveCues()))
         return null;

      return _trackedCues[idx].Cue;
   }

   public int GetLaneIdx()
   {
      return _laneIdx;
   }

   public void Init(int laneIdx)
   {
      _laneIdx = laneIdx;
   }

   public void AddCueToLane(SFLanesCue cue)
   {
      cue.transform.rotation = ArrivalPt.rotation;

      TrackedCue tc = new TrackedCue();
      tc.Cue = cue;
      //figure out our start offset
      float cueSpeed = SFLanesCueingMgr.I.CueTravelSpeed;
      float travelSecs = cue.GetArriveSecs() - cue.GetSpawnSecs();
      float travelDist = cueSpeed * travelSecs;
      tc.StartLaneOffset = travelDist*GetTravelDir();
      //figure out end offset
      float endTravelSecs = cue.GetEndSecs() - cue.GetArriveSecs();
      float endTravelDist = cueSpeed * endTravelSecs;
      tc.EndOffset = endTravelDist * -1.0f * GetTravelDir();

      _trackedCues.Add(tc);
   }

   public Vector3 GetTravelDir()
   {
      return TravelDir ? TravelDir.forward : Vector3.forward;
   }

   public bool GetIsLaneSelected()
   {
      return _isSelected;
   }

   public void SetLaneSelected(bool b)
   {
      if (b == _isSelected)
         return;

      _isSelected = b;

      _RefreshSelectionVisuals();

      if (_isSelected)
         OnLaneSelected.Invoke();
      else
         OnLaneDeselected.Invoke();
   }

   void _RefreshSelectionVisuals()
   {
      if (SelectedRnd)
      {
         if (SelectedColorProp.Length > 0)
         {
            SelectedRnd.material.SetColor(SelectedColorProp, GetIsLaneSelected() ? SelectedColor : NotSelectedColor);
         }
      }
   }

   void Start()
   {
      _RefreshSelectionVisuals();
   }

   void _UpdateLaneLength()
   {
      if (!ScaleToLaneLength)
         return;

      //figure out how long the lane should be based on travel beats and cue speed
      float fromBeat = SFSongMgr.I.GetCurrentSong().GetCurBeat();
      float toBeat = fromBeat + SFLanesCueingMgr.I.LaneTravelBeats;

      float cueSpeed = SFLanesCueingMgr.I.CueTravelSpeed;
      float travelSecs = SFSongMgr.I.GetCurrentSong().BeatsToSecs(toBeat) - SFSongMgr.I.GetCurrentSong().BeatsToSecs(fromBeat);
      float travelDist = cueSpeed * travelSecs;

      //stretch object to match distance!
      Vector3 curScale = ScaleToLaneLength.localScale;
      curScale.z = travelDist;
      ScaleToLaneLength.localScale = curScale;
   }

   void Update()
   {
      if ((SFSongMgr.I.GetCurrentSong() == null) || !ArrivalPt)
         return;

      _UpdateLaneLength();

      float curSecs = SFSongMgr.I.GetCurrentSong().GetCurContentTime();
      float curBeat = SFSongMgr.I.GetCurrentSong().GetCurBeat();

      //process tracked cues
      List<TrackedCue> toDelete = new List<TrackedCue>();
      foreach(TrackedCue cue in _trackedCues)
      {
         float arriveProgress = Mathf.InverseLerp(cue.Cue.GetSpawnBeat(), cue.Cue.GetArriveBeat(), curBeat);

         if(Mathf.Approximately(arriveProgress, 1.0f)) //arrived?
         {
            //now we "continue moving
            float endProgress = Mathf.InverseLerp(cue.Cue.GetArriveBeat(), cue.Cue.GetEndBeat(), curBeat);
            Vector3 curOffset = Vector3.Lerp(Vector3.zero, cue.EndOffset, endProgress);
            cue.Cue.transform.position = ArrivalPt.position + curOffset;

            if(Mathf.Approximately(endProgress, 1.0f)) //done with cue?
            {
               toDelete.Add(cue);
            }
         }
         else //haven't arrived yet, move to the "now" spot
         {
            Vector3 curOffset = Vector3.Lerp(cue.StartLaneOffset, Vector3.zero, arriveProgress);

            cue.Cue.transform.position = ArrivalPt.position + curOffset;
         }
      }

      //clean up any cues marked for delete
      foreach(TrackedCue cue in toDelete)
      {
         GameObject toDestroy = cue.Cue.gameObject;
         _trackedCues.Remove(cue);
         Destroy(toDestroy);
      }
   }
}
