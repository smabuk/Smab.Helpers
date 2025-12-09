namespace Smab.Helpers;

public static partial class LinqHelpers {
	/// <summary>
	/// Applies the specified action to the source value and returns the source value unchanged.
	/// </summary>
	/// <remarks>
	/// This extension enables side effects in a functional pipeline while preserving the original
	/// value for further operations. Useful for logging, debugging, or performing actions that
	/// don't modify the pipeline's data flow.
	/// </remarks>
	/// <typeparam name="TSource">The type of the source value.</typeparam>
	/// <param name="source">The source value to process.</param>
	/// <param name="action">The action to perform on the source value.</param>
	/// <returns>The original source value unchanged.</returns>
	public static TSource Pipe<TSource>(this TSource source, Action<TSource> action) {
		action(source);
		return source;
	}

	/// <summary>
	/// Invokes the specified action on the source object and returns the source object. This method enables fluent
	/// chaining of operations that perform side effects.
	/// </summary>
	/// <remarks>This method is useful for inserting side-effecting operations, such as logging or validation, into
	/// a fluent call chain without disrupting the chain's flow. The source object is passed to the action and then
	/// returned unchanged.</remarks>
	/// <typeparam name="TSource">The type of the source object.</typeparam>
	/// <param name="source">The object on which to perform the action. Cannot be null.</param>
	/// <param name="action">The action to invoke with the source object as its argument. Cannot be null.</param>
	public static void Also<TSource>(this TSource source, Action<TSource> action)
		=> action(source);
}
