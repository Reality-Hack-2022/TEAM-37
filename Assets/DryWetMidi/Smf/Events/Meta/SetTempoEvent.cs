using Melanchall.DryWetMidi.Common;

namespace Melanchall.DryWetMidi.Smf
{
    /// <summary>
    /// Represents a Set Tempo meta event.
    /// </summary>
    /// <remarks>
    /// The MIDI set tempo meta message sets the tempo of a MIDI sequence in terms
    /// of microseconds per quarter note.
    /// </remarks>
    public sealed class SetTempoEvent : MetaEvent
    {
        #region Constants

        /// <summary>
        /// Default tempo.
        /// </summary>
        public const long DefaultTempo = 500000;

        #endregion

        #region Fields

        private long _microsecondsPerBeat = DefaultTempo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SetTempoEvent"/>.
        /// </summary>
        public SetTempoEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetTempoEvent"/> with the
        /// specified number of microseconds per quarter note.
        /// </summary>
        /// <param name="microsecondsPerQuarterNote">Number of microseconds per quarter note.</param>
        public SetTempoEvent(long microsecondsPerQuarterNote)
            : this()
        {
            MicrosecondsPerQuarterNote = microsecondsPerQuarterNote;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets number of microseconds per quarter note.
        /// </summary>
        public long MicrosecondsPerQuarterNote
        {
            get { return _microsecondsPerBeat; }
            set
            {
                ThrowIfArgument.IsNonpositive(nameof(value),
                                              value,
                                              "Value of microseconds per quarter note is zero or negative.");

                _microsecondsPerBeat = value;
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Reads content of a MIDI meta event.
        /// </summary>
        /// <param name="reader">Reader to read the content with.</param>
        /// <param name="settings">Settings according to which the event's content must be read.</param>
        /// <param name="size">Size of the event's content.</param>
        protected override void ReadContent(MidiReader reader, ReadingSettings settings, int size)
        {
            MicrosecondsPerQuarterNote = reader.Read3ByteDword();
        }

        /// <summary>
        /// Writes content of a MIDI meta event.
        /// </summary>
        /// <param name="writer">Writer to write the content with.</param>
        /// <param name="settings">Settings according to which the event's content must be written.</param>
        protected override void WriteContent(MidiWriter writer, WritingSettings settings)
        {
            writer.Write3ByteDword((uint)MicrosecondsPerQuarterNote);
        }

        /// <summary>
        /// Gets the size of the content of a MIDI meta event.
        /// </summary>
        /// <param name="settings">Settings according to which the event's content must be written.</param>
        /// <returns>Size of the event's content.</returns>
        protected override int GetContentSize(WritingSettings settings)
        {
            return 3;
        }

        /// <summary>
        /// Clones event by creating a copy of it.
        /// </summary>
        /// <returns>Copy of the event.</returns>
        protected override MidiEvent CloneEvent()
        {
            return new SetTempoEvent(MicrosecondsPerQuarterNote);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Set Tempo ({MicrosecondsPerQuarterNote})";
        }

        #endregion
    }
}
