using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {

	/// <summary>
	/// Attempts to determine the overlapping range between two specified ranges.
	/// </summary>
	/// <remarks>The method normalizes the input ranges by ensuring that the <see langword="Start"/> value is less
	/// than or equal to the <see langword="End"/> value for each range before calculating the overlap. If the ranges do
	/// not overlap, the <paramref name="overlap"/> parameter will be set to its default value.</remarks>
	/// <typeparam name="T">The type of the range boundaries. Must implement <see cref="INumber{T}"/>.</typeparam>
	/// <param name="range">The first range, represented as a tuple with <see langword="Start"/> and <see langword="End"/> values.</param>
	/// <param name="range2">The second range, represented as a tuple with <see langword="Start"/> and <see langword="End"/> values.</param>
	/// <param name="overlap">When this method returns, contains the overlapping range as a tuple with <see langword="Start"/> and <see
	/// langword="End"/> values, if an overlap exists; otherwise, contains the default value for the tuple type.</param>
	/// <returns><see langword="true"/> if the two ranges overlap; otherwise, <see langword="false"/>.</returns>
	public static bool TryGetOverlap<T>(this (T Start, T End) range, (T Start, T End) range2, out (T Start, T End) overlap) where T : INumber<T> {
		overlap = default!;
		T range1Start = T.Min(range.Start, range.End);
		T range1End   = T.Max(range.Start, range.End);
		T range2Start = T.Min(range2.Start, range2.End);
		T range2End   = T.Max(range2.Start, range2.End);
		T max = T.Max(range1Start, range2Start);
		T min = T.Min(range1End, range2End);
		if (max <= min) {
			overlap = (max, min);
			return true;
		} else {
			return false;
		}
	}

	/// <summary>
	/// Determines the overlapping range between two specified ranges.
	/// </summary>
	/// <remarks>The method normalizes the input ranges to ensure that the <c>Start</c> boundary is less than or
	/// equal to the <c>End</c> boundary before calculating the overlap. If the ranges do not overlap, an exception is
	/// thrown.</remarks>
	/// <typeparam name="T">The type of the range boundaries. Must implement <see cref="INumber{T}"/>.</typeparam>
	/// <param name="range">The first range, represented as a tuple where <c>Start</c> is the starting boundary and <c>End</c> is the ending
	/// boundary.</param>
	/// <param name="range2">The second range, represented as a tuple where <c>Start</c> is the starting boundary and <c>End</c> is the ending
	/// boundary.</param>
	/// <returns>A tuple representing the overlapping range, where <c>Start</c> is the starting boundary and <c>End</c> is the
	/// ending boundary.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown if the specified ranges do not overlap.</exception>
	public static (T Start, T End) GetOverlap<T>(this (T Start, T End) range, (T Start, T End) range2) where T : INumber<T> {
		T range1Start = T.Min(range.Start, range.End);
		T range1End   = T.Max(range.Start, range.End);
		T range2Start = T.Min(range2.Start, range2.End);
		T range2End   = T.Max(range2.Start, range2.End);
		T max = T.Max(range1Start, range2Start);
		T min = T.Min(range1End, range2End);
		if (max <= min) {
			return (max, min);
		} else {
			throw new ArgumentOutOfRangeException(nameof(range), "Ranges do not overlap.");
		}
	}

	/// <summary>
	/// Attempts to calculate the overlapping range between the current range and the specified range.
	/// </summary>
	/// <remarks>The method determines whether the two ranges intersect and, if so, calculates the overlapping
	/// portion. If no overlap exists, the <paramref name="overlap"/> parameter will be set to its default value.</remarks>
	/// <param name="range">The first range to evaluate for overlap.</param>
	/// <param name="range2">The second range to evaluate for overlap.</param>
	/// <param name="overlap">When this method returns, contains the overlapping range if an overlap exists; otherwise, contains the default
	/// value of <see cref="Range"/>.</param>
	/// <returns><see langword="true"/> if the two ranges overlap; otherwise, <see langword="false"/>.</returns>
	public static bool TryGetOverlap(this Range range, Range range2, out Range overlap) {
		overlap = default!;
		bool success =  TryGetOverlap((range.Start.Value, range.End.Value), (range2.Start.Value, range2.End.Value), out (int Start, int End) overlap2);
		if (success) {
			overlap = new(overlap2.Start, overlap2.End);
		}
		return success;
	}

	/// <summary>
	/// Determines the overlapping range between the current range and the specified range.
	/// </summary>
	/// <remarks>This method calculates the intersection of two ranges. If the ranges do not overlap,  an <see
	/// cref="ArgumentOutOfRangeException"/> is thrown.</remarks>
	/// <param name="range">The first range to compare.</param>
	/// <param name="range2">The second range to compare.</param>
	/// <returns>A <see cref="Range"/> representing the overlapping portion of the two ranges.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown if the two ranges do not overlap.</exception>
	public static Range GetOverlap(this Range range, Range range2) {
		bool success =  TryGetOverlap((range.Start.Value, range.End.Value), (range2.Start.Value, range2.End.Value), out (int Start, int End) overlap2);
		if (success) {
			return new(overlap2.Start, overlap2.End);
		} else {
			throw new ArgumentOutOfRangeException(nameof(range), "Ranges do not overlap.");
		}
	}
}

