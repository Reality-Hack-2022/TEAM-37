//
// an individual annotation shown in the tool
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnnotationVizObject : MonoBehaviour
{
   public TextMeshPro LabelText;

   public void InitUI(AnnotationChannelType t)
   {
      if (LabelText)
         LabelText.text = t.ToString();
   }
}
