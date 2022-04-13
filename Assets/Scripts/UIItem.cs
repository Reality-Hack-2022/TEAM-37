//
// A selectable UI item (see UIMgr for more...)
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Oculus.Interaction;

public class UIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public float HighlightScale = 1.25f;
   public UIPanel PanelType = UIPanel.None;

   [Space(10)]

   public Button TriggerButton;

   Vector3 _initialLocalScale = Vector3.one;
   InteractableUnityEventWrapper _ovrInteractor = null; //if we're on an Oculus Interaction System widget

   void Start()
   {
      //hook into oculus interaction events
      _ovrInteractor = GetComponent<InteractableUnityEventWrapper>();
      if(_ovrInteractor)
      {
         _ovrInteractor.WhenSelect.AddListener(_OnOVRSelected);
      }

      if (UIMgr.I)
         UIMgr.I.RegisterItem(this);
      _initialLocalScale = this.transform.localScale;

      if(TriggerButton)
      {
         TriggerButton.onClick.AddListener(_OnButtonPressed);
 
      }
   }

   void _OnOVRSelected()
   {
      UIMgr.I.TriggerItemSelected(this);
   }

   void _OnButtonPressed()
   {
      UIMgr.I.TriggerItemSelected(this);
   }

   public void OnPointerEnter(PointerEventData eventData)
   {
      if (TriggerButton && !TriggerButton.interactable)
         return;
      NotifyHighlighted(true);
   }

   public void OnPointerExit(PointerEventData eventData)
   {
      NotifyHighlighted(false);
   }

   public void NotifyHighlighted(bool b)
   {
      if (b)
         this.transform.localScale = new Vector3(_initialLocalScale.x*HighlightScale, _initialLocalScale.y * HighlightScale, _initialLocalScale.z * HighlightScale);
      else
         this.transform.localScale = _initialLocalScale;
   }
}
