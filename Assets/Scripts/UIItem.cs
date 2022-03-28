//
// A selectable UI item (see UIMgr for more...)
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItem : MonoBehaviour
{
   public float HighlightScale = 1.25f;
   public UIPanel PanelType = UIPanel.None;

   Vector3 _initialLocalScale = Vector3.one;

   void Start()
   {
      if (UIMgr.I)
         UIMgr.I.RegisterItem(this);
      _initialLocalScale = this.transform.localScale;
   }

   public void NotifyHighlighted(bool b)
   {
      if (b)
         this.transform.localScale = new Vector3(HighlightScale, HighlightScale, HighlightScale);
      else
         this.transform.localScale = _initialLocalScale;
   }
}
