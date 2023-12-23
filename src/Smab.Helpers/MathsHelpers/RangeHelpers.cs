using System.Numerics;

namespace Smab.Helpers;

public static class RangeHelpers {

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

	public static bool TryGetOverlap(this Range range, Range range2, out Range overlap) {
		overlap = default!;
		bool success =  TryGetOverlap((range.Start.Value, range.End.Value), (range2.Start.Value, range2.End.Value), out (int Start, int End) overlap2);
		if (success) {
			overlap = new(overlap2.Start, overlap2.End);
		}
		return success;
	}

	public static Range GetOverlap(this Range range, Range range2) {
		bool success =  TryGetOverlap((range.Start.Value, range.End.Value), (range2.Start.Value, range2.End.Value), out (int Start, int End) overlap2);
		if (success) {
			return new(overlap2.Start, overlap2.End);
		} else {
			throw new ArgumentOutOfRangeException(nameof(range), "Ranges do not overlap.");
		}
	}
}

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

	public readonly bool TryGetOverlap(LongRange range, out LongRange overlap)
		=> TryGetOverlap(this, range, out overlap);

	public readonly bool TryGetOverlap(long start, long end, out LongRange overlap)
		=> TryGetOverlap(this, new(start, end), out overlap);

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
