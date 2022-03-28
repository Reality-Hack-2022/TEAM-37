//
//  Laser point for SpatialU UI
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILaserPointer : MonoBehaviour
{
   public bool AutoSwitchHands = true;
   public VRInputMgr.Hand StartHand = VRInputMgr.Hand.Right;
   public Color DefaultLaserColor = Color.white;
   public Color HighlightLaserColor = Color.green;
   public float DefaultLaserLength = 100.0f;
   public LineRenderer LaserLineRnd;

   VRInputMgr.Hand _activeHand = VRInputMgr.Hand.Right;
   bool _laserEnabled = false;

   void Awake()
   {
      EnableLaser(false);
   }
   void Start()
   {
      _activeHand = StartHand;

      if(LaserLineRnd)
      {
         LaserLineRnd.useWorldSpace = true;
         LaserLineRnd.positionCount = 2;
      }
   }

   public VRInputMgr.Hand GetActiveHand() { return _activeHand; }

   public void EnableLaser(bool b)
   {
      _laserEnabled = b;
      if (LaserLineRnd)
         LaserLineRnd.gameObject.SetActive(b);
   }

   public bool GetLaserEnabled() { return _laserEnabled; }

   public Vector3 GetLaserDir()
   {
      Quaternion rot = VRInputMgr.GetHandRot(_activeHand);
      return rot * Vector3.forward;
   }

   public Vector3 GetLaserBasePos()
   {
      return VRInputMgr.GetHandPos(_activeHand);
   }


   void Update()
   {
      if (!_laserEnabled)
         return;

      //press trigger to switch which hand the laser pointer is attached to
      if(AutoSwitchHands)
      {
         var otherHand = (_activeHand == VRInputMgr.Hand.Left) ? VRInputMgr.Hand.Right : VRInputMgr.Hand.Left;
         if (VRInputMgr.GetTriggerDown(otherHand))
            _activeHand = otherHand;
      }

      //update line renderer
      Vector3 basePos = GetLaserBasePos();
      LaserLineRnd.SetPosition(0, basePos);

      if (UIMgr.I.GetIsPointingAtUIItem()) //if pointing at something in the UI, laser ends at UI item intersection
      {
         LaserLineRnd.material.color = HighlightLaserColor;
         LaserLineRnd.SetPosition(1, UIMgr.I.GetLastUIItemHitPos());
      }
      else //not pointing at anything, just use default length
      {
         LaserLineRnd.material.color = DefaultLaserColor;
         LaserLineRnd.SetPosition(1, basePos + DefaultLaserLength * GetLaserDir());
      }
   }
}
