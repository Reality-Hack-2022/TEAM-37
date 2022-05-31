//
// Draw an angle "arc" around a body part, with a target angle indicator
// As the angle of the limb changes, the visualization updates and has a special state when you are close to the target angle
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BodyAngleViz : MonoBehaviour
{
   [Header("Viz Config")]
   [Tooltip("Update arcs + lines every frame, for convenience when debugging")]
   public bool AlwaysUpdateLines = true;
   [Tooltip("The 'anchor' on the body where we center the visuals - like at the knee or elbow joint")]
   public Transform BodyAnchor;

   [Space(10)]

   [Tooltip("The radius of the circle the arc is tracing")]
   public float ArcRadius = 1.0f;
   [Tooltip("The arc aligns with the forward direction of this transform")]
   public Transform ArcDirection;
   [Tooltip("How many points is the arc made up of?")]
   public int ArcDetail = 20;
   [Tooltip("Populate this line renderer with the arc")]
   public LineRenderer ArcLineRnd;

   [Space(10)]

   [Tooltip("The length of the target angle indicator as multiplier on radius of arc")]
   public float TargetAngleLineRadiusMult = 1.25f;
   [Tooltip("Populate this line renderer with the target angle")]
   public LineRenderer TargetAngleLineRnd;

   [Header("Success Feedback")]
   public bool EnableSuccessFeedback = true;
   [Tooltip("Angle difference between CurAngle and TargetAngle in order to show success colors")]
   public float SuccessAngleThresh = 10.0f;
   public Material SuccessArcLineMat;
   public Material SuccessTargetLineMat;


   /*[Space(10)]

   [Tooltip("Text to display current angle")]
   public TextMeshPro CurAngleText;
   [Tooltip("A multiplier on the current radius used to position angle on the inside or outside of the arc")]
   public float AngleTextPosRadiusMult = 1.25f;*/

   [Header("Testing")]
   [Tooltip("Current angle to display on the arc, in degrees")]
   public float CurAngle = 0.0f;
   [Tooltip("The target angle to display, in degrees")]
   public float CurTargetAngle = 45.0f;


   private float _lastRadius = -1.0f;
   private float _lastCurAngle = -1000000.0f;
   private float _lastTargetAngle = -100000.0f;

   Material _origArcLineMat;
   Material _origTargetLineMat;

   void Start()
   {
      if (ArcLineRnd)
         _origArcLineMat = ArcLineRnd.sharedMaterial;
      if (TargetAngleLineRnd)
         _origTargetLineMat = TargetAngleLineRnd.sharedMaterial;
   }

   void Update()
   {
      bool radiusChanged = false;
      if(!Mathf.Approximately(_lastRadius, ArcRadius))
      {
         _lastRadius = ArcRadius;
         radiusChanged = true;
      }

      //refresh arc points if angle changes
      if (!Mathf.Approximately(_lastCurAngle, CurAngle) || radiusChanged || AlwaysUpdateLines)
      {
         _RefreshArc();
         _lastCurAngle = CurAngle;
      }

      //refresh target angle indicator if target angle changes
      if(!Mathf.Approximately(_lastTargetAngle, CurTargetAngle) || radiusChanged || AlwaysUpdateLines)
      {
         _RefreshTargetAngle();
         _lastTargetAngle = CurTargetAngle;
      }

      if(EnableSuccessFeedback)
         _RefreshSuccessFeedback();

   }

   //angle expected in RADIANS...
   Vector3 _GetLocalXYForAngle(float angle, float radiusMult = 1.0f)
   {
      float x = radiusMult * ArcRadius * Mathf.Cos(angle);
      float y = radiusMult * ArcRadius * Mathf.Sin(angle);
      return new Vector2(x, y);
   }

   //convert local XY on circle to worldspace pt
   //centered at BodyAnchor and pointing in direction of ArcDirection
   Vector3 _LocalXYToWorld(Vector2 localXY)
   {
      Vector3 circleCenter = BodyAnchor.position;

      Vector3 horizTangent = ArcDirection.forward;
      Vector3 vertTangent = ArcDirection.up;

      Vector3 result = circleCenter;
      
      result += localXY.x * horizTangent;
      result += localXY.y * vertTangent;

      return result;
   }

   void _RefreshSuccessFeedback()
   {
      if (!EnableSuccessFeedback)
         return;

      float angleDiff = Mathf.Abs(CurTargetAngle - CurAngle);
      bool isSuccess = (angleDiff <= SuccessAngleThresh);

      if (ArcLineRnd)
         ArcLineRnd.sharedMaterial = isSuccess ? SuccessArcLineMat : _origArcLineMat;
      if (TargetAngleLineRnd)
         TargetAngleLineRnd.sharedMaterial = isSuccess ? SuccessTargetLineMat : _origTargetLineMat;
   }


   void _RefreshArc()
   {
      if (!ArcLineRnd)
         return;

      ArcLineRnd.useWorldSpace = true;
      ArcLineRnd.positionCount = ArcDetail;

      float theta = 0.0f;
      for (int i = 0; i < ArcDetail; i++)
      {
         float u = ((float)i / (ArcDetail - 1));
         theta = u * CurAngle * Mathf.Deg2Rad;

         Vector2 localPt = _GetLocalXYForAngle(theta);
         Vector3 pt = _LocalXYToWorld(localPt);

         ArcLineRnd.SetPosition(i, pt);
      }

      //update angle text
      /*if (CurAngleText)
      {
         //text
         CurAngleText.text = Mathf.RoundToInt(CurAngle).ToString();

         //position at mid-point of arc
      }*/
   }

   void _RefreshTargetAngle()
   {
      if (!TargetAngleLineRnd)
         return;

      TargetAngleLineRnd.useWorldSpace = true;
      TargetAngleLineRnd.positionCount = 2;

      //first point at body anchor
      TargetAngleLineRnd.SetPosition(0, BodyAnchor.position);

      //second point at target angle
      Vector2 localPt = _GetLocalXYForAngle(CurTargetAngle*Mathf.Deg2Rad, TargetAngleLineRadiusMult);
      Vector3 worldPt = _LocalXYToWorld(localPt);
      TargetAngleLineRnd.SetPosition(1, worldPt);
   }
}
