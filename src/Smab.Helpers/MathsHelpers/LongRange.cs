namespace Smab.Helpers;

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
