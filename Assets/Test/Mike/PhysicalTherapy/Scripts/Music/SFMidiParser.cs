//
// When a song is loaded, parse all the gameplay data for Surf into something easily digestible by other systems
//

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;

//midi parsed into this data structure
[System.Serializable]
public class SFSongData
{
   //song sections
   public SFSectionData SectionData = new SFSectionData();

   //gameplay data
   //which "lane" the player needs to be in
   public SFLaneData LaneData = new SFLaneData();
   //actions the player needs to take at different times
   public SFActionData ActionData = new SFActionData();

   public SFSection GetSectionAtTime(float timeSecs)
   {
      var se = GetSectionEventAtTime(timeSecs);
      if(se != null)
         return SectionData.Sections[se.SectionIdx];

      return null;
   }

   public SFSectionEvent GetSectionEventAtTime(float timeSecs)
   {
      foreach (var se in SectionData.Sequence)
      {
         if ((timeSecs >= se.StartSecs) && (timeSecs <= se.EndSecs))
            return se;
      }

      return null;
   }
}





[System.Serializable]
public class SFLaneData
{
   public List<SFLaneEvent> LaneEvents = new List<SFLaneEvent>();
}

[System.Serializable]
public class SFLaneEvent
{
   public float StartSecs = -1.0f;
   public float EndSecs = -1.0f;

   public int LaneIdx = -1;
}

[System.Serializable]
public class SFActionData
{
   public List<SFActionEvent> ActionEvents = new List<SFActionEvent>();
}

[System.Serializable]
public class SFActionEvent
{
   public float StartSecs = -1.0f;
   public float EndSecs = -1.0f;

   public SFGameplayAction Action = SFGameplayAction.None;
}

public enum SFGameplayAction
{
   None,
   Squat
}


[System.Serializable]
public class SFSectionData
{
   public SFSection GetSectionByIdx(int idx)
   {
      return ((idx >= 0) && (idx < Sections.Count)) ? Sections[idx] : null;
   }

   public int SectionNameToIdx(string sectionName)
   {
      foreach (var s in Sections)
      {
         if (s.SectionName.Equals(sectionName))
            return s.SectionIdx;
      }
      return -1;
   }

   public int AddSection(SFSection s)
   {
      //is this a uniquely named section?
      if (Sections.Find(sec => sec.SectionName.Equals(s.SectionName)) != null)
         return -1;

      s.SectionIdx = Sections.Count;
      Sections.Add(s);

      return s.SectionIdx;
   }

   public List<SFSection> Sections = new List<SFSection>();
   public List<SFSectionEvent> Sequence = new List<SFSectionEvent>();
}

[System.Serializable]
public class SFSection
{
   public string SectionName = "";
   public int SectionIdx = -1; //to pair with a PRTimedSection
}


//a section in a moment in time, references a particular section by index
[System.Serializable]
public class SFSectionEvent
{
   public float StartSecs = -1.0f;
   public float EndSecs = -1.0f;
   public int SectionIdx = -1;
   public int EventIdx = -1;
}

//a raw midi note
public class SFPitchedNote
{
   public bool IsValid() { return (StartSecs >= 0.0f) && (EndSecs >= 0.0f) && (EndSecs > StartSecs); }

   public int pitch = 0;
   public float StartSecs = -1.0f;
   public float EndSecs = -1.0f;
}

[System.Serializable]
public class SFSongDataParsedEvent : UnityEvent<SFSongData>
{

}


[RequireComponent(typeof(OtherSongMgr))]
public class SFMidiParser : MonoBehaviour 
{
   //events
   public SFSongDataParsedEvent OnDataParsed = new SFSongDataParsedEvent();

   SFSongData _data = null;
   Song _song = null;

   public SFSongData GetParsedData() { return _data; }
   public Song GetSong() { return _song; }

   void Start()
   {
      if(OtherSongMgr.I)
      {
         OtherSongMgr.I.OnSongPrepared.AddListener(_OnSongLoaded);
      }
   }

   //this is basically here for tools to use outside play mode, and not intended to be used by the game
   public SFSongData ForceParseMidiFile(MidiFile f, Song s)
   {
      _song = s;
      _ParseMidiData(f);
      return _data;
   }

   void _OnSongLoaded(Song s)
   {
      _song = s;

      //parse the midi data that was loaded
      if (s.GetMidiFile() != null)
         _ParseMidiData(s.GetMidiFile());
      else
         Debug.LogWarning("Can't parse midi data because song did not load one successfully...");
   }

   void _ParseMidiData(MidiFile midiFile)
   {
      Debug.Log("Begin parsing midi file...");

      _data = new SFSongData();

      //loop thru each track
      foreach (TrackChunk c in midiFile.Chunks)
      {
         var trackName = c.Events
                          .OfType<SequenceTrackNameEvent>()
                          .FirstOrDefault()
                          ?.Text;

         if (trackName == null)
            continue;

         string trackNameToLower = trackName.ToLower();

         //timing belt?
         if (trackNameToLower.Contains("gameplay"))
            _ParseGameplayTrack(trackName, c);
         else if (trackNameToLower.Contains("section"))
         {
            //grab all the sections
            _ParseSections(trackName, c);
         }
      }
   }

   public static int GetMaxLanes()
   {
      const int kMaxLanes = 5;

      return kMaxLanes;
   }

