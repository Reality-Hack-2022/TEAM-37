using Melanchall.DryWetMidi.Common;
using System;

namespace Melanchall.DryWetMidi.Smf.Interaction
{
    /// <summary>
    /// Represents a time span as a fraction of the whole note's length.
    /// </summary>
    public sealed class MusicalTimeSpan : ITimeSpan, IComparable<MusicalTimeSpan>, IEquatable<MusicalTimeSpan>
    {
        #region Constants

        /// <summary>
        /// <see cref="MusicalTimeSpan"/> that corresponds to the whole length.
        /// </summary>
        public static readonly MusicalTimeSpan Whole = new MusicalTimeSpan(WholeFraction);

        /// <summary>
        /// <see cref="MusicalTimeSpan"/> that corresponds to the half length.
        /// </summary>
        public static readonly MusicalTimeSpan Half = new MusicalTimeSpan(HalfFraction);

        /// <summary>
        /// <see cref="MusicalTimeSpan"/> that corresponds to the quarter length.
        /// </summary>
        public static readonly MusicalTimeSpan Quarter = new MusicalTimeSpan(QuarterFraction);

        /// <summary>
        /// <see cref="MusicalTimeSpan"/> that corresponds to the eighth length.
        /// </summary>
        public static readonly MusicalTimeSpan Eighth = new MusicalTimeSpan(EighthFraction);

        /// <summary>
        /// <see cref="MusicalTimeSpan"/> that corresponds to the sixteenth length.
        /// </summary>
        public static readonly MusicalTimeSpan Sixteenth = new MusicalTimeSpan(SixteenthFraction);

        /// <summary>
        /// <see cref="MusicalTimeSpan"/> that corresponds to the thirty-second length.
        /// </summary>
        public static readonly MusicalTimeSpan ThirtySecond = new MusicalTimeSpan(ThirtySecondFraction);

        /// <summary>
        /// <see cref="MusicalTimeSpan"/> that corresponds to the sixty-fourth length.
        /// </summary>
        public static readonly MusicalTimeSpan SixtyFourth = new MusicalTimeSpan(SixtyFourthFraction);

        private const long ZeroTimeSpanNumerator = 0;
        private const long ZeroTimeSpanDenominator = 1;

        private const long FractionNumerator = 1;

        private const int WholeFraction = 1;
        private const int HalfFraction = 2;
        private const int QuarterFraction = 4;
        private const int EighthFraction = 8;
        private const int SixteenthFraction = 16;
        private const int ThirtySecondFraction = 32;
        private const int SixtyFourthFraction = 64;

        private const int TripletNotesCount = 3;
        private const int TripletSpaceSize = 2;

        private const int DupletNotesCount = 2;
        private const int DupletSpaceSize = 3;

        private const int SingleDotCount = 1;
        private const int DoubleDotCount = 2;

