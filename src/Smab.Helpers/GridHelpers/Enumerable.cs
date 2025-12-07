namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Returns an enumerable collection of all values in the grid.
		/// </summary>
		/// <returns>An enumerable collection of all elements in the grid in row-major order.</returns>
		public IEnumerable<T> Values() {
			foreach (T value in grid.Cells) {
				yield return value;
			}
		}
	}
}

