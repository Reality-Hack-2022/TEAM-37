using System;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;

namespace Melanchall.DryWetMidi.Tools
{
    /// <summary>
    /// Provides methods to randomize notes time.
    /// </summary>
    public static class NotesRandomizerUtilities
    {
        #region Methods

        /// <summary>
        /// Randomizes notes contained in the specified <see cref="TrackChunk"/>.
        /// </summary>
        /// <param name="trackChunk"><see cref="TrackChunk"/> to randomize notes in.</param>
        /// <param name="bounds">Bounds to randomize time within.</param>
        /// <param name="tempoMap">Tempo map used to calculate time bounds to randomize within.</param>
        /// <param name="settings">Settings according to which notes should be randomized.</param>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunk"/> is null. -or-
        /// <paramref name="bounds"/> is null. -or- <paramref name="tempoMap"/> is null.</exception>
        public static void RandomizeNotes(this TrackChunk trackChunk, IBounds bounds, TempoMap tempoMap, NotesRandomizingSettings settings = null)
        {
            ThrowIfArgument.IsNull(nameof(trackChunk), trackChunk);
            ThrowIfArgument.IsNull(nameof(bounds), bounds);
            ThrowIfArgument.IsNull(nameof(tempoMap), tempoMap);

            using (var notesManager = trackChunk.ManageNotes())
            {
                new NotesRandomizer().Randomize(notesManager.Notes, bounds, tempoMap, settings);
            }
        }

        /// <summary>
        /// Randomizes notes contained in the specified collection of <see cref="TrackChunk"/>.
        /// </summary>
        /// <param name="trackChunks">Collection of <see cref="TrackChunk"/> to randomize notes in.</param>
        /// <param name="bounds">Bounds to randomize time within.</param>
        /// <param name="tempoMap">Tempo map used to calculate time bounds to randomize within.</param>
        /// <param name="settings">Settings according to which notes should be randomized.</param>
        /// <exception cref="ArgumentNullException"><paramref name="trackChunks"/> is null. -or-
        /// <paramref name="bounds"/> is null. -or- <paramref name="tempoMap"/> is null.</exception>
        public static void RandomizeNotes(this IEnumerable<TrackChunk> trackChunks, IBounds bounds, TempoMap tempoMap, NotesRandomizingSettings settings = null)
        {
            ThrowIfArgument.IsNull(nameof(trackChunks), trackChunks);
            ThrowIfArgument.IsNull(nameof(bounds), bounds);
            ThrowIfArgument.IsNull(nameof(tempoMap), tempoMap);

            foreach (var trackChunk in trackChunks)
            {
                trackChunk.RandomizeNotes(bounds, tempoMap, settings);
            }
        }

        /// <summary>
        /// Randomizes notes contained in the specified <see cref="MidiFile"/>.
        /// </summary>
        /// <param name="midiFile"><see cref="MidiFile"/> to randomize notes in.</param>
        /// <param name="bounds">Bounds to randomize time within.</param>
        /// <param name="settings">Settings according to which notes should be randomized.</param>
        /// <exception cref="ArgumentNullException"><paramref name="midiFile"/> is null. -or-
        /// <paramref name="bounds"/> is null.</exception>
        public static void RandomizeNotes(this MidiFile midiFile, IBounds bounds, NotesRandomizingSettings settings = null)
        {
            ThrowIfArgument.IsNull(nameof(midiFile), midiFile);
            ThrowIfArgument.IsNull(nameof(bounds), bounds);

            var tempoMap = midiFile.GetTempoMap();

            midiFile.GetTrackChunks().RandomizeNotes(bounds, tempoMap, settings);
        }

        #endregion
    }
}
