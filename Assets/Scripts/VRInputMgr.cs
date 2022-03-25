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
