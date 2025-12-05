
namespace Smab.Helpers;

/// <summary>
/// This represents a string that is incapable of holding an empty string or one consisting purely of whitespace
/// </summary>
/// <param name="Value"></param>
/// <exception cref="ArgumentNullException"></exception>
public readonly record struct NonEmptyString(string Value) : IParsable<NonEmptyString> {
	public string Value { get; init; } =
		!string.IsNullOrWhiteSpace(Value)
		? Value.Trim()
		: throw new ArgumentNullException("Value cannot be null or white space", nameof(Value));

	public NonEmptyString() : this(string.Empty) { }

	public static implicit operator string(NonEmptyString value) => value.Value;
	public static implicit operator NonEmptyString(string value) => new(value);


	public static NonEmptyString Parse(string s, IFormatProvider? provider) => new(s);
	public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out NonEmptyString result) {
		if (!string.IsNullOrWhiteSpace(s)) {
			result = new(s);
			return true;
		}

		result = default;
		return false;
	}
}
