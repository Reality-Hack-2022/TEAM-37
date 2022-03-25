using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class DriveTextWithBeat : MonoBehaviour
{
   TextMeshPro _text;

   void Awake()
   {
      _text = GetComponent<TextMeshPro>();
   }

   void Update()
   {
      if (SongMgr.I && _text)
      {
         int beatNum = (Mathf.FloorToInt(SongMgr.I.CurBeat) % 4) + 1;
         _text.text = beatNum.ToString();
      }
   }
}
