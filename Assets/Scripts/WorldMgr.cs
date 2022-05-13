//
// The world geometry a level sits within
// Assuming one of these exists in a scene (or is spawned in?), and all world geometry game objects are children...
// Used by clients to transition in/put the world (or turn it off for things like SNPassthruMgr's room mapping phase)
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldMgrShowingEvent : UnityEvent<bool> { }//showing

public class WorldMgr : MonoBehaviour
{

   //events
   public WorldMgrShowingEvent OnWorldShowChanged = new WorldMgrShowingEvent();

   bool _worldShowing = true;

   public static WorldMgr I { get; private set; }

   public static WorldMgr Find()
   {
      if (WorldMgr.I)
         return WorldMgr.I;

      WorldMgr w = GameObject.FindObjectOfType<WorldMgr>();
      return w;
   }

   public bool GetIsWorldShowing() { return _worldShowing; }

   public void ShowWorld(bool b, bool force = false)
   {
      if (!force && (b == _worldShowing))
         return;

      _worldShowing = b;

      gameObject.SetActive(b);
      /*for(int i = 0; i < transform.childCount; i++)
      {
         transform.GetChild(i).gameObject.SetActive(b);
      }*/

      OnWorldShowChanged.Invoke(_worldShowing);
   }

   void OnEnable()
   {
      ShowWorld(true);
   }

   void OnDisable()
   {
      ShowWorld(false);
   }

   void Awake()
   {
      I = this;
   }
}
