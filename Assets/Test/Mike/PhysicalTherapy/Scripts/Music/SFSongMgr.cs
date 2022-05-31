//
// Exposes relevant song data over time (like song section)
// Also provides easy access to other gameplay data from midi file for other systems to consume
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

[System.Serializable]
public class SFSongMgrSectionEvent : UnityEvent<SFSectionEvent, SFSection> { } //section event (timed), section (name)

[RequireComponent(typeof(SFMidiParser))]
public class SFSongMgr : MonoBehaviour 
{
   [Header("Debug")]
   public bool DisplayCurrentSection = true;

	[Header("Output")]
	[ReadOnly]
	public string CurSongSection = "";

	//events
	public UnityEvent OnSongStarted = new UnityEvent();
   public SFSongMgrSectionEvent OnSongSectionChanged = new SFSongMgrSectionEvent();
   public SFSongMgrSectionEvent OnPostSongSectionChanged = new SFSongMgrSectionEvent();

   public static SFSongMgr I { get; private set; }

	SFMidiParser _parser = null;

	SFSongData _songData = null;

   SFSectionEvent _prevSectionEvent = null;
   SFSection _prevSection = null;

   public SFSongData GetSongGameplayData() { return _songData; }

	public Song GetCurrentSong() { return _parser.GetSong(); }

   public SFMidiParser GetParser() { return _parser; }


   public void PlaySong(Song s)
   {
      if(OtherSongMgr.I)
      {
         OtherSongMgr.I.PrepareSong(s);
         OtherSongMgr.I.PlaySong();
      }
   }

	void Awake()
   {
		I = this;

		_parser = GetComponent<SFMidiParser>();
		_parser.OnDataParsed.AddListener(_OnSongReady);
   }

   void Start()
   {

   }

	void _OnSongReady(SFSongData data)
   {
      _prevSectionEvent  = null;
      _prevSection = null;

      _songData = data;
		OnSongStarted.Invoke();
	}

   SFSectionEvent _FindSectionAtTime(float curTime)
   {
      if (_songData == null)
         return null;

      return _songData.GetSectionEventAtTime(curTime);
   }


   void _UpdateSongSection()
   {
      if (_songData == null)
         return;

      float curTime = GetCurrentSong().GetCurContentTime();

      int prevSectionIdx = (_prevSectionEvent != null) ? _prevSectionEvent.SectionIdx : -1;
      SFSectionEvent curSection = _prevSectionEvent;
      //if ((curSection == null) || (curTime >= curSection.EndSecs))
      curSection = _FindSectionAtTime(curTime);

      if ((curSection != null) && (curSection.SectionIdx != prevSectionIdx)) //new section?
      {
         var section = _songData.SectionData.GetSectionByIdx(curSection.SectionIdx);
         CurSongSection = section.SectionName;

         _prevSection = section;

         //Debug.Log("NEW SECTION: " + section.SectionName + " at " + Time.time);

         OnSongSectionChanged.Invoke(curSection, section);
         //a second event for things that want to post process the result of a section change...
         OnPostSongSectionChanged.Invoke(curSection, section);
      }

      _prevSectionEvent = curSection;
   }

   void Update()
	{
		if (!GetCurrentSong())
			return;

		_UpdateSongSection();
	}

   void OnGUI()
   {
      if ((_prevSection == null)|| !DisplayCurrentSection)
         return;

      string sectionStr = "Section: " + _prevSection.SectionName;
      GUI.Label(new Rect(15.0f, Screen.height - 45.0f, Screen.width, 25.0f), sectionStr);
   }

}
