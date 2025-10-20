using System.Numerics;
using System.Text.RegularExpressions;

namespace Smab.Helpers;

public static partial class ParsingHelpers {

	extension(Match match) {
		/// <summary>
		/// Retrieves the value of a named capturing group from the specified regular expression match.
		/// </summary>
		/// <param name="match">The <see cref="Match"/> instance containing the regular expression match data.</param>
		/// <param name="groupName">The name of the capturing group whose value is to be retrieved.</param>
		/// <returns>The value of the specified capturing group. Returns an empty string if the group is not matched or does not exist.</returns>
		public string As(string groupName)
			=> match.Groups[groupName].Value;

		/// <summary>
		/// Retrieves the value of the capturing group at the specified index from the match.
		/// </summary>
		/// <param name="match">The <see cref="Match"/> instance containing the capturing groups.</param>
		/// <param name="index">The zero-based index of the capturing group to retrieve.</param>
		/// <returns>The value of the capturing group at the specified index. Returns an empty string if the group is not matched.</returns>
		public string As(int index)
			=> match.Groups[index].Value;

		/// <summary>
		/// Converts the value of the specified <see cref="Match"/> to the specified numeric type.
		/// </summary>
		/// <typeparam name="T">The numeric type to convert the value to. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="match">The <see cref="Match"/> whose value is to be converted.</param>
		/// <returns>The parsed value of type <typeparamref name="T"/>.</returns>
		/// <exception cref="InvalidCastException">Thrown if the value of <paramref name="match"/> cannot be parsed as a valid <typeparamref name="T"/>.</exception>
		public T As<T>() where T : INumber<T>
			=> T.TryParse(match.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() };

		/// <summary>
		/// Converts the value of the specified regex group to the specified numeric type.
		/// </summary>
		/// <typeparam name="T">The numeric type to which the group value should be converted. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="match">The <see cref="Match"/> object containing the group to convert. Cannot be <see langword="null"/>.</param>
		/// <param name="groupName">The name of the group within the match whose value will be converted. Cannot be <see langword="null"/> or empty.</param>
		/// <param name="defaultIfInvalid">The value to return if the group value cannot be successfully converted. Defaults to <see cref="T.Zero"/> if not
		/// specified.</param>
		/// <returns>The converted value of the group if the conversion is successful; otherwise, <paramref name="defaultIfInvalid"/> or
		/// <see cref="T.Zero"/>.</returns>
		public T As<T>(string groupName, T? defaultIfInvalid = default) where T : INumber<T>
			=> T.TryParse(match.Groups[groupName].Value, null, out T? value) switch { true => value, false => defaultIfInvalid ?? T.Zero };

		/// <summary>
		/// Converts the value of the specified match group to the specified numeric type.
		/// </summary>
		/// <typeparam name="T">The numeric type to convert the match group value to. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="match">The regular expression match containing the group to convert.</param>
		/// <param name="index">The zero-based index of the group within the match to convert.</param>
		/// <param name="defaultIfInvalid">The value to return if the group value cannot be converted to the specified type. Defaults to <see
		/// langword="default"/> for the type.</param>
		/// <returns>The converted value of the match group as the specified numeric type, or <paramref name="defaultIfInvalid"/> if the
		/// conversion fails.</returns>
		public T As<T>(int index, T? defaultIfInvalid = default) where T : INumber<T>
			=> T.TryParse(match.Groups[index].Value, null, out T? value) switch { true => value, false => defaultIfInvalid ?? T.Zero };
	}

	extension(MatchCollection matches) {
		/// <summary>
		/// Converts a <see cref="MatchCollection"/> to an <see cref="IEnumerable{T}"/> of the specified numeric type.
		/// </summary>
		/// <remarks>This method attempts to parse each match value into the specified numeric type <typeparamref
		/// name="T"/>. If parsing fails for any match, an <see cref="InvalidCastException"/> is thrown.</remarks>
		/// <typeparam name="T">The numeric type to which the match values will be converted. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="matches">The collection of regular expression matches to convert.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the parsed numeric values from the match collection.</returns>
		/// <exception cref="InvalidCastException">Thrown if any match value cannot be parsed into the specified numeric type <typeparamref name="T"/>.</exception>
		public IEnumerable<T> As<T>() where T : INumber<T>
			=> matches.Select(match => T.TryParse(match.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() });
	}

	extension(GroupCollection groups) {
		/// <summary>
		/// Converts the values in the specified <see cref="GroupCollection"/> to a sequence of the specified numeric type.
		/// </summary>
		/// <typeparam name="T">The numeric type to which the group values will be converted. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="groups">The <see cref="GroupCollection"/> containing the values to convert.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the converted numeric values.</returns>
		/// <exception cref="InvalidCastException">Thrown if any value in the <paramref name="groups"/> cannot be parsed as the specified numeric type <typeparamref
		/// name="T"/>.</exception>
		public IEnumerable<T> As<T>() where T : INumber<T>
			=> groups.Values.Select(group => T.TryParse(group.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() });
	}
}
