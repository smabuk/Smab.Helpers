namespace Smab.Helpers;

public static class ArgumentHelpers {

	/// <summary>
	/// Retrieves an argument from the specified array at the given position, or returns a default value if the argument is
	/// not present or cannot be cast to the specified type.
	/// </summary>
	/// <remarks>This method uses a 1-based index for <paramref name="argumentNumber"/>. If <paramref name="args"/>
	/// is <see langword="null"/> or does not contain an argument at the specified position, or if the argument cannot be
	/// cast to type <typeparamref name="T"/>, the <paramref name="defaultResult"/> is returned.</remarks>
	/// <typeparam name="T">The expected type of the argument to retrieve.</typeparam>
	/// <param name="args">An array of arguments. Can be <see langword="null"/>.</param>
	/// <param name="argumentNumber">The 1-based index of the argument to retrieve.</param>
	/// <param name="defaultResult">The value to return if the argument is not present or cannot be cast to type <typeparamref name="T"/>.</param>
	/// <returns>The argument at the specified position, cast to type <typeparamref name="T"/>, if it exists and is of the correct
	/// type; otherwise, <paramref name="defaultResult"/>.</returns>
	public static T GetArgument<T>(object[]? args, int argumentNumber, T defaultResult) {
		int i = argumentNumber - 1;
		// Learnt this Bounds Check micro-optimisation from Stephen Toub's deep dives into Linq
		//   (uint)i < (uint)length
		// Removes the need to check for < 0 and means the compiler doesn't need to recheck when calculating args[i]
		return args is not null && (uint)i < (uint)args.Length && args[i] is T resultT
			? resultT
			: defaultResult;
	}

	/// <summary>
	/// Retrieves the argument at the specified position from the provided array and casts it to the specified type.
	/// </summary>
	/// <remarks>The method uses a 1-based index for <paramref name="argumentNumber"/>. If the specified argument is
	/// not of type  <typeparamref name="T"/>, an <see cref="ArgumentOutOfRangeException"/> is thrown.</remarks>
	/// <typeparam name="T">The expected type of the argument to retrieve.</typeparam>
	/// <param name="args">An array of arguments. This cannot be <see langword="null"/>.</param>
	/// <param name="argumentNumber">The 1-based position of the argument to retrieve.</param>
	/// <returns>The argument at the specified position, cast to type <typeparamref name="T"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="argumentNumber"/> is less than 1, greater than the number of elements in <paramref
	/// name="args"/>,  or if the argument at the specified position cannot be cast to type <typeparamref name="T"/>.</exception>
	public static T GetArgument<T>(object[]? args, int argumentNumber) {
		ArgumentNullException.ThrowIfNull(args);

		int i = argumentNumber - 1;
		// Learnt this Bounds Check micro-optimisation from Stephen Toub's deep dives into Linq
		//   (uint)i < (uint)length
		// Removes the need to check for < 0 and means the compiler doesn't need to recheck when calculating args[i]
		return (uint)i < (uint)args.Length && args[i] is T resultT
			? resultT
			: throw new ArgumentOutOfRangeException($"{nameof(GetArgument)}: Requested argument {argumentNumber} from {args.Length} arguments.");
	}
}
