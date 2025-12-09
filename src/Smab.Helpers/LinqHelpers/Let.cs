namespace Smab.Helpers;

public static partial class LinqHelpers {
	extension<TSource>(TSource source) {
		/// <summary>
		/// Applies the specified function to the source value and returns the result.
		/// </summary>
		/// <remarks>
		/// This extension enables functional composition by allowing a value to be passed through
		/// a transformation function. Useful for creating inline scopes and maintaining immutability
		/// in expression-based code.
		/// </remarks>
		/// <typeparam name="TSource">The type of the source value.</typeparam>
		/// <typeparam name="TResult">The type of the result value.</typeparam>
		/// <param name="source">The source value to transform.</param>
		/// <param name="func">The transformation function to apply.</param>
		/// <returns>The result of applying the transformation function to the source value.</returns>
		public TResult Let<TResult>(Func<TSource, TResult> func)
			=> func(source);
	}

	extension<TSource>(TSource? source) where TSource : class {
		/// <summary>
		/// Applies the specified function to the source value and returns the result, or a default value if the source is null.
		/// </summary>
		/// <remarks>
		/// This extension enables functional composition by allowing a value to be passed through
		/// a transformation function. Useful for creating inline scopes and maintaining immutability
		/// in expression-based code.
		/// </remarks>
		/// <typeparam name="TSource">The type of the source value.</typeparam>
		/// <typeparam name="TResult">The type of the result value.</typeparam>
		/// <param name="source">The source value to transform.</param>
		/// <param name="func">The transformation function to apply.</param>
		/// <returns>
		/// The result of applying the transformation function to the source value,
		/// or the default value for the result type if the source value is null.
		/// </returns>
		public TResult? LetOrDefault<TResult>(Func<TSource, TResult> func)
			=> source is not null ? func(source) : default;

		/// <summary>
		/// Applies the specified function to the source value and returns the result, or a specified default value if the source is null.
		/// </summary>
		/// <remarks>
		/// This extension enables functional composition by allowing a value to be passed through
		/// a transformation function with a custom fallback value. Useful for creating inline scopes
		/// and maintaining immutability in expression-based code while providing meaningful defaults.
		/// </remarks>
		/// <typeparam name="TSource">The type of the source value.</typeparam>
		/// <typeparam name="TResult">The type of the result value.</typeparam>
		/// <param name="source">The source value to transform.</param>
		/// <param name="func">The transformation function to apply.</param>
		/// <param name="defaultValue">The value to return if the source is null.</param>
		/// <returns>
		/// The result of applying the transformation function to the source value,
		/// or the specified default value if the source value is null.
		/// </returns>
		public TResult LetOrDefault<TResult>(Func<TSource, TResult> func, TResult defaultValue)
			=> source is not null ? func(source) : defaultValue;
	}
}
