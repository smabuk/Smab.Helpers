namespace Smab.Helpers;

/// <summary>
/// Represents a point in a three-dimensional space with integer coordinates.
/// </summary>
/// <remarks>The <see cref="Point3d"/> struct provides a lightweight, immutable representation of a 3D point. It
/// supports basic arithmetic operations, directional movement, and parsing from string representations. Commonly used
/// for geometric calculations, spatial representations, and grid-based systems.</remarks>
/// <param name="X"></param>
/// <param name="Y"></param>
/// <param name="Z"></param>
[DebuggerDisplay("{DebugDisplay,nq}")]
public record struct Point3d(int X, int Y, int Z) : IParsable<Point3d> {

	public Point3d(Point3d point) : this(point.X, point.Y, point.Z) { }
	public Point3d((int X, int Y, int Z) point) : this(point.X, point.Y, point.Z) { }


	/// <summary>Creates a new <see cref="Point3d" /> object whose two elements have the same value.</summary>
	/// <param name="value">The value to assign to both elements.</param>
	public Point3d(int value) : this(value, value, value) { }

	/// <summary>Returns a <see cref="Point3d" /> whose 3 elements are equal to zero.</summary>
	/// <value>A <see cref="Point3d" /> whose three elements are equal to zero (that is, it returns the Point3d <c>(0,0,0)</c>.</value>
	public static readonly Point3d Zero = default;

	/// <summary>Returns a <see cref="Point3d" /> whose 3 elements are equal to one.</summary>
	/// <value>A <see cref="Point3d" /> whose three elements are equal to one (that is, it returns the Point3d <c>(1,1,1)</c>.</value>
	public static readonly Point3d One = new(1);

	/// <summary>Gets the point (1,0,0).</summary>
	/// <value>The point <c>(1,0,0)</c>.</value>
	public static readonly Point3d UnitX = new(1, 0, 0);

	/// <summary>Gets the point (0,1,0).</summary>
	/// <value>The point <c>(0,1,0)</c>.</value>
	public static readonly Point3d UnitY = new(0, 1, 0);

	/// <summary>Gets the point (0,0,1).</summary>
	/// <value>The point <c>(0,0,1)</c>.</value>
	public static readonly Point3d UnitZ = new(0, 0, 1);


	public static implicit operator (int x, int y, int z)(Point3d point) => (point.X, point.Y, point.Z);

	public static Point3d operator +(in Point3d lhs, in Point3d rhs) => new(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
	public static Point3d operator +(in Point3d lhs, in (int X, int Y, int Z) rhs) => new(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
	public static Point3d operator +(in (int X, int Y, int Z) lhs, in Point3d rhs) => new(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);

	public static Point3d operator -(in Point3d lhs, in Point3d rhs) => new(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
	public static Point3d operator -(in Point3d lhs, in (int X, int Y, int Z) rhs) => new(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
	public static Point3d operator -(in (int X, int Y, int Z) lhs, in Point3d rhs) => new(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
	public static Point3d operator -(in Point3d value) => new(-value.X, -value.Y, -value.Z);

	public static Point3d operator *(in Point3d lhs, in Point3d rhs) => new(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);

	public static Point3d operator *(in Point3d lhs, int rhs) => new(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
	public static Point3d operator *(int lhs, in Point3d rhs) => new(rhs.X * lhs, rhs.Y * lhs, rhs.Z * lhs);


	public readonly void Deconstruct(out int x, out int y, out int z) {
		x = X;
		y = Y;
		z = Z;
	}

	public Point3d East(int distance = 1) => this with { X = X + distance };
	public Point3d West(int distance = 1) => this with { X = X - distance };
	public Point3d North(int distance = 1) => this with { Y = Y - distance };
	public Point3d South(int distance = 1) => this with { Y = Y + distance };
	public Point3d Front(int distance = 1) => this with { Z = Z - distance };
	public Point3d Back(int distance = 1) => this with { Z = Z + distance };
	public Point3d Right(int distance = 1) => this with { X = X + distance };
	public Point3d Left(int distance = 1) => this with { X = X - distance };
	public Point3d Up(int distance = 1) => this with { Y = Y - distance };
	public Point3d Down(int distance = 1) => this with { Y = Y + distance };

	public IEnumerable<Point3d> Adjacent() {
		Point3d p = this;
		return CARDINAL_DIRECTIONS.Select(d => p with { X = p.X + d.dX, Y = p.Y + d.dY, Z = p.Z + d.dZ });
	}

	public IEnumerable<Point3d> AllAdjacent() {
		Point3d p = this;
		for (int z = -1; z <= 1; z++) {
			for (int y = -1; y <= 1; y++) {
				for (int x = -1; x <= 1; x++) {
					if (x == 0 && y == 0 && z == 0) {
						continue;
					}
					yield return p with { X = p.X + x, Y = p.Y + y, Z = p.Z + z };
				}
			}
		}
	}

	private static readonly List<(int dX, int dY, int dZ)> CARDINAL_DIRECTIONS = [
		( 0, -1,  0),
		( 0,  1,  0),
		(-1,  0,  0),
		( 1,  0,  0),
		( 0,  0, -1),
		( 0,  0,  1),
	];
	private static readonly List<(int dX, int dY, int dZ)> ORDINAL_DIRECTIONS = [
		( 1, -1, -1),
		( 1,  1,  1),
		(-1,  1, -1),
		(-1, -1,  1),
	];

	//public override string ToString() => $"({X}, {Y}, {Z})";

	public static Point3d Parse(string s, IFormatProvider? provider) {
		char[] splitBy = [',', '(', ')'];
		string[] tokens = s.TrimmedSplit(splitBy);
		return new(tokens[0].As<int>(), tokens[1].As<int>(), tokens[2].As<int>());
	}

	public static Point3d Parse(string s) => Parse(s, null);
	public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Point3d result)
		=> ISimpleParsable<Point3d>.TryParse(s, provider, out result);

	private readonly string DebugDisplay => $$"""{{nameof(Point3d)}} ({{X}}, {{Y}}, {{Z}})""";
}
