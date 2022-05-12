//
// UI around the volumetric actor, giving timing cues, especially during "practice"
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(VolumetricPlayer))]
public class VolumetricPlayerUI : MonoBehaviour
{
   //show progress thru the current loop using a shader that takes a "progress" param
   [Header("Loop Progress")]
   public ShowWhen ShowLoopProgressWhen = ShowWhen.PracticingStep;
   //public bool LoopProgressInBeatChunks = true; //instead of advancing progress smoothly, jump it in chunks every beat
   public GameObject LoopProgressParent = null;
   public Renderer LoopProgressRnd;
   public string LoopProgressShaderProp = "";
   public TextMeshPro LoopProgressCountText = null;

   //show a count-in when a scheduled loop is about to play
   [Header("Scheduled Count-in")]
   public GameObject ScheduledCountInParent = null;
   public TextMeshPro ScheduledCountInText = null;


   public enum ShowWhen
   {
      PracticingStep,
      FullPlayback
   }

   VolumetricPlayer _player = null;

   void Start()
   {
      _player = GetComponent<VolumetricPlayer>();

      if (LoopProgressParent)
         LoopProgressParent.SetActive(false);
      if (ScheduledCountInParent)
         ScheduledCountInParent.SetActive(false);
   }

   void Update()
   {

      //deal with showing progress thru loop
      if(LoopProgressParent)
      {
         bool shouldShow = (ShowLoopProgressWhen == ShowWhen.PracticingStep) ? (_player.CurStep != -1) : true;
         //hide loop progress when waiting for a scheduled loop to start
         if (shouldShow && ((_player.GetScheduledState() == VolumetricPlayer.ScheduledLoopState.Waiting) || (_player.GetScheduledState() == VolumetricPlayer.ScheduledLoopState.Preroll)))
            shouldShow = false;
         if (_player.GetPlaybackState() != VolumetricPlayer.PlaybackState.Playing)
            shouldShow = false;
         LoopProgressParent.SetActive(shouldShow);

         if(shouldShow)
         {
            //feed shader progress value to display
            float progress = _player.GetLoopProgress();
            if (LoopProgressRnd && (LoopProgressShaderProp.Length > 0))
               LoopProgressRnd.material.SetFloat(LoopProgressShaderProp, progress);

            //show which beat # we are on of the loop
            if(LoopProgressCountText)
            {
               float totalBeats = _player.NumLoopBeats;
               if (_player.CurStep != -1)
                  totalBeats = _player.Steps[_player.CurStep].NumLoopBeats;

               float curBeat = progress * totalBeats;
               int beatToShow = Mathf.CeilToInt(curBeat);
               LoopProgressCountText.text = beatToShow.ToString();
            }
         }
      }

      //show countdown when scheduled loop is about to start
      if(ScheduledCountInParent && ScheduledCountInText)
      {
         VolumetricPlayer.ScheduledLoop scheduledInfo = _player.GetScheduledLoop();
         bool shouldShow = (scheduledInfo != null) && ((_player.GetScheduledState() == VolumetricPlayer.ScheduledLoopState.Waiting) || (_player.GetScheduledState() == VolumetricPlayer.ScheduledLoopState.Preroll));
         ScheduledCountInParent.SetActive(shouldShow);

         if(shouldShow)
         {
            float curBeat = SongMgr.I.CurBeat;
            float startBeat = scheduledInfo.StartBeat;
            float beatsTillStart = (startBeat - curBeat);
            int beatToShow = Mathf.CeilToInt(beatsTillStart);
            //if ((curBeat - scheduledInfo.ScheduleBeat) < 1.0f) //dont show first countin beat, to give a little space
            if((scheduledInfo.StartBeat - curBeat) > 3.0f) //only show countdown the last 3 beats
               ScheduledCountInText.text = "";
            else
               ScheduledCountInText.text = beatToShow.ToString();
         }
      }
   }
}
