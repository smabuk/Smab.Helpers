namespace Smab.Helpers;

public static partial class LinqHelpers {
	extension<T>(T value) {
		/// <summary>
		/// Determines whether the specified value exists in the provided collection.
		/// </summary>
		/// <typeparam name="T">The type of the value and the elements in the collection.</typeparam>
		/// <param name="value">The value to locate in the collection.</param>
		/// <param name="values">The collection of values to search.</param>
		/// <returns><see langword="true"/> if the specified value is found in the collection; otherwise, <see langword="false"/>.</returns>
		public bool IsIn(IEnumerable<T> values) => values.Contains(value);
	}
}
