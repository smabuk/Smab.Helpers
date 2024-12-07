using System.Numerics;

namespace Smab.Helpers;
public static partial class MathsHelpers {
	public static string ToBaseAsString<T>(this T number, int baseNumber, int minSize = 1) where T : INumber<T> {
		if (number == T.Zero) { return "0".PadLeft(minSize, '0'); }

		T divisor = T.CreateChecked(baseNumber);

		string result = "";
		while (number > T.Zero) {
			T remainder =  number % divisor;
			result = remainder + result;
			number /= divisor;
		}

		return result.PadLeft(minSize, '0');
	}
}
