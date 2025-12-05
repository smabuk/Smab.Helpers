using System;
using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {

	extension<T>((T Start, T End) range) where T : INumber<T> {
		/// <summary>
		/// Attempts to merge the current range with the specified range if they overlap or are adjacent.
		/// </summary>
		/// <remarks>Ranges are considered mergeable if they overlap or are directly adjacent. The merged range will
		/// span from the minimum start to the maximum end of the two ranges.</remarks>
		/// <param name="range2">A tuple representing the start and end values of the range to merge with the current range.</param>
		/// <param name="mergedRange">When this method returns, contains the merged range if the ranges overlap or are adjacent; otherwise, contains the
		/// default value.</param>
		/// <returns>true if the ranges were successfully merged; otherwise, false.</returns>
		public bool TryMerge((T Start, T End) range2, [NotNullWhen(true)] out (T Start, T End) mergedRange) {
			mergedRange = default!;
			T rangeLower = T.Min(range.Start, range.End);
			T rangeUpper = T.Max(range.Start, range.End);
			T range2Lower = T.Min(range2.Start, range2.End);
			T range2Upper = T.Max(range2.Start, range2.End);
			if (range.TryGetOverlap(range2, out (T Start, T End) _) || rangeUpper + T.One == range2Lower || range2Upper + T.One == rangeLower) {
				mergedRange = new (T.Min(rangeLower, range2Lower), T.Max(rangeUpper, range2Upper));
				return true;
			} else {
				return false;
			}
		}
	}

	extension(Range range) {
		/// <summary>
		/// Attempts to merge the current range with the specified range if they overlap or are adjacent.
		/// </summary>
		/// <remarks>Ranges are considered mergeable if they overlap or if one range ends immediately before the other
		/// begins. The merged range will span from the lowest start value to the highest end value of the two
		/// ranges.</remarks>
		/// <param name="range2">The range to attempt to merge with the current range.</param>
		/// <param name="mergedRange">When this method returns <see langword="true"/>, contains the merged range that encompasses both ranges;
		/// otherwise, contains the default value.</param>
		/// <returns><see langword="true"/> if the ranges overlap or are adjacent and can be merged; otherwise, <see
		/// langword="false"/>.</returns>
		public bool TryMerge(Range range2, [NotNullWhen(true)] out Range mergedRange) {
			mergedRange = default!;
			int rangeLower  = int.Min(range.Start.Value, range.End.Value);
			int rangeUpper  = int.Max(range.Start.Value, range.End.Value);
			int range2Lower = int.Min(range2.Start.Value, range2.End.Value);
			int range2Upper = int.Max(range2.Start.Value, range2.End.Value);
			if (range.TryGetOverlap(range2, out Range _) || rangeUpper + 1 == range2Lower || range2Upper + 1 == rangeLower) {
				mergedRange = new Range(int.Min(rangeLower, range2Lower), int.Max(rangeUpper, range2Upper));
				return true;
			} else {
				return false;
			}
		}
	}

	extension(LongRange range) {
		/// <summary>
		/// Attempts to merge the current range with the specified range if they overlap or are adjacent.
		/// </summary>
		/// <remarks>Ranges are considered mergeable if they overlap or are directly adjacent. If the merge is
		/// successful, the resulting range encompasses both input ranges.</remarks>
		/// <param name="otherRange">The range to attempt to merge with the current range. Must not be null.</param>
		/// <param name="mergedRange">When this method returns, contains the merged range if the operation succeeds; otherwise, contains the default
		/// value.</param>
		/// <returns>true if the ranges were successfully merged; otherwise, false.</returns>
		public bool TryMerge(LongRange otherRange, [NotNullWhen(true)] out LongRange mergedRange) {
			mergedRange = default!;
			if (range.TryGetOverlap(otherRange, out LongRange _) || range.End + 1 == otherRange.Start || otherRange.End + 1 == range.Start) {
				mergedRange = new LongRange(long.Min(range.Start, otherRange.Start), long.Max(range.End, otherRange.End));
				return true;
			} else {
				return false;
			}
		}
	}
}
