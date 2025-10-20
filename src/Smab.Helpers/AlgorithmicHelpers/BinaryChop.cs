using System.Numerics;
namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

	/// <summary>
	/// Attempts to perform a binary search within a specified range to find an element that satisfies a given predicate.
	/// </summary>
	/// <remarks>This method performs a binary search, which assumes that the range is sorted in a way that is
	/// compatible with the predicate. The search narrows the range iteratively by evaluating the predicate at the midpoint
	/// of the current range.</remarks>
	/// <typeparam name="TIterator">The type of the range boundaries, which must implement <see cref="INumber{T}"/>.</typeparam>
	/// <param name="start">The inclusive start of the range to search.</param>
	/// <param name="end">The exclusive end of the range to search.</param>
	/// <param name="predicate">A function that determines whether a given element satisfies the condition.  The function should return <see
	/// langword="true"/> for elements that meet the condition, and <see langword="false"/> otherwise.</param>
	/// <param name="result">When this method returns, contains the element that satisfies the predicate, if found; otherwise, the default value
	/// of <typeparamref name="TIterator"/>. This parameter is only guaranteed to be non-null if the method returns <see
	/// langword="true"/>.</param>
	/// <returns><see langword="true"/> if an element satisfying the predicate is found; otherwise, <see langword="false"/>.</returns>
	public static bool TryBinaryChop<TIterator>(TIterator start, TIterator end, Predicate<TIterator> predicate, [NotNullWhen(true)] out TIterator result) where TIterator : INumber<TIterator>
	{
		result = default!;
		bool found = false;

		while (start < end) {
			// Calculate the midpoint of the range
			TIterator mid = start + (end - start) / TIterator.CreateChecked(2);

			// Check if the predicate is satisfied at the midpoint
			if (predicate(mid)) {
				result = mid;
				found = true;
				end = mid; // Narrow the search to the lower half
			} else {
				start = mid + TIterator.One; // Narrow the search to the upper half
			}
		}

		if (!found && predicate(result)) {
			found = true;
		}
		
		return found;
	}

	extension(Range range) {
		/// <summary>
		/// Attempts to find an integer within the specified range that satisfies the given predicate.
		/// </summary>
		/// <remarks>The search is performed using a binary chop algorithm, which assumes that the range is continuous 
		/// and the predicate exhibits a monotonic behavior (e.g., all <see langword="false"/> values precede all  <see
		/// langword="true"/> values or vice versa).</remarks>
		/// <param name="range">The range of integers to search, defined by a start and end value.</param>
		/// <param name="predicate">A function that determines whether a given integer satisfies a condition.  The function should return <see
		/// langword="true"/> for a matching integer and <see langword="false"/> otherwise.</param>
		/// <param name="result">When this method returns <see langword="true"/>, contains the first integer in the range that satisfies the
		/// predicate. When this method returns <see langword="false"/>, the value is undefined.</param>
		/// <returns><see langword="true"/> if an integer satisfying the predicate is found within the range;  otherwise, <see
		/// langword="false"/>.</returns>
		public bool TryBinaryChop(Predicate<int> predicate, [NotNullWhen(true)] out int result)
			=> TryBinaryChop<int>(range.Start.Value, range.End.Value, predicate, out result);
	}

	extension(LongRange range) {
		/// <summary>
		/// Attempts to perform a binary search within the specified range to find a value that satisfies the given predicate.
		/// </summary>
		/// <remarks>The method performs a binary search, which assumes that the predicate returns <see
		/// langword="true"/>  for all values greater than or equal to a certain threshold and <see langword="false"/> for all
		/// values below it.</remarks>
		/// <param name="range">The range of values to search, defined by a start and an end value.</param>
		/// <param name="predicate">A function that determines whether a given value satisfies the condition.  The predicate should return <see
		/// langword="true"/> for the desired value and <see langword="false"/> otherwise.</param>
		/// <param name="result">When this method returns <see langword="true"/>, contains the value that satisfies the predicate.  If no such value
		/// is found, the value is undefined.</param>
		/// <returns><see langword="true"/> if a value satisfying the predicate is found within the range; otherwise, <see
		/// langword="false"/>.</returns>
		public bool TryBinaryChop(Predicate<long> predicate, [NotNullWhen(true)] out long result)
			=> TryBinaryChop<long>(range.Start, range.End, predicate, out result);
	}
}
