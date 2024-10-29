namespace Smab.Helpers;

public static class ArgumentHelpers {

	public static T GetArgument<T>(object[]? args, int argumentNumber, T defaultResult) {
		int i = argumentNumber - 1;
		// Learnt this Bounds Check micro-optimisation from Stephen Toub's deep dives into Linq
		//   (uint)i < (uint)length
		// Removes the need to check for < 0 and means the compiler doesn't need to recheck when calculating args[i]
		return args is not null && (uint)i < (uint)args.Length && args[i] is T resultT
			? resultT
			: defaultResult;
	}

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
