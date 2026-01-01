namespace Smab.Helpers;

public static partial class MathsHelpers {

	extension<T>(IEnumerable<(T Start, T End)> ranges) where T : INumber<T> {
		/// <summary>
		/// Merges all overlapping or adjacent ranges in the collection into a minimal set of non-overlapping ranges.
		/// </summary>
		/// <remarks>Ranges are considered overlapping or adjacent if the start of one range is less than or equal to
		/// the end of the previous range plus one. The returned list is sorted by the start value of each range.</remarks>
		/// <returns>A list of tuples representing the merged ranges, where each tuple contains the start and end values of a
		/// non-overlapping range. The list is empty if there are no ranges to merge.</returns>
		public List<(T Start, T End)> MergeOverlapping() {
			List<(T Start, T End)> mergedRanges = [];
			foreach ((T Start, T End) currentRange in ranges.OrderBy(r => r.Start)) {
				if (mergedRanges.Count == 0) {
					mergedRanges.Add(currentRange);
					continue;
				}

				(T Start, T End) = mergedRanges[^1];
				if (currentRange.Start <= End + T.One) {
					mergedRanges[^1] = (Start, T.Max(End, currentRange.End));
				} else {
					mergedRanges.Add(currentRange);
				}
			}

			return mergedRanges;
		}
	}

	extension(IEnumerable<Range> ranges) {
		/// <summary>
		/// Merges all overlapping or adjacent ranges in the collection into distinct, non-overlapping ranges.
		/// </summary>
		/// <remarks>Ranges are merged if they overlap or are directly adjacent (i.e., the end of one range is
		/// immediately before the start of the next). The returned list is sorted by the start value of each range.</remarks>
		/// <returns>A list of merged ranges, where each range represents a contiguous block with no overlaps or gaps between them. The
		/// list is empty if there are no ranges to merge.</returns>
		public List<Range> MergeOverlapping() {
			List<Range> mergedRanges = [];
			foreach (Range currentRange in ranges.OrderBy(r => r.Start.Value)) {
				if (mergedRanges.Count == 0) {
					mergedRanges.Add(currentRange);
					continue;
				}

				Range lastRange = mergedRanges[^1];
				if (currentRange.Start.Value <= lastRange.End.Value + 1) {
					mergedRanges[^1] = new Range(lastRange.Start.Value, int.Max(lastRange.End.Value, currentRange.End.Value));
				} else {
					mergedRanges.Add(currentRange);
				}
			}

			return mergedRanges;
		}
	}

	extension(IEnumerable<LongRange> ranges) {
		/// <summary>
		/// Merges all overlapping or adjacent ranges in the collection into distinct, non-overlapping ranges.
		/// </summary>
		/// <remarks>Ranges are considered overlapping if they share any values, and adjacent if the end of one range
		/// is immediately before the start of another. The returned list is sorted by range start values.</remarks>
		/// <returns>A list of <see cref="LongRange"/> objects representing the merged, non-overlapping ranges. The list is empty if
		/// there are no ranges in the collection.</returns>
		public List<LongRange> MergeOverlapping() {
			List<LongRange> mergedRanges = [];
			foreach (LongRange range in ranges.OrderBy(r => r.Start)) {
				if (mergedRanges.Count == 0) {
					mergedRanges.Add(range);
					continue;
				}

				LongRange lastRange = mergedRanges[^1];
				if (range.Start <= lastRange.End + 1) {
					mergedRanges[^1] = new LongRange(lastRange.Start, long.Max(lastRange.End, range.End));
				} else {
					mergedRanges.Add(range);
				}
			}

			return mergedRanges;
		}
	}
}
