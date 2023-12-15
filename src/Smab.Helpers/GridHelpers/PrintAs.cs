namespace Smab.Helpers;

public static partial class ArrayHelpers {

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <param name="width">If -1 then no spaces. If 0 then 1 padded space, otherwise the width of columns required</param>
	/// <returns></returns>
	public static IEnumerable<string> PrintAsStringArray<T>(this T[,] array, int width = 0, (string, string)[]? replacements = null) where T : struct {
		StringBuilder line = new();
		for (int r = 0; r <= array.GetUpperBound(ROW_DIMENSION); r++) {
			line.Clear();
			for (int c = 0; c <= array.GetUpperBound(COL_DIMENSION); c++) {
				string cell = array[c, r].ToString() ?? "";
				line.Append(width switch {
					0 => cell,
					_ => $"{new string(' ', (width - cell.Length))}{cell}",
				});
			}
			if (replacements is not null) {
				foreach ((string from, string to) in replacements) {
					line = line.Replace(from, to);
				}
			}
			yield return line.ToString();
		}
	}

	public static List<string> PrintAsStringList<T>(this T[,] array, int width = 0, (string, string)[]? replacements = null) where T : struct
		=> [.. PrintAsStringArray(array, width, replacements)];


	public static string PrintAsString<T>(this T[,] array, int width = 0, (string, string)[]? replacements = null) where T : struct
		=> string.Join(Environment.NewLine, PrintAsStringArray(array, width, replacements));
}
