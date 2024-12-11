using System.Numerics;

namespace Smab.Helpers;
public static partial class MathsHelpers {

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="number"></param>
	/// <param name="includeNegativeSign"></param>
	/// <returns></returns>
	public static int Length<T>(this T number) where T : INumber<T> {

		if (number is null)   { return 0; }
		if (number == T.Zero) { return 1; }

		if (number < T.One) {
			throw new ArgumentOutOfRangeException(nameof(number), $"{number} must be >= 0");
		}

		return number switch {
			int    num => (int)Math.Log10(num) + 1,
			long   num => (int)Math.Log10(num) + 1,
			uint   num => (int)Math.Log10(num) + 1,
			ulong  num => (int)Math.Log10(num) + 1,
			ushort num => (int)Math.Log10(num) + 1,
			short  num => (int)Math.Log10(num) + 1,
			byte   num => (int)Math.Log10(num) + 1,
			sbyte  num => (int)Math.Log10(num) + 1,
			_ => number.ToString()?.Length ?? 0,
		};
	}
}
