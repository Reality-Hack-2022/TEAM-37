using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CamMgr : MonoBehaviour
{
   public bool RecenterAtStart = false;
   public CamMode CamType = CamMode.Oculus;
   public GameObject OculusRig;
   public GameObject HololensRig;
   public GameObject ScreenRig;

   //events
   public UnityEvent OnVRRecenter = new UnityEvent();

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
      _isFirstRecenter = true;
      if (OculusRig)
         OculusRig.SetActive(CamType == CamMode.Oculus);
      if (HololensRig)
         HololensRig.SetActive(CamType == CamMode.Hololens);
      if (ScreenRig)
         ScreenRig.SetActive(CamType == CamMode.Screen);

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

   bool _isFirstRecenter = true;

   void _OnRecentered()
   {
      Debug.Log("GOT RECENTERED at " + Time.time);
      
      if(_isFirstRecenter)
      {
         StartCoroutine(_DoFirstRecenter());
         _isFirstRecenter = false;
      }
      else
         OnVRRecenter.Invoke();
   }

   IEnumerator _DoFirstRecenter()
   {
      //wait for an actual head pose before sending recenter, because some scripts want to adapt to player height (see SetUIHeight.cs for example)
      Vector3 headPos = VRInputMgr.GetHeadPos();
      while(Mathf.Approximately(headPos.y, 0.0f))
      {
         yield return new WaitForEndOfFrame();

         headPos = VRInputMgr.GetHeadPos();
      }

      OnVRRecenter.Invoke();
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

      if (Input.GetKeyDown(KeyCode.C))
         _OculusRecenter();
   }
}
