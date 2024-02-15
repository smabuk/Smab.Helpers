using System.Numerics;

namespace Smab.Helpers;
public static partial class ParsingHelpers {
	public static T FromBinaryAs<T>(this string input, char zeroChar = '.', char oneChar = '#') where T : INumber<T>
		=> T.CreateChecked(T.Parse(input.Replace(zeroChar, '0').Replace(oneChar, '1'), System.Globalization.NumberStyles.BinaryNumber, null));
}