        private const int NumberOfDigitsAfterDecimalPoint = 3;
        private static readonly int FractionPartMultiplier = (int)Math.Pow(10, NumberOfDigitsAfterDecimalPoint);

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicalTimeSpan"/>.
        /// </summary>
        public MusicalTimeSpan()
            : this(ZeroTimeSpanNumerator, ZeroTimeSpanDenominator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicalTimeSpan"/> with the specified
        /// fraction of the whole note's length.
        /// </summary>
        /// <param name="fraction">The fraction of the whole note's length.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="fraction"/> is zero or negative.</exception>
        public MusicalTimeSpan(long fraction)
            : this(FractionNumerator, fraction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicalTimeSpan"/> with the specified
        /// numerator and denominator of the fraction of the whole note's length.
        /// </summary>
        /// <param name="numerator">The numerator of fraction of the whole note's length.</param>
        /// <param name="denominator">The denominator of fraction of the whole note's length.</param>
        /// <param name="simplify">true if the time span should be simplified, false otherwise.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="numerator"/> is negative. -or-
        /// <paramref name="denominator"/> is zero or negative.</exception>
        public MusicalTimeSpan(long numerator, long denominator, bool simplify = true)
        {
            ThrowIfArgument.IsNegative(nameof(numerator), numerator, "Numerator is negative.");
            ThrowIfArgument.IsNonpositive(nameof(denominator), denominator, "Denominator is zero or negative.");

            var greatestCommonDivisor = simplify
                ? MathUtilities.GreatestCommonDivisor(numerator, denominator)
                : 1;

            Numerator = numerator / greatestCommonDivisor;
            Denominator = denominator / greatestCommonDivisor;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the numerator of the current <see cref="MusicalTimeSpan"/>.
        /// </summary>
        public long Numerator { get; }

        /// <summary>
        /// Gets the denominator of the current <see cref="MusicalTimeSpan"/>.
        /// </summary>
        public long Denominator { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the current <see cref="MusicalTimeSpan"/> modified by the specified number
        /// of dots.
        /// </summary>
        /// <param name="dotsCount">The number of dots to modify the current <see cref="MusicalTimeSpan"/>.</param>
        /// <returns>The dotted version of the current <see cref="MusicalTimeSpan"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="dotsCount"/> is negative.</exception>
        public MusicalTimeSpan Dotted(int dotsCount)
        {
            ThrowIfArgument.IsNegative(nameof(dotsCount), dotsCount, "Dots count is negative.");

            return new MusicalTimeSpan(Numerator * ((1 << dotsCount + 1) - 1),
                                       Denominator * (1 << dotsCount));
        }

        /// <summary>
        /// Returns the current <see cref="MusicalTimeSpan"/> modified by one dot.
        /// </summary>
        /// <returns>The single dotted version of the current <see cref="MusicalTimeSpan"/>.</returns>
        public MusicalTimeSpan SingleDotted()
        {
            return Dotted(SingleDotCount);
        }

        /// <summary>
        /// Returns the current <see cref="MusicalTimeSpan"/> modified by two dots.
        /// </summary>
        /// <returns>The double dotted version of the current <see cref="MusicalTimeSpan"/>.</returns>
        public MusicalTimeSpan DoubleDotted()
        {
            return Dotted(DoubleDotCount);
        }

        /// <summary>
        /// Returns a tuplet based on the current <see cref="MusicalTimeSpan"/>.
        /// </summary>
        /// <param name="tupletNotesCount">Notes count of a tuplet to construct.</param>
        /// <param name="tupletSpaceSize">Space of a tuplet to construct.</param>
        /// <returns>A tuplet based on the current <see cref="MusicalTimeSpan"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tupletNotesCount"/> is zero
        /// or negative. -or- <paramref name="tupletSpaceSize"/> is zero or negative.</exception>
        public MusicalTimeSpan Tuplet(int tupletNotesCount, int tupletSpaceSize)
        {
            ThrowIfArgument.IsNonpositive(nameof(tupletNotesCount), tupletNotesCount, "Tuplet's notes count is zero or negative.");
            ThrowIfArgument.IsNonpositive(nameof(tupletSpaceSize), tupletSpaceSize, "Tuplet's space size is zero or negative.");

            return new MusicalTimeSpan(Numerator * tupletSpaceSize,
                                       Denominator * tupletNotesCount);
        }

        /// <summary>
        /// Returns a triplet based on the current <see cref="MusicalTimeSpan"/>.
        /// </summary>
        /// <returns>A triplet based on the current <see cref="MusicalTimeSpan"/>.</returns>
        public MusicalTimeSpan Triplet()
        {
            return Tuplet(TripletNotesCount, TripletSpaceSize);
        }

        /// <summary>
        /// Returns a duplet based on the current <see cref="MusicalTimeSpan"/>.
        /// </summary>
        /// <returns>A duplet based on the current <see cref="MusicalTimeSpan"/>.</returns>
        public MusicalTimeSpan Duplet()
        {
            return Tuplet(DupletNotesCount, DupletSpaceSize);
        }

        /// <summary>
        /// Divides the current time span by the specified <see cref="MusicalTimeSpan"/> returning ration
        /// between them.
        /// </summary>
        /// <param name="timeSpan"><see cref="MusicalTimeSpan"/> to divide the current time span by.</param>
        /// <returns>Rayion between the current <see cref="MusicalTimeSpan"/> and <paramref name="timeSpan"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan"/> is null.</exception>
        /// <exception cref="DivideByZeroException"><paramref name="timeSpan"/> represents a time span of zero length.</exception>
        public double Divide(MusicalTimeSpan timeSpan)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan), timeSpan);

            if (timeSpan.Numerator == 0)
                throw new DivideByZeroException("Dividing by zero time span.");

            return (double)Numerator * timeSpan.Denominator / (Denominator * timeSpan.Numerator);
        }

        /// <summary>
        /// Changes denominator of the current <see cref="MusicalTimeSpan"/>.
        /// </summary>
        /// <param name="denominator">New denominator.</param>
        /// <returns>An instance of the <see cref="MusicalTimeSpan"/> which represents the same time span as
        /// the original one but with the specified denominator.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="denominator"/> is zero or negative.</exception>
        public MusicalTimeSpan ChangeDenominator(long denominator)
        {
            ThrowIfArgument.IsNonpositive(nameof(denominator), denominator, "Denominator is zero or negative.");

            var numerator = MathUtilities.RoundToLong((double)denominator / Denominator * Numerator);
            return new MusicalTimeSpan(numerator, denominator, false);
        }

        /// <summary>
        /// Converts the string representation of a whole note's fraction to its <see cref="MusicalTimeSpan"/>
        /// equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a time span to convert.</param>
        /// <param name="timeSpan">When this method returns, contains the <see cref="MusicalTimeSpan"/>
        /// equivalent of the time span contained in <paramref name="input"/>, if the conversion succeeded, or
        /// null if the conversion failed. The conversion fails if the <paramref name="input"/> is null or
        /// <see cref="String.Empty"/>, or is not of the correct format. This parameter is passed uninitialized;
        /// any value originally supplied in result will be overwritten.</param>
        /// <returns>true if <paramref name="input"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string input, out MusicalTimeSpan timeSpan)
        {
            return MusicalTimeSpanParser.TryParse(input, out timeSpan).Status == ParsingStatus.Parsed;
        }

        /// <summary>
        /// Converts the string representation of a whole note's fraction to its <see cref="MusicalTimeSpan"/>
        /// equivalent.
        /// </summary>
        /// <param name="input">A string containing a time span to convert.</param>
        /// <returns>A <see cref="MusicalTimeSpan"/> equivalent to the time span contained in
        /// <paramref name="input"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="input"/> is null or contains white-spaces only.</exception>
        /// <exception cref="FormatException"><paramref name="input"/> has invalid format.</exception>
        public static MusicalTimeSpan Parse(string input)
        {
            MusicalTimeSpan timeSpan;
            var parsingResult = MusicalTimeSpanParser.TryParse(input, out timeSpan);
            if (parsingResult.Status == ParsingStatus.Parsed)
                return timeSpan;

            throw parsingResult.Exception;
        }

        /// <summary>
        /// Reduces the specified musical time spans to the common denominator.
        /// </summary>
        /// <param name="fraction1">First time span.</param>
        /// <param name="fraction2">Second time span.</param>
        /// <param name="numerator1">Numerator of the reduced first time span.</param>
        /// <param name="numerator2">Numerator of the reduced second time span.</param>
        /// <param name="denominator">Common denominator of reduced time spans.</param>
        private static void ReduceToCommonDenominator(MusicalTimeSpan fraction1,
                                                      MusicalTimeSpan fraction2,
                                                      out long numerator1,
                                                      out long numerator2,
                                                      out long denominator)
        {
            denominator = MathUtilities.LeastCommonMultiple(fraction1.Denominator, fraction2.Denominator);

            numerator1 = fraction1.Numerator * denominator / fraction1.Denominator;
            numerator2 = fraction2.Numerator * denominator / fraction2.Denominator;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Determines if two <see cref="MusicalTimeSpan"/> objects are equal.
        /// </summary>
        /// <param name="timeSpan1">The first <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <param name="timeSpan2">The second <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <returns>true if time spans are equal, false otherwise.</returns>
        public static bool operator ==(MusicalTimeSpan timeSpan1, MusicalTimeSpan timeSpan2)
        {
            if (ReferenceEquals(timeSpan1, null))
                return ReferenceEquals(timeSpan2, null);

            return timeSpan1.Equals(timeSpan2);
        }

        /// <summary>
        /// Determines if two <see cref="MusicalTimeSpan"/> objects are not equal.
        /// </summary>
        /// <param name="timeSpan1">The first <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <param name="timeSpan2">The second <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <returns>false if time spans are equal, true otherwise.</returns>
        public static bool operator !=(MusicalTimeSpan timeSpan1, MusicalTimeSpan timeSpan2)
        {
            return !(timeSpan1 == timeSpan2);
        }

        /// <summary>
        /// Multiplies the specified <see cref="MusicalTimeSpan"/> by a number.
        /// </summary>
        /// <param name="timeSpan">The <see cref="MusicalTimeSpan"/> to multiply by <paramref name="number"/>.</param>
        /// <param name="number">The multiplier.</param>
        /// <returns>An object whose value is the result of multiplication of <paramref name="timeSpan"/> by
        /// <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="number"/> is negative.</exception>
        public static MusicalTimeSpan operator *(MusicalTimeSpan timeSpan, long number)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan), timeSpan);
            ThrowIfArgument.IsNegative(nameof(number), number, "Number is negative.");

