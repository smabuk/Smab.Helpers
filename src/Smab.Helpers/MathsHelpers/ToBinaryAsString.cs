using System.Numerics;

namespace Smab.Helpers;
public static partial class MathsHelpers {
	public static string ToBinaryAsString<T>(this T number, int minSize = 1) where T : INumber<T> {

		return number switch {
			int   num => Convert.ToString(num, 2).PadLeft(minSize, '0'),
			byte  num => Convert.ToString(num, 2).PadLeft(minSize, '0'),
			short num => Convert.ToString(num, 2).PadLeft(minSize, '0'),
			long  num => Convert.ToString(num, 2).PadLeft(minSize, '0'),
			_ => number.ToBaseAsString(2, minSize),
		};
	}
}
