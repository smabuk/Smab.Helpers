namespace Smab.Helpers;

public static partial class LinqHelpers {
	extension<T>(IEnumerable<T> items) {
		/// <summary>
		/// Executes the specified action on each element of the <see cref="IEnumerable{T}"/>.
		/// </summary>
		/// <remarks>This method iterates through the collection and invokes the specified action for each
		/// element.</remarks>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="items">The collection of elements to iterate over. Cannot be <see langword="null"/>.</param>
		/// <param name="action">The action to perform on each element. Cannot be <see langword="null"/>.</param>
		public void ForEach(Action<T> action) {
			foreach (T? item in items) {
				action(item);
			}
		}

		/// <summary>
		/// Executes the specified action on each element of the collection and yields the elements back to the caller.
		/// </summary>
		/// <remarks>This method allows you to perform an action on each element of the collection while continuing to
		/// use the collection in a deferred execution manner. The action is executed as the elements are enumerated.</remarks>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="items">The collection of elements to iterate over. Cannot be <see langword="null"/>.</param>
		/// <param name="action">The action to perform on each element. Cannot be <see langword="null"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> that yields the elements of the original collection in the same order.</returns>
		public IEnumerable<T> ForEachContinue(Action<T> action) {
			foreach (T? item in items) {
				action(item);
				yield return item;
			}
		}

		/// <summary>
		/// Applies the specified function to each element in the sequence and returns a sequence of the results.
		/// </summary>
		/// <remarks>This method uses deferred execution. The function is not applied until the resulting sequence is
		/// enumerated.</remarks>
		/// <typeparam name="T">The type of the elements in the input sequence.</typeparam>
		/// <typeparam name="TResult">The type of the elements in the resulting sequence.</typeparam>
		/// <param name="items">The sequence of elements to process. Cannot be <see langword="null"/>.</param>
		/// <param name="action">A function to apply to each element in the sequence. Cannot be <see langword="null"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the results of applying the function to each element in the input
		/// sequence.</returns>
		public IEnumerable<TResult> ForEach<TResult>(Func<T, TResult> action) {
			foreach (T? item in items) {
				yield return action(item);
			}
		}
	}
}
