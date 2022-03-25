using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
   public GameObject PrefabToSpawn;
   public KeyCode SpawnKey;

   void Update()
   {
      if(Input.GetKeyDown(SpawnKey))
      {
         var go = Instantiate(PrefabToSpawn, this.transform);
         go.transform.localPosition = Vector3.zero;
         go.transform.localRotation = Quaternion.identity;
      }
   }
}
