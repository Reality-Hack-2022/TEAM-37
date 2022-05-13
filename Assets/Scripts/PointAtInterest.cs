//
// If something of interest is off camera, this shows up and points you in the direction
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtInterest : MonoBehaviour
{
   [Tooltip("The thing of interest")]
   public Transform InterestTarget;
   [Tooltip("How far in front of your head the indicator shows up")]
   public float DistanceFromHead = 1.0f;
   [Tooltip("This visual shows up and is oriented towards the target")]
   public Transform VisualParent = null;
   [Tooltip("How far off from interest do we need to be looking before the visual shows up?")]
   public float AngleThresh = 90.0f;
   public float RotateSpeed = 20.0f;

   [Space(10)]

   public bool FadeSpriteNearThresh = false;
   public SpriteRenderer SpriteToFade;
   public float FadeOverDegrees = 10.0f;

   void Update()
   {
      if (!VisualParent || !InterestTarget)
         return;

      Transform headTrans = VRInputMgr.GetHeadTrans();
      Vector3 headPos = headTrans.position;
      Quaternion headRot = headTrans.rotation;
      Vector3 headForward = headTrans.forward;

      //position visual
      VisualParent.transform.position = headPos + (headForward * DistanceFromHead);

      //rotation 
      Vector3 flattenedVector = Vector3.ProjectOnPlane((InterestTarget.position - headPos).normalized, headForward);
      Quaternion lookRotation = Quaternion.LookRotation(-headForward, flattenedVector.normalized);

      //angle
      float dotTo = Vector3.Dot(headForward, (InterestTarget.position - headPos).normalized);
      bool inFront = dotTo >= 0;
      //angle to
      float sideTo = Vector3.Dot(headTrans.transform.right, (InterestTarget.position - headPos).normalized);


      //flattern rotation when behind player
      if (!inFront)
      {
         //lock to a left and right direction if the target is behind:
         if (sideTo > 0)
            lookRotation = Quaternion.LookRotation(-headForward, headTrans.right);
         else
            lookRotation = Quaternion.LookRotation(-headForward, -headTrans.right);
      }

      //apply rot, and snap if the angle difference is large
      if (Quaternion.Angle(VisualParent.transform.rotation, lookRotation) > 90)
         VisualParent.transform.rotation = lookRotation;
      else
         VisualParent.transform.rotation = Quaternion.Slerp(VisualParent.transform.rotation, lookRotation, RotateSpeed * Time.deltaTime);

      //show visual only if angle is bigger than thresh     
      float angle = Mathf.Abs(Mathf.Acos(dotTo) * Mathf.Rad2Deg);
      VisualParent.gameObject.SetActive(angle >= AngleThresh);


      //fade sprite when close to thresh
      if(FadeSpriteNearThresh && SpriteToFade)
      {
         float fade = Mathf.InverseLerp(AngleThresh, AngleThresh + FadeOverDegrees, angle);
         Color c = SpriteToFade.color;
         c.a = fade;
         SpriteToFade.color = c;
      }
   }
}
