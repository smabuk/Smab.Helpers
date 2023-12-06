namespace Smab.Helpers;

public static class RangeHelpers {

	public static bool TryGetOverlap(this Range thisRange, Range range, out Range overlap) {
		overlap = default!; 
		int range1Start = Math.Min(thisRange.Start.Value, thisRange.End.Value);
		int range1End   = Math.Max(thisRange.Start.Value, thisRange.End.Value);
		int range2Start = Math.Min(range.Start.Value, range.End.Value);
		int range2End   = Math.Max(range.Start.Value, range.End.Value);
		int max = Math.Max(range1Start, range2Start);
		int min = Math.Min(range1End, range2End);
		if (max <= min) {
			overlap = new(max, min);
			return true;
		} else {
			return false;
		}
	}

	public static Range GetOverlap(this Range thisRange, Range range) {
		int range1Start = Math.Min(thisRange.Start.Value, thisRange.End.Value);
		int range1End   = Math.Max(thisRange.Start.Value, thisRange.End.Value);
		int range2Start = Math.Min(range.Start.Value, range.End.Value);
		int range2End   = Math.Max(range.Start.Value, range.End.Value);
		int max = Math.Max(range1Start, range2Start);
		int min = Math.Min(range1End, range2End);
		if (max <= min) {
			return new(max, min);
		} else {
			throw new ArgumentOutOfRangeException(nameof(range), "Ranges do not overlap.");
		}
	}
}

public record struct LongRange(long Start, long End) {

	public long Length { get; } = End - Start + 1;

	public long Lower { get; } = Math.Min(Start, End);
	public long Upper { get; } = Math.Max(Start, End);

	public IEnumerable<long> Values {
		get {
			for (long l = Lower; l <= Upper; l++) {
				yield return l;
			}
		}
	}

	public bool TryGetOverlap(LongRange range, out LongRange overlap)
		=> TryGetOverlap(this, range, out overlap);

	public bool TryGetOverlap(long start, long end, out LongRange overlap)
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

	public void Deconstruct(out long start, out long end) {
		start = Start;
		end = End;
	}

}
