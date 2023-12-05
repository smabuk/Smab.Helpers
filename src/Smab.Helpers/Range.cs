namespace Smab.Helpers;
/// <summary>
/// Ranges are inclusive
/// </summary>
/// <param name="Start"></param>
/// <param name="End"></param>
public record Range(int Start, int End) {

	public int Length { get; } = End - Start + 1;

	public int Lower { get; } = Math.Min(Start, End);
	public int Upper { get; } = Math.Max(Start, End);

	public IEnumerable<int> Values => Enumerable.Range(Lower, Length);

	public bool TryGetOverlap(Range range, out Range overlap)
		=> TryGetOverlap(this, range, out overlap);

	public bool TryGetOverlap(int start, int end, out Range overlap)
		=> TryGetOverlap(this, new(start, end), out overlap);

	public static bool TryGetOverlap(Range range1, Range range2, out Range overlap) {
		overlap = default!;
		int range1Start = Math.Min(range1.Start, range1.End);
		int range1End   = Math.Max(range1.Start, range1.End);
		int range2Start = Math.Min(range2.Start, range2.End);
		int range2End   = Math.Max(range2.Start, range2.End);
		int max = Math.Max(range1Start, range2Start);
		int min = Math.Min(range1End,   range2End);
		if (max <= min) {
			overlap = new(max, min);
			return true;
		} else {
			return false;
		}
	}



	public Range((int Start, int End) range) : this(range.Start, range.End) { }

	public static implicit operator (int start, int end)(Range range) {
		range.Deconstruct(out int start, out int end);
		return (start, end);
	}

	public void Deconstruct(out int start, out int end) {
		start = Start;
		end = End;
	}
}

public record LongRange(long Start, long End) {

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
