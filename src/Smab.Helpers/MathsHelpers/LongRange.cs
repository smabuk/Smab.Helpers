namespace Smab.Helpers;

/// <summary>
/// Represents an inclusive range of 64-bit integer values, defined by a start and end point.
/// </summary>
/// <remarks>The range includes both the start and end values. The struct can be deconstructed into its start and
/// end components, and supports implicit conversion to a tuple for convenient usage in tuple-based APIs.</remarks>
/// <param name="Start">The first value of the range, inclusive.</param>
/// <param name="End">The last value of the range, inclusive.</param>
public record struct LongRange(long Start, long End) {
	public LongRange((long Start, long End) range) : this(range.Start, range.End) { }

	public static implicit operator (long start, long end)(LongRange range) {
		range.Deconstruct(out long start, out long end);
		return (start, end);
	}

	public readonly void Deconstruct(out long start, out long end) {
		start = Start;
		end = End;
	}
}

public static partial class LongRangeExtensions {
	extension(LongRange range) {
		/// <summary>
		/// Gets the total number of elements in the range.
		/// </summary>
		public long Length => range.Upper - range.Lower + 1;

		/// <summary>
		/// Gets the lower bound of the range as a 64-bit signed integer.
		/// </summary>
		public long Lower => long.Min(range.Start, range.End);

		/// <summary>
		/// Gets the upper bound of the range represented by this instance.
		/// </summary>
		public long Upper => long.Max(range.Start, range.End);

		/// <summary>
		/// Gets an enumerable collection of all long values within the specified range, inclusive of the lower and upper
		/// bounds.
		/// </summary>
		public IEnumerable<long> Values => Enumerable.Sequence(range.Lower, range.Upper, 1);
	}
}
