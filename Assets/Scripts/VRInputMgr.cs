using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInputMgr : MonoBehaviour
{
   public enum Hand
   {
      Left,
      Right
   }

   public static Vector3 GetHeadPos()
   {
      if(CamMgr.I && (CamMgr.I.CamType == CamMgr.CamMode.Oculus) && CamMgr.I.OculusRig)
         return CamMgr.I.OculusRig.GetComponent<OVRCameraRig>().centerEyeAnchor.position;

      return Vector3.zero;
   }

   public static Quaternion GetHeadRot()
   {
      if (CamMgr.I && (CamMgr.I.CamType == CamMgr.CamMode.Oculus) && CamMgr.I.OculusRig)
         return CamMgr.I.OculusRig.GetComponent<OVRCameraRig>().centerEyeAnchor.rotation;

      return Quaternion.identity;
   }

   public static Vector3 GetHandPos(Hand hand)
   {
      Vector3 localPos = (OVRInput.GetLocalControllerPosition((hand == Hand.Left) ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch));
      return CamMgr.I.OculusRig.transform.TransformPoint(localPos);
   }

   public static Quaternion GetHandRot(Hand hand)
   {
      Quaternion localRot = (OVRInput.GetLocalControllerRotation((hand == Hand.Left) ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch));
      return CamMgr.I.OculusRig.transform.rotation * localRot;
   }


   public static bool GetTriggerDown(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) : OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger);
   }

   public static bool GetTriggerHeld(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.Get(OVRInput.RawButton.LIndexTrigger) : OVRInput.Get(OVRInput.RawButton.RIndexTrigger);
   }

   public static float GetTriggerPos(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) : OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
   }

   public static bool GetGripDown(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.GetDown(OVRInput.RawButton.LHandTrigger) : OVRInput.GetDown(OVRInput.RawButton.RHandTrigger);
   }

   public static bool GetGripHeld(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.Get(OVRInput.RawButton.LHandTrigger) : OVRInput.Get(OVRInput.RawButton.RHandTrigger);
   }

   public static bool GetBottomFaceButtonDown(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.GetDown(OVRInput.RawButton.X) : OVRInput.GetDown(OVRInput.RawButton.A);
   }

   public static bool GetBottomFaceButtonHeld(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.Get(OVRInput.RawButton.X) : OVRInput.Get(OVRInput.RawButton.A);
   }

   public static bool GetTopFaceButtonDown(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.GetDown(OVRInput.RawButton.Y) : OVRInput.GetDown(OVRInput.RawButton.B);
   }

   public static bool GetTopFaceButtonHeld(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.Get(OVRInput.RawButton.Y) : OVRInput.Get(OVRInput.RawButton.B);
   }

   public static float GetStickHorizontal(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x : OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
   }

   public static float GetStickVertical(Hand hand)
   {
      return (hand == Hand.Left) ? OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y : OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y;
   }
}
