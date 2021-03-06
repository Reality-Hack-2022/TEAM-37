using Melanchall.DryWetMidi.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Melanchall.DryWetMidi.Smf.Interaction
{
    /// <summary>
    /// Extension methods for chords managing.
    /// </summary>
    public static class ChordsManagingUtilities
    {
        #region Methods

        /// <summary>
        /// Creates an instance of the <see cref="ChordsManager"/> initializing it with the
        /// specified events collection, notes tolerance and comparison delegate for events that have same time.
        /// </summary>
        /// <param name="eventsCollection"><see cref="EventsCollection"/> that holds chords to manage.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <param name="sameTimeEventsComparison">Delegate to compare events with the same absolute time.</param>
        /// <returns>An instance of the <see cref="ChordsManager"/> that can be used to manage chords
        /// represented by the <paramref name="eventsCollection"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="eventsCollection"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static ChordsManager ManageChords(this EventsCollection eventsCollection, long notesTolerance = 0, Comparison<MidiEvent> sameTimeEventsComparison = null)
        {
            ThrowIfArgument.IsNull(nameof(eventsCollection), eventsCollection);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            return new ChordsManager(eventsCollection, notesTolerance, sameTimeEventsComparison);
        }

        /// <summary>
        /// Creates an instance of the <see cref="ChordsManager"/> initializing it with the
        /// events collection of the specified track chunk, notes tolerance and comparison delegate for events
        /// that have same time.
        /// </summary>
        /// <param name="trackChunk"><see cref="TrackChunk"/> that holds chords to manage.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <param name="sameTimeEventsComparison">Delegate to compare events with the same absolute time.</param>
        /// <returns>An instance of the <see cref="ChordsManager"/> that can be used to manage
        /// chords represented by the <paramref name="trackChunk"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunk"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static ChordsManager ManageChords(this TrackChunk trackChunk, long notesTolerance = 0, Comparison<MidiEvent> sameTimeEventsComparison = null)
        {
            ThrowIfArgument.IsNull(nameof(trackChunk), trackChunk);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            return trackChunk.Events.ManageChords(notesTolerance, sameTimeEventsComparison);
        }

        /// <summary>
        /// Gets chords contained in the specified <see cref="EventsCollection"/>.
        /// </summary>
        /// <param name="eventsCollection"><see cref="EventsCollection"/> to search for chords.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <returns>Collection of chords contained in <paramref name="eventsCollection"/> ordered by time.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="eventsCollection"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static IEnumerable<Chord> GetChords(this EventsCollection eventsCollection, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(eventsCollection), eventsCollection);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            return eventsCollection.ManageChords(notesTolerance).Chords.ToList();
        }

        /// <summary>
        /// Gets chords contained in the specified <see cref="TrackChunk"/>.
        /// </summary>
        /// <param name="trackChunk"><see cref="TrackChunk"/> to search for chords.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <returns>Collection of chords contained in <paramref name="trackChunk"/> ordered by time.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunk"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static IEnumerable<Chord> GetChords(this TrackChunk trackChunk, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(trackChunk), trackChunk);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            return trackChunk.Events.GetChords(notesTolerance);
        }

        /// <summary>
        /// Gets chords contained in the specified collection of <see cref="TrackChunk"/>.
        /// </summary>
        /// <param name="trackChunks">Track chunks to search for chords.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <returns>Collection of chords contained in <paramref name="trackChunks"/> ordered by time.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunks"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static IEnumerable<Chord> GetChords(this IEnumerable<TrackChunk> trackChunks, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(trackChunks), trackChunks);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            return trackChunks.Where(c => c != null)
                              .SelectMany(c => c.GetChords(notesTolerance))
                              .OrderBy(c => c.Time)
                              .ToList();
        }

        /// <summary>
        /// Gets chords contained in the specified <see cref="MidiFile"/>.
        /// </summary>
        /// <param name="file"><see cref="MidiFile"/> to search for chords.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <returns>Collection of notes contained in <paramref name="file"/> ordered by time.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="file"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static IEnumerable<Chord> GetChords(this MidiFile file, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(file), file);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            return file.GetTrackChunks().GetChords(notesTolerance);
        }

        public static IEnumerable<Chord> GetChords(this IEnumerable<Note> notes, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(notes), notes);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            return ChordsManager.CreateChords(notes, notesTolerance)
                                .OrderBy(c => c.Time)
                                .ToList();
        }

        /// <summary>
        /// Performs the specified action on each <see cref="Chord"/> contained in the <see cref="EventsCollection"/>.
        /// </summary>
        /// <param name="eventsCollection"><see cref="EventsCollection"/> to search for chords to process.</param>
        /// <param name="action">The action to perform on each <see cref="Chord"/> contained in the
        /// <paramref name="eventsCollection"/>.</param>
        /// <param name="match">The predicate that defines the conditions of the <see cref="Chord"/> to process.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventsCollection"/> is null. -or-
        /// <paramref name="action"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static void ProcessChords(this EventsCollection eventsCollection, Action<Chord> action, Predicate<Chord> match = null, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(eventsCollection), eventsCollection);
            ThrowIfArgument.IsNull(nameof(action), action);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            using (var chordsManager = eventsCollection.ManageChords(notesTolerance))
            {
                foreach (var chord in chordsManager.Chords.Where(c => match?.Invoke(c) != false))
                {
                    action(chord);
                }
            }
        }

        /// <summary>
        /// Performs the specified action on each <see cref="Chord"/> contained in the <see cref="TrackChunk"/>.
        /// </summary>
        /// <param name="trackChunk"><see cref="TrackChunk"/> to search for chords to process.</param>
        /// <param name="action">The action to perform on each <see cref="Chord"/> contained in the
        /// <paramref name="trackChunk"/>.</param>
        /// <param name="match">The predicate that defines the conditions of the <see cref="Chord"/> to process.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunk"/> is null. -or-
        /// <paramref name="action"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static void ProcessChords(this TrackChunk trackChunk, Action<Chord> action, Predicate<Chord> match = null, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(trackChunk), trackChunk);
            ThrowIfArgument.IsNull(nameof(action), action);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            trackChunk.Events.ProcessChords(action, match, notesTolerance);
        }

        /// <summary>
        /// Performs the specified action on each <see cref="Chord"/> contained in the collection of
        /// <see cref="TrackChunk"/>.
        /// </summary>
        /// <param name="trackChunks">Collection of <see cref="TrackChunk"/> to search for chords to process.</param>
        /// <param name="action">The action to perform on each <see cref="Chord"/> contained in the
        /// <paramref name="trackChunks"/>.</param>
        /// <param name="match">The predicate that defines the conditions of the <see cref="Chord"/> to process.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunks"/> is null. -or-
        /// <paramref name="action"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static void ProcessChords(this IEnumerable<TrackChunk> trackChunks, Action<Chord> action, Predicate<Chord> match = null, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(trackChunks), trackChunks);
            ThrowIfArgument.IsNull(nameof(action), action);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            foreach (var trackChunk in trackChunks)
            {
                trackChunk?.ProcessChords(action, match, notesTolerance);
            }
        }

        /// <summary>
        /// Performs the specified action on each <see cref="Chord"/> contained in the <see cref="MidiFile"/>.
        /// </summary>
        /// <param name="file"><see cref="MidiFile"/> to search for chords to process.</param>
        /// <param name="action">The action to perform on each <see cref="Chord"/> contained in the
        /// <paramref name="file"/>.</param>
        /// <param name="match">The predicate that defines the conditions of the <see cref="Chord"/> to process.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="file"/> is null. -or-
        /// <paramref name="action"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static void ProcessChords(this MidiFile file, Action<Chord> action, Predicate<Chord> match = null, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(file), file);
            ThrowIfArgument.IsNull(nameof(action), action);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            file.GetTrackChunks().ProcessChords(action, match, notesTolerance);
        }

        /// <summary>
        /// Removes all the <see cref="Chord"/> that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="eventsCollection"><see cref="EventsCollection"/> to search for chords to remove.</param>
        /// <param name="match">The predicate that defines the conditions of the <see cref="Chord"/> to remove.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventsCollection"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static void RemoveChords(this EventsCollection eventsCollection, Predicate<Chord> match = null, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(eventsCollection), eventsCollection);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            using (var chordsManager = eventsCollection.ManageChords(notesTolerance))
            {
                chordsManager.Chords.RemoveAll(match ?? (c => true));
            }
        }

        /// <summary>
        /// Removes all the <see cref="Chord"/> that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="trackChunk"><see cref="TrackChunk"/> to search for chords to remove.</param>
        /// <param name="match">The predicate that defines the conditions of the <see cref="Chord"/> to remove.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunk"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static void RemoveChords(this TrackChunk trackChunk, Predicate<Chord> match = null, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(trackChunk), trackChunk);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            trackChunk.Events.RemoveChords(match, notesTolerance);
        }

        /// <summary>
        /// Removes all the <see cref="Chord"/> that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="trackChunks">Collection of <see cref="TrackChunk"/> to search for chords to remove.</param>
        /// <param name="match">The predicate that defines the conditions of the <see cref="Chord"/> to remove.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunks"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static void RemoveChords(this IEnumerable<TrackChunk> trackChunks, Predicate<Chord> match = null, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(trackChunks), trackChunks);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            foreach (var trackChunk in trackChunks)
            {
                trackChunk?.RemoveChords(match, notesTolerance);
            }
        }

        /// <summary>
        /// Removes all the <see cref="Chord"/> that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="file"><see cref="MidiFile"/> to search for chords to remove.</param>
        /// <param name="match">The predicate that defines the conditions of the <see cref="Chord"/> to remove.</param>
        /// <param name="notesTolerance">Notes tolerance that defines maximum distance of notes from the
        /// start of the first note of a chord. Notes within this tolerance will be considered as a chord.</param>
        /// <exception cref="ArgumentNullException"><paramref name="file"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="notesTolerance"/> is negative.</exception>
        public static void RemoveChords(this MidiFile file, Predicate<Chord> match = null, long notesTolerance = 0)
        {
            ThrowIfArgument.IsNull(nameof(file), file);
            ThrowIfNotesTolerance.IsNegative(nameof(notesTolerance), notesTolerance);

            file.GetTrackChunks().RemoveChords(match, notesTolerance);
        }

        /// <summary>
        /// Adds collection of chords to the specified <see cref="EventsCollection"/>.
        /// </summary>
        /// <param name="eventsCollection"><see cref="EventsCollection"/> to add chords to.</param>
        /// <param name="chords">Chords to add to the <paramref name="eventsCollection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventsCollection"/> is null. -or-
        /// <paramref name="chords"/> is null.</exception>
        public static void AddChords(this EventsCollection eventsCollection, IEnumerable<Chord> chords)
        {
            ThrowIfArgument.IsNull(nameof(eventsCollection), eventsCollection);
            ThrowIfArgument.IsNull(nameof(chords), chords);

            using (var chordsManager = eventsCollection.ManageChords())
            {
                chordsManager.Chords.Add(chords);
            }
        }

        /// <summary>
        /// Adds collection of chords to the specified <see cref="TrackChunk"/>.
        /// </summary>
        /// <param name="trackChunk"><see cref="TrackChunk"/> to add chords to.</param>
        /// <param name="chords">Chords to add to the <paramref name="trackChunk"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunk"/> is null. -or-
        /// <paramref name="chords"/> is null.</exception>
        public static void AddChords(this TrackChunk trackChunk, IEnumerable<Chord> chords)
        {
            ThrowIfArgument.IsNull(nameof(trackChunk), trackChunk);
            ThrowIfArgument.IsNull(nameof(chords), chords);

            trackChunk.Events.AddChords(chords);
        }

        /// <summary>
        /// Creates a track chunk with the specified chords.
        /// </summary>
        /// <param name="chords">Collection of chords to create a track chunk.</param>
        /// <returns><see cref="TrackChunk"/> containing the specified chords.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="chords"/> is null.</exception>
        public static TrackChunk ToTrackChunk(this IEnumerable<Chord> chords)
        {
            ThrowIfArgument.IsNull(nameof(chords), chords);

            var trackChunk = new TrackChunk();
            trackChunk.AddChords(chords);

            return trackChunk;
        }

        /// <summary>
        /// Creates a MIDI file with the specified chords.
        /// </summary>
        /// <param name="chords">Collection of chords to create a MIDI file.</param>
        /// <returns><see cref="MidiFile"/> containing the specified chords.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="chords"/> is null.</exception>
        public static MidiFile ToFile(this IEnumerable<Chord> chords)
        {
            ThrowIfArgument.IsNull(nameof(chords), chords);

            return new MidiFile(chords.ToTrackChunk());
        }

        #endregion
    }
}
