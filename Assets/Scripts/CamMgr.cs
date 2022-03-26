using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMgr : MonoBehaviour
{
   public bool RecenterAtStart = false;
   public CamMode CamType = CamMode.Oculus;
   public GameObject OculusRig;
   public GameObject HololensRig;
   public GameObject ScreenRig;

   public static CamMgr I { get; private set; }

   bool _vrEnabled = false;

   public enum CamMode
   {
      Oculus,
      Hololens,
      Screen
   }

   void Awake()
   {
      I = this;
   }

   void Start()
   {
      if (OculusRig)
         OculusRig.SetActive(CamType == CamMode.Oculus);
      if (HololensRig)
         OculusRig.SetActive(CamType == CamMode.Hololens);
      if (ScreenRig)
         OculusRig.SetActive(CamType == CamMode.Screen);

   }

   bool _hasRegisteredRecenterEvent = false;
   void _OculusRecenter()
   {
      if (OVRManager.display != null)
      {
         //register to find out when a recenter happens
         if (!_hasRegisteredRecenterEvent)
         {
            OVRManager.display.RecenteredPose += _OnRecentered;
            _hasRegisteredRecenterEvent = true;
         }

         OVRManager.display.RecenterPose();
      }
   }


   void _OnRecentered()
   {
      Debug.Log("GOT RECENTERED at " + Time.time);
   }

   void _EnableXR()
   {
      if (_vrEnabled)
         return;

      Debug.Log("XR enabled successfully!");

      _vrEnabled = true;

      if (RecenterAtStart && (CamType == CamMode.Oculus))
      {
         _OculusRecenter();
      }
   }

   void Update()
   {
      //detect when vr hmd first becomes preset
      if (OculusRig && OculusRig.gameObject.activeInHierarchy)
      {
         if (_vrEnabled != OVRManager.isHmdPresent)
         {
            if (OVRManager.isHmdPresent)
               _EnableXR();
         }
      }
   }
}
