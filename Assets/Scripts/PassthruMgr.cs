//
// Manage video-passthru "mixed reality" features
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement.XRTools;

public class PassthruMgr : MonoBehaviour
{
   [Header("Config")]
   public bool StartInPassthru = true;
   public RoomMapper RoomMapperMgr;
   public bool EnableToggleCheat = true;
   public KeyCode ToggleCheat = KeyCode.P;
   public KeyCode RestartRoomMappingCheat = KeyCode.P;
   public bool RestartRoomMappingCtrlModifier = true;

   [Header("Testing")]
   [InspectorButton("_DebugTogglePassthru", ButtonWidth = 150)]
   public bool TogglePassthru;


   private bool _passthruOn = false;

   bool _roomMapped = false;

   OVRPassthroughLayer _passthru = null;



   public bool GetPassthruOn() { return _passthruOn; }

   public void SetPassthruOn(bool b, bool force = false)
   {
      if (!force && (_passthruOn == b))
         return;

      _passthruOn = b;

      if (CamMgr.I && CamMgr.I.OculusRig)
         CamMgr.I.OculusRig.gameObject.GetComponent<OVRManager>().isInsightPassthroughEnabled = b;

      //enable room mapper
      if (RoomMapperMgr)
         RoomMapperMgr.gameObject.SetActive(b);

      if (!_passthruOn)
         _roomMapped = false;
   }

   public bool GetHasMappedRoom() { return _roomMapped; }

   public bool GetIsMappingRoom() { return WorldMgr.I ? WorldMgr.I.GetIsWorldShowing() : false; }

   public static PassthruMgr I { get; private set; }

   void Awake()
   {
      I = this;

      if (RoomMapperMgr)
      {
         //turn off room mapper until we enable passthru
         if (!StartInPassthru)
            RoomMapperMgr.gameObject.SetActive(false);

         //add our world to the "content" managed by the room mapper, so it can hide us during the "scanning" phase
         var worldMgr = WorldMgr.Find(); //need to use Find() if called in Awake() in case we get called second
         if(worldMgr)
         {
            RoomMapperMgr.contentToActivate = new GameObject[1];
            RoomMapperMgr.contentToActivate[0] = worldMgr.gameObject;
         }
      }
   }

   void Start()
   {
      if (RoomMapperMgr)
      {
         RoomMapperMgr.OnRoomMapped += _OnRoomMapped;
      }

      GameObject ovrCameraRig = CamMgr.I && CamMgr.I.OculusRig ? CamMgr.I.OculusRig.gameObject : GameObject.Find("OVRCameraRig");
      _passthru = ovrCameraRig.GetComponent<OVRPassthroughLayer>();

      //start with reconstructed (i.e full passthru) until room is mapped
      if (_passthru)
         _passthru.projectionSurfaceType = OVRPassthroughLayer.ProjectionSurfaceType.Reconstructed;

      SetPassthruOn(StartInPassthru, true /*force*/);
   }

   void _OnRoomMapped()
   {
      //switch to user defined mode so we can specify projection surfaces
      _passthru.projectionSurfaceType = OVRPassthroughLayer.ProjectionSurfaceType.UserDefined;
      //cycle passthru enabled for projection surface change to "take"
      _passthru.enabled = false;
      _passthru.enabled = true;

      //start with all passthru surfaces on
      _ShowPassthruSurface(RoomMapper.Instance.Floor, true);
      _ShowPassthruSurface(RoomMapper.Instance.Ceiling, true);
      foreach(var wall in RoomMapper.Instance.Walls)
         _ShowPassthruSurface(wall, true);

      _roomMapped = true;
   }

   public void ShowCeiling(bool b)
   {
      _ShowPassthruSurface(RoomMapper.Instance.Ceiling, b);
   }

   void _ShowPassthruSurface(GameObject s, bool b)
   {
      if (!_passthru)
         return;

      if (b)
      {
         if(!_passthru.IsSurfaceGeometry(s))
            _passthru.AddSurfaceGeometry(s, false /*updateTranform*/);
      }
      else
      {
         if (_passthru.IsSurfaceGeometry(s))
            _passthru.RemoveSurfaceGeometry(s);
      }

      // Disable the mesh renderer to avoid rendering the surface within Unity
      MeshRenderer mr = s.GetComponent<MeshRenderer>();
      if (mr)
         mr.enabled = b;
   }

   void _DebugTogglePassthru()
   {
      SetPassthruOn(!GetPassthruOn());
   }

   void _RestartRoomMapping()
   {
      _roomMapped = false;

      if (RoomMapper.Instance)
         RoomMapper.Instance.Restart();
   }
   
   void Update()
   {
      if(EnableToggleCheat && Input.GetKeyDown(ToggleCheat))
         SetPassthruOn(!GetPassthruOn());

      if(Input.GetKeyDown(RestartRoomMappingCheat) && (!RestartRoomMappingCtrlModifier || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) )
      {
         _RestartRoomMapping();
      }
   }
}
