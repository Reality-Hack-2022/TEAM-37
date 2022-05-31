using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SongPlayedEvent : UnityEvent<Song>
{
}

public class OtherSongMgr : MonoBehaviour
{
   public AudioSource source;
   public Song[] SongList = new Song[0];

   [Header("Debug")]
   public bool EnablePlayTestSongAtStart = false;
   public int TestSongIdxToPlayAtStart = 0;
   [Space(10)]
   [InspectorButton("_OnDebugTogglePause")]
   public bool TogglePause;
   [InspectorButton("_OnDebugRestart")]
   public bool TriggerRestartSong;

   //events
   public SongPlayedEvent OnSongPrepared = new SongPlayedEvent();
   public SongPlayedEvent OnSongPlayed = new SongPlayedEvent();
   public SongPlayedEvent OnSongStopped = new SongPlayedEvent();

   Song _curSong = null;

   Song _prevMainSong = null;  //set while in bonus room, to be restored
   float _mainSongResumeTime = -1.0f;

   public static OtherSongMgr I { get; private set; }

   public static void Global_RestartSong()
   {
      if (OtherSongMgr.I)
         OtherSongMgr.I.RestartSong();
   }

   public static void Global_StopSong()
   {
      if (OtherSongMgr.I)
         OtherSongMgr.I.StopSong();
   }

   public static void Global_PrepareSong(Song s)
   {
      if (OtherSongMgr.I)
         OtherSongMgr.I.PrepareSong(s);
   }


   public static void Global_PlaySong()
   {
      if (OtherSongMgr.I)
         OtherSongMgr.I.PlaySong();
   }

   public static bool Global_IsSongPlaying()
   {
      return OtherSongMgr.I && (OtherSongMgr.I._curSong != null) && (OtherSongMgr.I._curSong.IsPlaying());
   }

   //call this to switch to another song for bonus rooms, then call Global_ResumeMainSong to return to the current song
   public static void Global_TriggerBonusRoomSong(Song s)
   {
      if (OtherSongMgr.I)
         OtherSongMgr.I.TriggerBonusRoomSong(s);
   }

   public static void Global_ResumeMainSong(bool restartMainSong)
   {
      if (OtherSongMgr.I)
         OtherSongMgr.I.ResumeMainSong(restartMainSong);
   }

   public static void Global_SetSongPaused(bool paused)
   {
      if (OtherSongMgr.I)
         OtherSongMgr.I.SetSongPaused(paused);
   }

   public static Song Global_GetCurrentSong()
   {
      if (OtherSongMgr.I)
         return OtherSongMgr.I.GetCurrentSong();
      return null;
   }


   public Song GetCurrentSong()
   {
      return _curSong;
   }

   void Awake()
   {
      I = this;
   }

   void Start()
   {
      if (EnablePlayTestSongAtStart)
      {
         PrepareSong(GetSong(TestSongIdxToPlayAtStart));
         PlaySong();
      }
   }

   void Update()
   {
      /*if(Input.GetKeyDown(KeyCode.M))
      {
         if (_curSong)
            _curSong.SetMuted(!_curSong.IsMuted());
      }*/
   }

   public Song GetSong(int idx)
   {
      return ((idx >= 0) && (idx < SongList.Length)) ? SongList[idx] : null;
   }

   //load the song, but dont play it yet
   public void PrepareSong(Song s)
   {
      if (!s)
         return;

      GameObject songObj = Instantiate(s.gameObject) as GameObject; //assuming song is a prefab that needs to be spawned, so it can update
      songObj.transform.SetParent(this.transform);
      _curSong = songObj.GetComponent<Song>();
      _curSong.Prepare();

      OnSongPrepared.Invoke(_curSong);
   }

   public void TriggerBonusRoomSong(Song s)
   {
      if(_curSong == null)
      {
         Debug.LogWarning("Can't trigger bonus room song because there isnt a main one playing!");
         //return;
      }

      if(_curSong == s)
      {
         Debug.LogWarning("Ignoring TriggerBonusRoomSong because that song is already playing...");
         return;
      }

      if(s == null)
      {
         Debug.LogWarning("Ignoring TriggerBonusRoomSong because that song passed was null...");
         return;
      }

      _mainSongResumeTime = source.time;
      _prevMainSong = _curSong;

      source.time = 0;
      PrepareSong(s);
      PlaySong();
   }

   public void ResumeMainSong(bool restartMainSong)
   {
      if(!_prevMainSong)
      {
         Debug.LogWarning("Can't resume main song since we dont have one captured.  this is a bug!");
         return;
      }

      _curSong = _prevMainSong;
      _prevMainSong = null;
      if (restartMainSong)
      {
         RestartSong();
      }
      else //resume
      {
         PlaySong();
         source.time = _mainSongResumeTime;
      }
   }

   public void PlaySong()
   {
      if (!_curSong)
      {
         Debug.LogWarning("Can't play song because PrepareSong was not called yet");
         return;
      }

      _curSong.Play(source);

      OnSongPlayed.Invoke(_curSong);
   }

   public void SetSongPaused(bool pause)
   {
      if (!_curSong)
      {
         Debug.LogWarning("Can't pause song because PrepareSong was not called yet");
         return;
      }

      if (pause)
         _curSong.Pause();
      else
         _curSong.Resume();
   }

   public void RestartSong()
   {
      if (!_curSong)
      {
         Debug.LogWarning("Can't restart song because PrepareSong was not called yet");
         return;
      }

      _curSong.Stop();
      _curSong.Play(source);

      OnSongPlayed.Invoke(_curSong);
   }

   public void StopSong()
   {
      if (!_curSong || !_curSong.IsPlaying())
      {
         Debug.LogWarning("Can't play song because PrepareSong was not called yet");
         return;
      }

      _curSong.Stop();

      OnSongStopped.Invoke(_curSong);

      Destroy(_curSong.gameObject);
      _curSong = null;
   }

   void _OnDebugRestart()
   {
      RestartSong();
   }

   bool _isDebugPaused = false;
   void _OnDebugTogglePause()
   {
      _isDebugPaused = !_isDebugPaused;
      SetSongPaused(_isDebugPaused);
   }
}
