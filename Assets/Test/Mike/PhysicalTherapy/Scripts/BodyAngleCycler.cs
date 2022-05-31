//
// Cycle the CurAngle of the body angle viz through a particular range over and over... for demo
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BodyAngleViz))]
public class BodyAngleCycler : MonoBehaviour
{
   public float MinAngle = 90.0f;
   public float MaxAngle = 180.0f;
   public float CycleTime = 4.0f;

   [Space(10)]

   public bool AddNoise = false;
   public float NoiseMult = .1f;

   BodyAngleViz _bodyAngle = null;

   void Awake()
   {
      _bodyAngle = GetComponent<BodyAngleViz>();
   }

   void Update()
   {
      float curTime = Time.time;

      float cycleU = (curTime % CycleTime) / CycleTime;

      if(cycleU <= .5f) //MinAngle -> MaxAngle
      {
         float u = Mathf.InverseLerp(0.0f, .5f, cycleU);
         u = Easing.SineEaseOut(u, 0.0f, 1.0f, 1.0f);
         float angle = Mathf.Lerp(MinAngle, MaxAngle, u);
         _bodyAngle.CurAngle = _ApplyNoise(angle);
      }
      else //MaxAngle -> MinAngle
      {
         float u = Mathf.InverseLerp(0.5f, 1.0f, cycleU);
         u = Easing.SineEaseOut(u, 0.0f, 1.0f, 1.0f);
         float angle = Mathf.Lerp(MaxAngle, MinAngle, u);
         _bodyAngle.CurAngle = _ApplyNoise(angle);
      }
   }

   float _ApplyNoise(float val)
   {
      if (!AddNoise)
         return val;

      return val + (NoiseMult * Mathf.PerlinNoise(Time.time, 0.0f)); 
   }
}
