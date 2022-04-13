using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum UIPanel
{
   None,
   Learn,
   Play,
   Back,
   Home,
   Next,
   PauseToggle,
   SlowToggle
}

[System.Serializable]
public class UIMgrSelectedEvent : UnityEvent<UIItem> { }

public class UIMgr : MonoBehaviour
{
   public bool EnableLaserPointer = true;
   public LayerMask UILayer;
   public UILaserPointer LaserPointer;

   //events
   public UIMgrSelectedEvent OnUIItemSelected = new UIMgrSelectedEvent();

   public static UIMgr I { get; private set; }

   Vector3 _lastHitPos = Vector3.zero;
   UIItem _lastHitItem = null;

   List<UIItem> _allItems = new List<UIItem>();

   public void RegisterItem(UIItem item)
   {
      if (!_allItems.Contains(item))
         _allItems.Add(item);
   }

   void Awake()
   {
      I = this;
   }

   void Start()
   {

   }

   public bool GetIsPointingAtUIItem()
   {
      return _lastHitItem != null;
   }

   public Vector3 GetLastUIItemHitPos()
   {
      return _lastHitPos;
   }

   void _RefreshEnableLaser()
   {
      if (CamMgr.I && (CamMgr.I.CamType == CamMgr.CamMode.Oculus))
      {
         bool handsEnabled = OVRPlugin.GetHandTrackingEnabled(); //only want laser point if holding controllers
         //enable laser pointer in VR
         LaserPointer.EnableLaser(!handsEnabled && EnableLaserPointer);
      }
      else
      {
         LaserPointer.EnableLaser(false);
      }
   }

   public void TriggerItemSelected(UIItem item)
   {
      OnUIItemSelected.Invoke(item);
   }

   void Update()
   {
      _lastHitItem = null;

      _RefreshEnableLaser();
      if (!LaserPointer.GetLaserEnabled())
         return;

      //raycast to see if we are pointing at a ui item
      Vector3 rayPos = LaserPointer.GetLaserBasePos();
      Vector3 rayDir = LaserPointer.GetLaserDir();
      RaycastHit hit;
      const float kRayLen = 100.0f;
      if(Physics.Raycast(new Ray(rayPos, rayDir), out hit, kRayLen, UILayer, QueryTriggerInteraction.UseGlobal))
      {
         UIItem item = hit.collider.GetComponent<UIItem>();
         if (!item)
            item = hit.collider.GetComponentInParent<UIItem>();

         if(item)
         {
            _lastHitItem = item;
            _lastHitPos = hit.point;
         }
      }

      //so highlight doesnt get stuck on
      foreach (var item in _allItems)
         item.NotifyHighlighted(false);

      //if pointing at a UI item, see if the player presses the trigger to "click" it
      if (_lastHitItem)
      {
         _lastHitItem.NotifyHighlighted(true);
         if (VRInputMgr.GetTriggerDown(LaserPointer.GetActiveHand()))
         {
            TriggerItemSelected(_lastHitItem);
         }
      }

   }
}
