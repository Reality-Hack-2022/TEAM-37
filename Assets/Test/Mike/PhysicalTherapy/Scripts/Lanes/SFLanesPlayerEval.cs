//
// This is the performance/scoring evaluator for a given player during lanes gameplay
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFLanesPlayerEval : MonoBehaviour 
{
   [Tooltip("If true, ignores input and just forces into correct lane, so all the gems are hit")]
   public bool Autoplay = false;
   public bool ActivateAtStart = true;
   [Tooltip("Assuming 3 lanes, how much of the input width goes to determining you are in one of the side lanes?")]
   public float SideLaneInputThresh = .2f;
   [Tooltip("Hystersis to for the lane input thresholds to avoid oscilations")]
   public float LaneHysteresis = .05f;

   bool _isActivated = false;

   void Start()
   {
      _isActivated = ActivateAtStart;
   }



   //0...1 input signal used to select which lane the player is in
   float _GetLaneInputSignal()
   {
      //HACK for now, use gamepad vertical stick
      float stick = -1.0f*Input.GetAxis("Vertical");

      float signal = Mathf.InverseLerp(-1.0f, 1.0f, stick);

      return signal;
   }

   void _SelectLane(int laneIdx)
   {
      if (SFLanesCueingMgr.I && SFLanesCueingMgr.I.LanesRig)
         SFLanesCueingMgr.I.LanesRig.SelectLane(laneIdx);
   }

   int _GetSelectedLaneIdx()
   {
      return SFLanesCueingMgr.I && SFLanesCueingMgr.I.LanesRig ? SFLanesCueingMgr.I.LanesRig.GetSelectedLaneIdx() : -1;
   }

   void Update()
   {
      if (!_isActivated)
         return;

      //get active lane cue 
      SFLanesCue activeLaneCue = SFLanesCueingMgr.I.GetActiveLaneCue();

      if (Autoplay)
      {
         //just go into the lane of the active cue
         if(activeLaneCue)
            _SelectLane(activeLaneCue.GetLane().GetLaneIdx());
      }
      else //normal input
      {
         //figure out which lane we think the player is in
         float inputSignal = _GetLaneInputSignal();
         //Debug.Log("lanes input signal: " + inputSignal + " left < thresh: " + (SideLaneInputThresh - LaneHysteresis) + " right >= thresh: " + (1.0f - SideLaneInputThresh + LaneHysteresis));
         if ((inputSignal <= (SideLaneInputThresh - LaneHysteresis))) //left lane
            _SelectLane(0);
         else if (inputSignal >= (1.0f - SideLaneInputThresh + LaneHysteresis)) //right lane
            _SelectLane(2);
         else //center lane
            _SelectLane(1);
      }

      int selectedLaneIdx = _GetSelectedLaneIdx();

      if(activeLaneCue)
      {
         bool isSuccess = activeLaneCue.GetLane().GetLaneIdx() == selectedLaneIdx;
         activeLaneCue.SetIsSustainSuccess(isSuccess);

         GameObject successFX = SFLanesCueingMgr.I.LanesRig.LanesSuccessFeedback;
         if(successFX != null)
         {
            successFX.transform.position = SFLanesCueingMgr.I.LanesRig.GetLane(selectedLaneIdx).ArrivalPt.position;
            successFX.SetActive(isSuccess);
         }
      }
   }
}
