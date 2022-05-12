using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrentStep : MonoBehaviour
{
   public TextMeshPro Text;

   int _curDisplayStep = -1;

   void Start()
   {
      if (Text)
         Text.gameObject.SetActive(false);
   }

   void _SetDisplayStep(int s)
   {
      if (s == _curDisplayStep)
         return;

      bool showText = (s >= 0);

      if (Text)
      {
         Text.gameObject.SetActive(showText);
         if(showText)
            Text.text = "Step " + (s + 1).ToString() + " of " + ProgressionMgr.instance.volumetricPlayer.Steps.Length;
      }
   }

   void Update()
   {
      if (!ProgressionMgr.instance)
         return;

      var vol = ProgressionMgr.instance.volumetricPlayer;
      int step = (vol.GetPlaybackState() == VolumetricPlayer.PlaybackState.Playing) ? vol.ComputedStep : vol.CurStep;
      _SetDisplayStep(step);
   }
}
