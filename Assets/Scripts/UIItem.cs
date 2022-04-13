//
// A selectable UI item (see UIMgr for more...)
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public float HighlightScale = 1.25f;
   public UIPanel PanelType = UIPanel.None;

   [Space(10)]

   public Button TriggerButton;

   Vector3 _initialLocalScale = Vector3.one;   

   void Start()
   {
      if (UIMgr.I)
         UIMgr.I.RegisterItem(this);
      _initialLocalScale = this.transform.localScale;

      if(TriggerButton)
      {
         TriggerButton.onClick.AddListener(_OnButtonPressed);
 
      }
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