   void _ProcessGameplayNote(SFPitchedNote note)
   {
      const int kLaneStartNote = 12;
      int kNumLanes = GetMaxLanes();
      const int kSquatNote = 24;

      //squat action
      if(note.pitch == kSquatNote)
      {
         SFActionEvent a = new SFActionEvent();
         a.StartSecs = note.StartSecs;
         a.EndSecs = note.EndSecs;
         a.Action = SFGameplayAction.Squat;

         _data.ActionData.ActionEvents.Add(a);
      }
      //lane?
      else if((note.pitch >= kLaneStartNote) && (note.pitch < kLaneStartNote + kNumLanes))
      {
         SFLaneEvent l = new SFLaneEvent();
         l.StartSecs = note.StartSecs;
         l.EndSecs = note.EndSecs;
         l.LaneIdx = (note.pitch - kLaneStartNote);

         _data.LaneData.LaneEvents.Add(l);
      }
   }

   void _ParseGameplayTrack(string trackName, TrackChunk c)
   {
      _data.LaneData.LaneEvents.Clear();
      _data.ActionData.ActionEvents.Clear();

      //notes that haven't found their matching note-off yet...
      List<SFPitchedNote> trackedNotes = new List<SFPitchedNote>();

      SFPitchedNote newNote = null;
      using (TimedEventsManager timedEventsManager = c.ManageTimedEvents())
      {
         // Get timed events ordered by time
         TimedEventsCollection events = timedEventsManager.Events;

         foreach (var midiEvent in events)
         {
            if ((midiEvent.Event is NoteOnEvent)) //found a note on
            {
               int pitch = (midiEvent.Event as NoteOnEvent).NoteNumber;

               float curSecs = midiEvent.TimeAs<MetricTimeSpan>(_song.GetTempoMap()).TotalMicroseconds / 1000000.0f;

               newNote = new SFPitchedNote();
               newNote.StartSecs = curSecs;
               newNote.pitch = pitch;

               trackedNotes.Add(newNote);
            }
            else if (midiEvent.Event is NoteOffEvent)
            {
               int noteOffPitch = ((midiEvent.Event as NoteOffEvent).NoteNumber);

               //can we find a corresponding note On?
               SFPitchedNote foundMatch = null;
               int foundMatchIdx = -1;
               for (int trackedNoteIdx = 0; trackedNoteIdx < trackedNotes.Count; trackedNoteIdx++)
               {
                  var trackedNote = trackedNotes[trackedNoteIdx];
                  if (trackedNote.pitch == noteOffPitch)
                  {
                     foundMatch = trackedNote;
                     foundMatchIdx = trackedNoteIdx;
                     break;
                  }
               }

               //found it, finish out the note and add it to our list (and stop tracking it!)
               if (foundMatch != null)
               {
                  foundMatch.EndSecs = midiEvent.TimeAs<MetricTimeSpan>(_song.GetTempoMap()).TotalMicroseconds / 1000000.0f;

                  if (foundMatch.IsValid())
                  {
                     _ProcessGameplayNote(foundMatch);
                  }

                  trackedNotes.RemoveAt(foundMatchIdx);
                  newNote = null;
               }
            }
         }
      }

      //print summary
      Debug.Log("Found " + _data.LaneData.LaneEvents.Count + " lane change events...");
      Debug.Log("Found " + _data.ActionData.ActionEvents.Count + " gameplay actions...");

      OnDataParsed.Invoke(_data);
   }


   void _ParseSections(string trackName, TrackChunk c)
   {
      Debug.Log("Found song sections midi track '" + trackName + "'...");

      using (TimedEventsManager timedEventsManager = c.ManageTimedEvents())
      {
         // Get timed events ordered by time
         TimedEventsCollection events = timedEventsManager.Events;
         SFSectionEvent prevEvent = null;
         foreach (var midiEvent in events)
         {
            if (!(midiEvent.Event is SequenceTrackNameEvent) && (midiEvent.Event is BaseTextEvent)) //text event!
            {
               SFSectionEvent newEvent = new SFSectionEvent();
               string sectionName = (midiEvent.Event as BaseTextEvent).Text;

               int sectionIdx = _data.SectionData.SectionNameToIdx(sectionName);
               if (sectionIdx < 0) //first time seeing this section, add it to sections
               {
                  SFSection newSection = new SFSection();
                  newSection.SectionName = sectionName;

                  sectionIdx = _data.SectionData.AddSection(newSection);
               }

               if (sectionIdx < 0)
               {
                  Debug.LogWarning("error processing section " + sectionName);
                  continue;
               }

               //finish filling out timed section event
               newEvent.SectionIdx = sectionIdx;
               newEvent.EventIdx = _data.SectionData.Sequence.Count;
               newEvent.StartSecs = midiEvent.TimeAs<MetricTimeSpan>(_song.GetTempoMap()).TotalMicroseconds / 1000000.0f;
               newEvent.EndSecs = newEvent.StartSecs; //will be filled in next event

               //close out old event
               if (prevEvent != null)
                  prevEvent.EndSecs = newEvent.StartSecs;

               _data.SectionData.Sequence.Add(newEvent);

               prevEvent = newEvent;
            }
         }

         //close out final event
         float endSecs = ((_song != null) && (_song.AudioToPlay != null)) ? _song.AudioToPlay.length : -1.0f;
         if ((prevEvent != null) && (endSecs > 0.0f))
            prevEvent.EndSecs = endSecs;
      }

      //print summary of what we found
      Debug.Log("Found " + _data.SectionData.Sequence.Count + " section markers with " + _data.SectionData.Sections.Count + " unique sections: ");
      foreach (var s in _data.SectionData.Sections)
         Debug.Log("    " + s.SectionName);
   }
}
