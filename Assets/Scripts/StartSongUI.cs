using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;
using TMPro;

public class StartSongUI : MonoBehaviour
{
   public bool TriggerUIOnEnable = true;
   public bool StartSongOnComplete = true;
   public GameObject VisualsParent;
   public InteractableUnityEventWrapper OVRInteractor = null;
   public PokeInteractable OVRPokeInteractor = null;

   [Space(10)]

   public GameObject SongPoster;
   public bool EnableForcePosterYValue = false;
   public float ForcePosterYValue = 1.0f;

   [Space(10)]

   public TextMeshPro TitleText;
   public string TitleLearn = "Learning Dance:";
   public string TitlePerform = "Performing Dance:";

   //events
   public UnityEvent OnSongStarted = new UnityEvent();

   public void TriggerUI()
   {
      _ShowVisuals(true);
      if (OVRPokeInteractor)
         OVRPokeInteractor.Enable();
      if (StartSongOnComplete && SongMgr.I)
         SongMgr.I.Stop();

      if(TitleText)
      {
         bool isPerform = ProgressionMgr.instance.volumetricPlayer.CurStep == -1;
         TitleText.text = isPerform ? TitlePerform : TitleLearn;
      }
   }

   void OnEnable()
   {
      if (TriggerUIOnEnable)
         TriggerUI();
      else
         _ShowVisuals(false);
   }

   void Awake()
   {
      if (OVRInteractor)
      {
         OVRInteractor.WhenSelect.AddListener(_OnStartSongPressed);
      }
   }

   void _OnStartSongPressed()
   {
      if (StartSongOnComplete && SongMgr.I)
         SongMgr.I.Play();

      if (OVRPokeInteractor)
         OVRPokeInteractor.Disable();

      _ShowVisuals(false);

      OnSongStarted.Invoke();
   }

   void _ShowVisuals(bool b)
   {
      if (VisualsParent)
         VisualsParent.SetActive(b);

      if (b)
      {
         if (SongPoster && EnableForcePosterYValue)
         {
            Vector3 pos = SongPoster.transform.position;
            pos.y = ForcePosterYValue;
            SongPoster.transform.position = pos;
         }
      }
   }
}
