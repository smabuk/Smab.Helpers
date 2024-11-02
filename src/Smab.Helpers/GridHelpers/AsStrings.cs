namespace Smab.Helpers;

public static partial class ArrayHelpers {

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <param name="replacements"></param>
	/// <returns></returns>
	public static IEnumerable<string> AsStrings<T>(this T[,] array, params IEnumerable<(string, string)> replacements) where T : struct {
		StringBuilder line = new();
		for (int r = 0; r <= array.GetUpperBound(ROW_DIMENSION); r++) {
			line.Clear();
			for (int c = 0; c <= array.GetUpperBound(COL_DIMENSION); c++) {
				string cell = array[c, r].ToString() ?? "";
				line.Append(cell);
			}
			if (replacements is not null) {
				foreach ((string from, string to) in replacements) {
					line = line.Replace(from, to);
				}
			}
			yield return line.ToString();
		}
	}

	public static string AsStringWithNewLines<T>(this T[,] array, params IEnumerable<(string, string)> replacements) where T : struct
		=> string.Join(Environment.NewLine, AsStrings(array, replacements));

	public static string AsString<T>(this T[,] array, string? separator = null, params IEnumerable<(string, string)> replacements) where T : struct
		=> string.Join("", AsStrings(array, replacements));
}
