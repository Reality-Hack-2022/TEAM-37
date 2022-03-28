//
// put UI at head height
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUIHeight : MonoBehaviour
{
   void Start()
   {
      if(CamMgr.I)
      {
         CamMgr.I.OnVRRecenter.AddListener(_OnRecentered);
      }

      _RefreshUIHeight();
   }

   void _OnRecentered()
   {
      _RefreshUIHeight();
   }

   void _RefreshUIHeight()
   {
      Vector3 curPos = transform.position;
      curPos.y = VRInputMgr.GetHeadPos().y;
      transform.position = curPos;
   }
}
