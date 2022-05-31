//
// Responsible for attaching lanes to a gameplay object, like the player
// It's expected that lanes themeselves are child objects
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFLanesRig : MonoBehaviour 
{
   public Transform VisualsParent;
   [Tooltip("Lanes for cues to travel down")]
   public SFLanesLane[] Lanes = new SFLanesLane[0];
   [Tooltip("Show this in a lane you are being successful in")]
   public GameObject LanesSuccessFeedback;

   int _selectedLaneIdx = -1;

   public int GetNumLanes()
   {
      return Lanes.Length;
   }

   public SFLanesLane GetLane(int idx)
   {
      if ((idx < 0) || (idx >= Lanes.Length))
         return null;
      return Lanes[idx];
   }

   public int GetSelectedLaneIdx()
   {
      return _selectedLaneIdx;
   }

   //called to select which lane the player is "in"
   public void SelectLane(int laneIdx)
   {
      if (_selectedLaneIdx == laneIdx)
         return;

      if((laneIdx < 0) || (laneIdx >= GetNumLanes()))
      {
         Debug.LogWarning("Can't select lane idx " + laneIdx + " because its invalid.  num lanes = " + GetNumLanes());
         return;
      }

      _selectedLaneIdx = laneIdx;

      //Debug.Log("Selected lane changed to " + _selectedLaneIdx);

      //select lane (deselect others)
      for(int i = 0; i < GetNumLanes(); i++)
      {
         GetLane(i).SetLaneSelected(i == _selectedLaneIdx);
      }
   }

   void Start()
   {
      if (LanesSuccessFeedback)
         LanesSuccessFeedback.SetActive(false);

      //assign lane idx to each lane
      for (int i = 0; i < GetNumLanes(); i++)
      {
         GetLane(i).Init(i);
      }
   }   

}
