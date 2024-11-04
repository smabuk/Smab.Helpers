using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {
	public static bool IsEven<T>    (this T value) where T : INumber<T> => T.IsEvenInteger(value);
	public static bool IsOdd<T>     (this T value) where T : INumber<T> => T.IsOddInteger(value);
	public static bool IsInteger<T> (this T value) where T : INumber<T> => T.IsInteger(value);
	public static bool IsNaN<T>     (this T value) where T : INumber<T> => T.IsNaN(value);
	public static bool IsNegative<T>(this T value) where T : INumber<T> => T.IsNegative(value);
	public static bool IsPositive<T>(this T value) where T : INumber<T> => T.IsPositive(value);
	public static bool IsZero<T>    (this T value) where T : INumber<T> => T.IsZero(value);
}
