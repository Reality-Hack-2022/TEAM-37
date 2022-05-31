//
// core cueing workhorse for lanes gameplay, where we cue things that travel down lanes towards the player
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SFLanesCueingMgr : SerializedMonoBehaviour //<-- need this in order for dictionary to serialize + show up in inspector
{
   [Tooltip("A prefab cue to spawn for each action type in the authoring")]
   [DictionaryDrawerSettings(KeyLabel = "Action", ValueLabel = "Cue Prefab")]
   public Dictionary<SFGameplayAction, SFLanesCue> ActionToCuePrefab = new Dictionary<SFGameplayAction, SFLanesCue>();
   [Tooltip("The cue to indicate when an individual lane is active")]
   public SFLanesCue LaneActiveCue = null;
   public SFLanesRig LanesRig;

   [Space(10)]

   [Tooltip("How many beats ahead of time does it take for a cue to travel down the lanes?")]
   public float LaneTravelBeats = 8.0f;
   public float CueTravelSpeed = 1.0f;
   [Tooltip("How long does a cue need to be in order for it to be considered a sustain?")]
   public float CueSustainMinBeats = 1.0f;
   [Tooltip("How many beats after arrive time does a cue stick around at minimum? (so it can pass the player fully...)")]
   public float CueMinOutroBeats = 2.0f;

   SFLanesCue _activeLaneCue = null; //the lane cue that is currently passing thru the now bar

   float _prevBeat = -1.0f;

   public static SFLanesCueingMgr I { get; private set; }

   public SFLanesCue GetActiveLaneCue()
   {
      return _activeLaneCue;
   }

   void Awake()
   {
      I = this;
   }

   void Start()
   {

   }


   bool _ShouldSpawnCue(float curBeat, float cueArriveBeat)
   {
      float spawnBeat = Mathf.Max(0.0f, cueArriveBeat - LaneTravelBeats);

      bool shouldSpawn = ((_prevBeat >= 0.0f) && (_prevBeat < spawnBeat) && (curBeat >= spawnBeat)) ||
                          ((_prevBeat < 0.0f) && (curBeat >= spawnBeat)
                         );

      return shouldSpawn;
   }

   //spawn cue into given lane
   void _SpawnCue(SFLanesCue cuePrefab, int laneIdx, float cueArriveBeat, float cueEndBeat)
   {
      if((laneIdx < 0) || (laneIdx >= LanesRig.GetNumLanes()))
      {
         Debug.LogWarning("Can't spawn cue into lane idx " + laneIdx + " because we only have " + LanesRig.GetNumLanes() + " lanes");
         return;
      }

      var lane = LanesRig.GetLane(laneIdx);

      GameObject cueObj = Instantiate(cuePrefab.gameObject) as GameObject;
      SFLanesCue cue = cueObj.GetComponent<SFLanesCue>();
      float cueSpawnBeat = Mathf.Max(0.0f, cueArriveBeat - LaneTravelBeats);
      cue.Init(lane, cueSpawnBeat, cueArriveBeat, cueEndBeat);

      lane.AddCueToLane(cue);
   }

   //we expect only one lane cue to be passing thru the now bar at a time, so find it!
   void _UpdateActiveLaneCue(float curBeat)
   {
      _activeLaneCue = null;

      for(int i = 0; i < LanesRig.GetNumLanes(); i++)
      {
         var lane = LanesRig.GetLane(i);
         for(int j = 0; j < lane.GetNumActiveCues(); j++)
         {
            var cue = lane.GetActiveCue(j);

            if ((curBeat >= cue.GetArriveBeat()) && (curBeat <= cue.GetEndBeat())) //found it?!
            {
               _activeLaneCue = cue;
               return;
            }
         }
      }
   }

   void Update()
   {

      float curSecs = SFSongMgr.I.GetCurrentSong().GetCurContentTime();
      float curBeat = SFSongMgr.I.GetCurrentSong().SecsToBeats(curSecs);

      SFMidiParser parser = SFSongMgr.I.GetParser();
      if (!parser)
         return;
      SFSongData parsedData = parser.GetParsedData();
      if (parsedData == null)
         return;

      //spawn lane cues into lanes
      foreach(var le in parsedData.LaneData.LaneEvents)
      {
         float cueArriveBeat = SFSongMgr.I.GetCurrentSong().SecsToBeats(le.StartSecs);
         float cueEndBeat    = SFSongMgr.I.GetCurrentSong().SecsToBeats(le.EndSecs);

         if(_ShouldSpawnCue(curBeat, cueArriveBeat))
         {
            int laneIdx = le.LaneIdx;
            SFLanesCue cuePrefab = LaneActiveCue;
            _SpawnCue(cuePrefab, laneIdx, cueArriveBeat, cueEndBeat);
         }
      }

      //spawn action cues into lanes
      foreach(var ae in parsedData.ActionData.ActionEvents)
      {
         float cueArriveBeat = SFSongMgr.I.GetCurrentSong().SecsToBeats(ae.StartSecs);
         float cueEndBeat = SFSongMgr.I.GetCurrentSong().SecsToBeats(ae.EndSecs);

         if (_ShouldSpawnCue(curBeat, cueArriveBeat))
         {
            int laneIdx = 1; //for now, action always go in the middle lane, might change this later...
            SFLanesCue cuePrefab = ActionToCuePrefab.ContainsKey(ae.Action) ?  ActionToCuePrefab[ae.Action] : null;
            if (cuePrefab != null)
               _SpawnCue(cuePrefab, laneIdx, cueArriveBeat, cueEndBeat);
            else
               Debug.LogWarning("Can't spawn cue for for action " + ae.Action.ToString() + " because no prefab has been specified for it!");
         }
      }

      _UpdateActiveLaneCue(curBeat);

      _prevBeat = curBeat;
   }
}