            return new MusicalTimeSpan(timeSpan.Numerator * number,
                                       timeSpan.Denominator);
        }

        /// <summary>
        /// Multiplies the specified <see cref="MusicalTimeSpan"/> by a number.
        /// </summary>
        /// <param name="number">The multiplier.</param>
        /// <param name="timeSpan">The <see cref="MusicalTimeSpan"/> to multiply by <paramref name="number"/>.</param>
        /// <returns>An object whose value is the result of multiplication of <paramref name="timeSpan"/> by
        /// <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="number"/> is negative.</exception>
        public static MusicalTimeSpan operator *(long number, MusicalTimeSpan timeSpan)
        {
            return timeSpan * number;
        }

        /// <summary>
        /// Divides the specified <see cref="MusicalTimeSpan"/> by a number.
        /// </summary>
        /// <param name="timeSpan">The <see cref="MusicalTimeSpan"/> to divide by <paramref name="number"/>.</param>
        /// <param name="number">The multiplier.</param>
        /// <returns>An object whose value is the result of division of <paramref name="timeSpan"/> by
        /// <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="number"/> is negative.</exception>
        public static MusicalTimeSpan operator /(MusicalTimeSpan timeSpan, long number)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan), timeSpan);
            ThrowIfArgument.IsNonpositive(nameof(number), number, "Number is zero or negative.");

            return new MusicalTimeSpan(timeSpan.Numerator,
                                       timeSpan.Denominator * number);
        }

        /// <summary>
        /// Adds two specified <see cref="MusicalTimeSpan"/> instances.
        /// </summary>
        /// <param name="timeSpan1">The first <see cref="MusicalTimeSpan"/> to add.</param>
        /// <param name="timeSpan2">The second <see cref="MusicalTimeSpan"/> to add.</param>
        /// <returns>An object whose value is the sum of the values of <paramref name="timeSpan1"/> and
        /// <paramref name="timeSpan2"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan1"/> is null. -or-
        /// <paramref name="timeSpan2"/> is null.</exception>
        public static MusicalTimeSpan operator +(MusicalTimeSpan timeSpan1, MusicalTimeSpan timeSpan2)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan1), timeSpan1);
            ThrowIfArgument.IsNull(nameof(timeSpan2), timeSpan2);

            long numerator1, numerator2, denominator;
            ReduceToCommonDenominator(timeSpan1, timeSpan2, out numerator1, out numerator2, out denominator);
            return new MusicalTimeSpan(numerator1 + numerator2, denominator);
        }

        /// <summary>
        /// Subtracts a specified <see cref="MusicalTimeSpan"/> from another one.
        /// </summary>
        /// <param name="timeSpan1">The minuend.</param>
        /// <param name="timeSpan2">The subtrahend.</param>
        /// <returns>An object whose value is the result of the value of <paramref name="timeSpan1"/> minus
        /// the value of <paramref name="timeSpan2"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan1"/> is null. -or-
        /// <paramref name="timeSpan2"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="timeSpan1"/> is less than <paramref name="timeSpan2"/>.</exception>
        public static MusicalTimeSpan operator -(MusicalTimeSpan timeSpan1, MusicalTimeSpan timeSpan2)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan1), timeSpan1);
            ThrowIfArgument.IsNull(nameof(timeSpan2), timeSpan2);

            long numerator1, numerator2, denominator;
            ReduceToCommonDenominator(timeSpan1, timeSpan2, out numerator1, out numerator2, out denominator);
            if (numerator1 < numerator2)
                throw new ArgumentException("First time span is less than second one.", nameof(timeSpan1));

            return new MusicalTimeSpan(numerator1 - numerator2, denominator);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="MusicalTimeSpan"/> is less than another one.
        /// </summary>
        /// <param name="timeSpan1">The first <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <param name="timeSpan2">The second <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <returns>true if the value of <paramref name="timeSpan1"/> is less than the value of
        /// <paramref name="timeSpan2"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan1"/> is null. -or-
        /// <paramref name="timeSpan2"/> is null.</exception>
        public static bool operator <(MusicalTimeSpan timeSpan1, MusicalTimeSpan timeSpan2)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan1), timeSpan1);
            ThrowIfArgument.IsNull(nameof(timeSpan2), timeSpan2);

            return timeSpan1.CompareTo(timeSpan2) < 0;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="MusicalTimeSpan"/> is greater than another one.
        /// </summary>
        /// <param name="timeSpan1">The first <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <param name="timeSpan2">The second <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <returns>true if the value of <paramref name="timeSpan1"/> is greater than the value of
        /// <paramref name="timeSpan2"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan1"/> is null. -or-
        /// <paramref name="timeSpan2"/> is null.</exception>
        public static bool operator >(MusicalTimeSpan timeSpan1, MusicalTimeSpan timeSpan2)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan1), timeSpan1);
            ThrowIfArgument.IsNull(nameof(timeSpan2), timeSpan2);

            return timeSpan1.CompareTo(timeSpan2) > 0;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="MusicalTimeSpan"/> is less than or equal to
        /// another one.
        /// </summary>
        /// <param name="timeSpan1">The first <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <param name="timeSpan2">The second <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <returns>true if the value of <paramref name="timeSpan1"/> is less than or equal to the value of
        /// <paramref name="timeSpan2"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan1"/> is null. -or-
        /// <paramref name="timeSpan2"/> is null.</exception>
        public static bool operator <=(MusicalTimeSpan timeSpan1, MusicalTimeSpan timeSpan2)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan1), timeSpan1);
            ThrowIfArgument.IsNull(nameof(timeSpan2), timeSpan2);

            return timeSpan1.CompareTo(timeSpan2) <= 0;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="MusicalTimeSpan"/> is greater than or equal to
        /// another one.
        /// </summary>
        /// <param name="timeSpan1">The first <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <param name="timeSpan2">The second <see cref="MusicalTimeSpan"/> to compare.</param>
        /// <returns>true if the value of <paramref name="timeSpan1"/> is greater than or equal to the value of
        /// <paramref name="timeSpan2"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="timeSpan1"/> is null. -or-
        /// <paramref name="timeSpan2"/> is null.</exception>
        public static bool operator >=(MusicalTimeSpan timeSpan1, MusicalTimeSpan timeSpan2)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan1), timeSpan1);
            ThrowIfArgument.IsNull(nameof(timeSpan2), timeSpan2);

            return timeSpan1.CompareTo(timeSpan2) >= 0;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as MusicalTimeSpan);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        #endregion

        #region ITimeSpan

        /// <summary>
        /// Adds a time span to the current one.
        /// </summary>
        /// <remarks>
        /// If <paramref name="timeSpan"/> and the current time span have the same type,
        /// the result time span will be of this type too; otherwise - of the <see cref="MathTimeSpan"/>.
        /// </remarks>
        /// <param name="timeSpan">Time span to add to the current one.</param>
        /// <param name="mode">Mode of the operation that defines meaning of time spans the
        /// operation will be performed on.</param>
        /// <returns>Time span that is a sum of the <paramref name="timeSpan"/> and the
        /// current time span.</returns>
        /// <exception cref="ArgumentException"><paramref name="mode"/> is invalid.</exception>
        public ITimeSpan Add(ITimeSpan timeSpan, TimeSpanMode mode)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan), timeSpan);

            var musicalTimeSpan = timeSpan as MusicalTimeSpan;
            return musicalTimeSpan != null
                ? this + musicalTimeSpan
                : TimeSpanUtilities.Add(this, timeSpan, mode);
        }

        /// <summary>
        /// Subtracts a time span from the current one.
        /// </summary>
        /// <remarks>
        /// If <paramref name="timeSpan"/> and the current time span have the same type,
        /// the result time span will be of this type too; otherwise - of the <see cref="MathTimeSpan"/>.
        /// </remarks>
        /// <param name="timeSpan">Time span to subtract from the current one.</param>
        /// <param name="mode">Mode of the operation that defines meaning of time spans the
        /// operation will be performed on.</param>
        /// <returns>Time span that is a difference between the <paramref name="timeSpan"/> and the
        /// current time span.</returns>
        public ITimeSpan Subtract(ITimeSpan timeSpan, TimeSpanMode mode)
        {
            ThrowIfArgument.IsNull(nameof(timeSpan), timeSpan);

            var musicalTimeSpan = timeSpan as MusicalTimeSpan;
            return musicalTimeSpan != null
                ? this - musicalTimeSpan
                : TimeSpanUtilities.Subtract(this, timeSpan, mode);
        }

        /// <summary>
        /// Stretches the current time span by multiplying its length by the specified multiplier.
        /// </summary>
        /// <param name="multiplier">Multiplier to stretch the time span by.</param>
        /// <returns>Time span that is the current time span stretched by the <paramref name="multiplier"/>.</returns>
        public ITimeSpan Multiply(double multiplier)
        {
            ThrowIfArgument.IsNegative(nameof(multiplier), multiplier, "Multiplier is negative.");

            return new MusicalTimeSpan(MathUtilities.RoundToLong(Numerator * MathUtilities.Round(multiplier, NumberOfDigitsAfterDecimalPoint) * FractionPartMultiplier),
                                       Denominator * FractionPartMultiplier);
        }

        /// <summary>
        /// Shrinks the current time span by dividing its length by the specified divisor.
        /// </summary>
        /// <param name="divisor">Divisor to shrink the time span by.</param>
        /// <returns>Time span that is the current time span shrinked by the <paramref name="divisor"/>.</returns>
        public ITimeSpan Divide(double divisor)
        {
            ThrowIfArgument.IsNonpositive(nameof(divisor), divisor, "Divisor is zero or negative.");

            return new MusicalTimeSpan(Numerator * FractionPartMultiplier,
                                       MathUtilities.RoundToLong(Denominator * MathUtilities.Round(divisor, NumberOfDigitsAfterDecimalPoint) * FractionPartMultiplier));
        }

        /// <summary>
        /// Clones the current time span.
        /// </summary>
        /// <returns>Copy of the current time span.</returns>
        public ITimeSpan Clone()
        {
            return new MusicalTimeSpan(Numerator, Denominator);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer
        /// that indicates whether the current instance precedes, follows, or occurs in the same
        /// position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The
        /// return value has these meanings: Value Meaning Less than zero This instance precedes obj
        /// in the sort order. Zero This instance occurs in the same position in the sort order as obj.
        /// Greater than zero This instance follows obj in the sort order.</returns>
        /// <exception cref="ArgumentException"><paramref name="obj"/> is not the same type as this instance.</exception>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                return 1;

            var musicalTimeSpan = obj as MusicalTimeSpan;
            if (ReferenceEquals(musicalTimeSpan, null))
                throw new ArgumentException("Time span is of different type.", nameof(obj));

            return CompareTo(musicalTimeSpan);
        }

        #endregion

        #region IComparable<MusicalTimeSpan>

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer
        /// that indicates whether the current instance precedes, follows, or occurs in the same
        /// position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The
        /// return value has these meanings: Value Meaning Less than zero This instance precedes other
        /// in the sort order. Zero This instance occurs in the same position in the sort order as other.
        /// Greater than zero This instance follows other in the sort order.</returns>
        public int CompareTo(MusicalTimeSpan other)
        {
            if (ReferenceEquals(other, null))
                return 1;

            long numerator1, numerator2, denominator;
            ReduceToCommonDenominator(this, other, out numerator1, out numerator2, out denominator);
            return Math.Sign(numerator1 - numerator2);
        }

        #endregion

        #region IEquatable<MusicalTimeSpan>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(MusicalTimeSpan other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (ReferenceEquals(null, other))
                return false;

            long numerator1, numerator2, denominator;
            ReduceToCommonDenominator(this, other, out numerator1, out numerator2, out denominator);
            return numerator1 == numerator2;
        }

        #endregion
    }
}