/// <summary>
/// Represents a range of 64-bit signed integers with a defined start and end.
/// </summary>
/// <remarks>The <see cref="LongRange"/> type provides properties and methods to work with ranges of integers,
/// including calculating the range's length, determining its bounds, enumerating its values, and finding overlaps with
/// other ranges. The range is inclusive of both the start and end values.</remarks>
/// <param name="Start"></param>
/// <param name="End"></param>
public record struct LongRange(long Start, long End) {

	public long Length { get; } = End - Start + 1;

	public long Lower { get; } = Math.Min(Start, End);
	public long Upper { get; } = Math.Max(Start, End);

	public readonly IEnumerable<long> Values {
		get {
			for (long l = Lower; l <= Upper; l++) {
				yield return l;
			}
		}
	}

	/// <summary>
	/// Attempts to determine the overlapping range between the current range and the specified range.
	/// </summary>
	/// <param name="range">The range to check for overlap with the current range.</param>
	/// <param name="overlap">When this method returns, contains the overlapping range if an overlap exists;  otherwise, contains an
	/// uninitialized <see cref="LongRange"/> value.</param>
	/// <returns><see langword="true"/> if the specified range overlaps with the current range;  otherwise, <see langword="false"/>.</returns>
	public readonly bool TryGetOverlap(LongRange range, out LongRange overlap)
		=> TryGetOverlap(this, range, out overlap);

	/// <summary>
	/// Attempts to determine the overlap between the current range and the specified range.
	/// </summary>
	/// <param name="start">The starting value of the range to check for overlap.</param>
	/// <param name="end">The ending value of the range to check for overlap.</param>
	/// <param name="overlap">When this method returns, contains the overlapping range, if an overlap exists; otherwise, contains an
	/// uninitialized <see cref="LongRange"/> value.</param>
	/// <returns><see langword="true"/> if an overlap exists between the current range and the specified range; otherwise, <see
	/// langword="false"/>.</returns>
	public readonly bool TryGetOverlap(long start, long end, out LongRange overlap)
		=> TryGetOverlap(this, new(start, end), out overlap);

	/// <summary>
	/// Attempts to determine the overlapping range between two <see cref="LongRange"/> instances.
	/// </summary>
	/// <remarks>This method normalizes the start and end values of the input ranges before evaluating the overlap.
	/// If the ranges do not overlap, the <paramref name="overlap"/> parameter will be set to its default value.</remarks>
	/// <param name="range1">The first range to evaluate. The start and end values do not need to be ordered.</param>
	/// <param name="range2">The second range to evaluate. The start and end values do not need to be ordered.</param>
	/// <param name="overlap">When this method returns, contains the overlapping range between <paramref name="range1"/> and  <paramref
	/// name="range2"/>, if an overlap exists; otherwise, the default value of <see cref="LongRange"/>.</param>
	/// <returns><see langword="true"/> if the two ranges overlap; otherwise, <see langword="false"/>.</returns>
	public static bool TryGetOverlap(LongRange range1, LongRange range2, out LongRange overlap) {
		overlap = default!;
		long range1Start = Math.Min(range1.Start, range1.End);
		long range1End   = Math.Max(range1.Start, range1.End);
		long range2Start = Math.Min(range2.Start, range2.End);
		long range2End   = Math.Max(range2.Start, range2.End);
		long max = Math.Max(range1Start, range2Start);
		long min = Math.Min(range1End,   range2End);
		if (max <= min) {
			overlap = new(max, min);
			return true;
		} else {
			return false;
		}
	}

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
