//
// Data saved for an annotation of volumetric data
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnnotationData 
{
   public static AnnotationData CreateData()
   {
      AnnotationData data = new AnnotationData();

      List<AnnotationChannel> channels = new List<AnnotationChannel>();
      channels.Add(new AnnotationChannel(AnnotationChannelType.Head));
      channels.Add(new AnnotationChannel(AnnotationChannelType.LeftHand));
      channels.Add(new AnnotationChannel(AnnotationChannelType.RightHand));
      channels.Add(new AnnotationChannel(AnnotationChannelType.LeftFoot));
      channels.Add(new AnnotationChannel(AnnotationChannelType.RightFoot));
      channels.Add(new AnnotationChannel(AnnotationChannelType.Hips));

      data.Channels = channels.ToArray();

      return data;
   }

   public static AnnotationData CreateData(List<AnnotationChannelType> types)
   {
      AnnotationData data = new AnnotationData();

      List<AnnotationChannel> channels = new List<AnnotationChannel>();
      foreach (var t in types)
         channels.Add(new AnnotationChannel(t));

      data.Channels = channels.ToArray();

      return data;
   }

   public AnnotationChannel[] Channels = new AnnotationChannel[0];
}

[System.Serializable]
public class AnnotationChannel
{
   public AnnotationChannel(AnnotationChannelType t) { ChannelType = t; }
   public AnnotationChannelType ChannelType = AnnotationChannelType.Head;

   public AnnotationChannel[] Samples = new AnnotationChannel[0];
}

public class AnnotationSample
{
   public float Time = 0.0f;
   public Vector3 Pos = Vector3.zero;
}

public enum AnnotationChannelType
{
   Head,
   LeftHand,
   RightHand,
   LeftFoot,
   RightFoot,
   Hips
}
