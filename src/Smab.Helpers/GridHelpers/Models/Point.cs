namespace Smab.Helpers;

/// <summary>
/// Represents a point in a two-dimensional space with integer coordinates.
/// </summary>
/// <remarks>The <see cref="Point"/> struct provides a lightweight representation of a 2D point with X and Y
/// coordinates. It supports various operations such as addition, subtraction, multiplication, and comparison.
/// Additionally, it includes predefined points such as <see cref="Zero"/>, <see cref="One"/>, <see cref="UnitX"/>, and
/// <see cref="UnitY"/>.</remarks>
/// <param name="X"></param>
/// <param name="Y"></param>
[DebuggerDisplay("{DebugDisplay,nq}")]
public record struct Point(int X, int Y) : IParsable<Point>, IComparable<Point> {

	/// <summary>
	/// Initializes a new instance of the Point class by copying the coordinates from the specified Point.
	/// </summary>
	/// <param name="point">The Point instance whose X and Y coordinates are used to initialize the new Point. Cannot be null.</param>
	public Point(Point point) : this(point.X, point.Y) { }

	/// <summary>
	/// Initializes a new instance of the Point structure using the specified coordinates.
	/// </summary>
	/// <param name="point">A tuple containing the X and Y coordinates to assign to the point.</param>
	public Point((int X, int Y) point) : this(point.X, point.Y) { }

	/// <summary>Creates a new <see cref="Point" /> object whose two elements have the same value.</summary>
	/// <param name="value">The value to assign to both elements.</param>
	public Point(int value) : this(value, value) { }


	/// <summary>Returns a <see cref="Point" /> whose 2 elements are equal to zero.</summary>
	/// <value>A <see cref="Point" /> whose two elements are equal to zero (that is, it returns the Point <c>(0,0)</c>.</value>
	public static readonly Point Zero = default;

	/// <summary>Returns a <see cref="Point" /> whose 2 elements are equal to one.</summary>
	/// <value>A <see cref="Point" /> whose two elements are equal to one (that is, it returns the Point <c>(1,1)</c>.</value>
	public static readonly Point One = new(1);

	/// <summary>Gets the point (1,0).</summary>
	/// <value>The point <c>(1,0)</c>.</value>
	public static readonly Point UnitX = new(1, 0);

	/// <summary>Gets the point (0,1).</summary>
	/// <value>The point <c>(0,1)</c>.</value>
	public static readonly Point UnitY = new(0, 1);

	/// <summary>
	/// Converts a <see cref="Point"/> instance to a tuple containing its X and Y coordinates.
	/// </summary>
	/// <remarks>This operator enables implicit conversion from a <see cref="Point"/> to a tuple of two integers,
	/// allowing direct assignment or usage in tuple-based APIs.</remarks>
	/// <param name="point">The <see cref="Point"/> to convert to an <see cref="System.ValueTuple{Int32, Int32}"/> representing the X and Y
	/// coordinates.</param>
	public static implicit operator (int x, int y)(Point point) => (point.X, point.Y);

	/// <summary>
	/// Ordering is by Y first, then X
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public readonly int CompareTo(Point other) {
		return Y == other.Y
			? X.CompareTo(other.X)
			: Y.CompareTo(other.Y);
	}

	public readonly void Deconstruct(out int x, out int y) {
		x = X;
		y = Y;
	}

	//public override string ToString() => $"({X}, {Y})";

	public static Point Parse(string s, IFormatProvider? provider) {
		char[] splitBy = [',', '(', ')'];
		string[] tokens = s.TrimmedSplit(splitBy);
		return new(tokens[0].As<int>(), tokens[1].As<int>());
	}

	public static Point Parse(string s) => Parse(s, null);
	public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Point result)
		=> ISimpleParsable<Point>.TryParse(s, provider, out result);


	private readonly string DebugDisplay => $$"""{{nameof(Point)}} ({{X}}, {{Y}})""";
}
