namespace Smab.Helpers;
public static partial class ParsingHelpers {

	public static T AsEnum<T>(this ReadOnlySpan<char> s) where T : struct => Enum.Parse<T>(s, true);
	public static T AsEnum<T>(this string s) where T : struct => Enum.Parse<T>(s, true);
	
	public static T AsEnumOrDefault<T>(this ReadOnlySpan<char> s, T TDefault = default) where T : struct => 
		Enum.TryParse<T>(s, true, out T result)
		? result
		: TDefault;

	public static T AsEnumOrDefault<T>(this string s, T TDefault = default) where T : struct => 
		Enum.TryParse<T>(s, true, out T result)
		? result
		: TDefault;
}
