﻿namespace Smab.Helpers;

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

	public Point(Point point) : this(point.X, point.Y) { }

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



	public static implicit operator (int x, int y)(Point point) => (point.X, point.Y);

	public static Point operator +(Point p1, Point p2)          => new(p1.X + p2.X, p1.Y + p2.Y);
	public static Point operator +((int X, int Y) p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);
	public static Point operator +(int lhs, Point p2)           => new(lhs + p2.X, lhs + p2.Y);
	public static Point operator +(Point p1, int rhs)           => new(rhs + p1.X, rhs + p1.Y);
	public static Point operator +(Point p1, (int X, int Y) p2) => new(p1.X + p2.X, p1.Y + p2.Y);

	public static Point operator -(Point p1, Point p2)          => new(p1.X - p2.X, p1.Y - p2.Y);
	public static Point operator -(Point p1, (int X, int Y) p2) => new(p1.X - p2.X, p1.Y - p2.Y);
	public static Point operator -(Point p1, int rhs)           => new(p1.X - rhs, p1.Y - rhs);
	public static Point operator -((int X, int Y) p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);
	public static Point operator -(Point p1)                    => Zero - p1;

	public static Point operator *(Point p1, Point p2)          => new(p1.X * p2.X, p1.Y * p2.Y);
	public static Point operator *(Point p1, (int X, int Y) p2) => new(p1.X * p2.X, p1.Y * p2.Y);
	public static Point operator *((int X, int Y) p1, Point p2) => new(p1.X * p2.X, p1.Y * p2.Y);
	public static Point operator *(in Point lhs, int rhs) => new(lhs.X * rhs, lhs.Y * rhs);
	public static Point operator *(int lhs, in Point rhs) => new(rhs.X * lhs, rhs.Y * lhs);
	
	public static Point operator %(Point p1, Point p2)          => new(p1.X % p2.X, p1.Y % p2.Y);
	public static Point operator %(Point p1, (int X, int Y) p2) => new(p1.X % p2.X, p1.Y % p2.Y);
	public static Point operator %(Point p1, int rhs)           => new(p1.X % rhs, p1.Y % rhs);
	public static Point operator %((int X, int Y) p1, Point p2) => new(p1.X % p2.X, p1.Y % p2.Y);


	public static bool operator  <(Point point1, Point point2) => point1.CompareTo(point2)  < 0;
	public static bool operator  >(Point point1, Point point2) => point1.CompareTo(point2)  > 0;
	public static bool operator <=(Point point1, Point point2) => point1.CompareTo(point2) <= 0;
	public static bool operator >=(Point point1, Point point2) => point1.CompareTo(point2) >= 0;

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