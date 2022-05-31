//
// A cue that can be spawned into a lane
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFLanesCue : MonoBehaviour 
{
   [Header("Sustain")]
   [Tooltip("How much scale is needed to make the cue one world unit in length?")]
   public float ScalePerUnit = 1.0f;
   [Tooltip("Scale this transform to stretch the cue for a sustain")]
   public Transform ScaleForSustain;
   public Axis ScaleAxis = Axis.Z;

   [Space(10)]

   public GameObject GemMesh;

   [Space(10)]

   public Renderer SustainingRnd;
   public string SustainingColorProp = "";
   public Color SustainPreArriveColor = Color.cyan;
   public Color IsSustainSuccessColor = Color.green;
   public Color IsSustainFailureColor = Color.red;

   public enum Axis
   {
      X,
      Y,
      Z
   }

   float _cueSpawnBeat = -1.0f;
   float _cueArriveBeat = -1.0f;
   float _cueEndBeat = -1.0f;
   bool _isSustain = false;
   SFLanesLane _myLane = null;

   bool _isSustainSuccess = false;

   //is the player successfully sustaining this cue?
   public void SetIsSustainSuccess(bool b)
   {
      _isSustainSuccess = b;

      //hide gem if you start sustain near start of cue (sorta like "smashing it")
      float kSlopMs = 200.0f;
      float curSecs = OtherSongMgr.I.GetCurrentSong().GetCurContentTime();
      float arriveSecs = GetArriveSecs();

      float errorSecs = Mathf.Abs(curSecs - arriveSecs);
      bool isWithinSlop = errorSecs <= (kSlopMs * .001f);
      if (b && isWithinSlop && GemMesh)
         GemMesh.SetActive(false);

      _RefreshSustainColor();
   }

   public SFLanesLane GetLane()
   {
      return _myLane;
   }

   public bool GetIsSustain()
   {
      return _isSustain;
   }

   public float GetSpawnBeat()
   {
      return _cueSpawnBeat;
   }

   public float GetSpawnSecs()
   {
      return SFSongMgr.I.GetCurrentSong().BeatsToSecs(GetSpawnBeat());
   }

   public float GetArriveBeat()
   {
      return _cueArriveBeat;
   }

   public float GetArriveSecs()
   {
      return SFSongMgr.I.GetCurrentSong().BeatsToSecs(GetArriveBeat());
   }

   public float GetEndBeat()
   {
      return _cueEndBeat;
   }

   public float GetEndSecs()
   {
      return SFSongMgr.I.GetCurrentSong().BeatsToSecs(GetEndBeat());
   }

   public void Init(SFLanesLane lane, float cueSpawnBeat, float cueArriveBeat, float cueEndBeat)
   {
      _myLane = lane;

      _cueSpawnBeat = cueSpawnBeat;
      _cueArriveBeat = cueArriveBeat;
      _cueEndBeat = cueEndBeat;
      
      float numOutroBeats = (GetEndBeat() - GetArriveBeat());

      //see if we're a sustain cue
      const float kSustainFudge = .1f; //to account for sloppy authoring...
      _isSustain = numOutroBeats >= (SFLanesCueingMgr.I.CueSustainMinBeats - kSustainFudge);

      //after determining if its a real sustain, extend outro to hit minimum configured (so things pass by player fully)
      if (numOutroBeats < SFLanesCueingMgr.I.CueMinOutroBeats)
         _cueEndBeat = _cueEndBeat + SFLanesCueingMgr.I.CueMinOutroBeats;

      if (_isSustain)
      {
         _StretchForSustain();
         _RefreshSustainColor();
      }

      if (GemMesh)
         GemMesh.SetActive(true);
   }

   void _StretchForSustain()
   {
      if (!_isSustain || !ScaleForSustain)
         return;

      //figure out how much distance we will cover during the sustain
      float cueSpeed = SFLanesCueingMgr.I.CueTravelSpeed;
      float sustainSecs = GetEndSecs() - GetArriveSecs();
      float travelDist = cueSpeed * sustainSecs;

      //convert distance to scale using ScalePerUnit param
      float scaleAmt = travelDist * ScalePerUnit;

      //apply scale!
      Vector3 curScale = ScaleForSustain.localScale;
      switch(ScaleAxis)
      {
         case Axis.X: curScale.x = scaleAmt; break;
         case Axis.Y: curScale.y = scaleAmt; break;
         case Axis.Z: curScale.z = scaleAmt; break;
         default: break;
      }
      ScaleForSustain.localScale = curScale;
   }

   void _RefreshSustainColor()
   {
      float curBeat = SFSongMgr.I.GetCurrentSong() ? SFSongMgr.I.GetCurrentSong().GetCurBeat() : 0.0f;

      bool isPreArrive = (curBeat < GetArriveBeat());

      if (isPreArrive)
         _SetSustainingColor(SustainPreArriveColor);
      else
         _SetSustainingColor(_isSustainSuccess ? IsSustainSuccessColor : IsSustainFailureColor);
   }

   void _SetSustainingColor(Color c)
   {
      if (SustainingRnd && (SustainingColorProp.Length > 0))
         SustainingRnd.material.SetColor(SustainingColorProp, c);
   }
}
