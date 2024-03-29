﻿namespace Smab.Helpers;

[DebuggerDisplay("{DebugDisplay,nq}")]
public record struct Point3d(int X, int Y, int Z) : IParsable<Point3d> {

	public Point3d((int X, int Y, int Z) point) : this(point.X, point.Y, point.Z) { }

	public static implicit operator (int x, int y, int z)(Point3d point) => (point.X, point.Y, point.Z);

	public static Point3d operator +(in Point3d lhs, in Point3d rhs)               => new(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
	public static Point3d operator +(in Point3d lhs, in (int X, int Y, int Z) rhs) => new(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
	public static Point3d operator +(in (int X, int Y, int Z) lhs, in Point3d rhs) => new(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);

	public static Point3d operator -(in Point3d lhs, in Point3d rhs)               => new(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
	public static Point3d operator -(in Point3d lhs, in (int X, int Y, int Z) rhs) => new(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
	public static Point3d operator -(in (int X, int Y, int Z) lhs, in Point3d rhs) => new(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
	public static Point3d operator -(in Point3d value)                             => new(-value.X, -value.Y, -value.Z);

	public static Point3d operator *(in Point3d lhs, in Point3d rhs) => new(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);

	public static Point3d operator *(in Point3d lhs, int rhs)        => new(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
	public static Point3d operator *(int lhs, in Point3d rhs)        => new(rhs.X * lhs, rhs.Y * lhs, rhs.Z * lhs);


	public readonly void Deconstruct(out int x, out int y, out int z) {
		x = X;
		y = Y;
		z = Z;
	}

	public Point3d East()  => this with { X = X + 1 };
	public Point3d West()  => this with { X = X - 1 };
	public Point3d North() => this with { Y = Y - 1 };
	public Point3d South() => this with { Y = Y + 1 };
	public Point3d Front() => this with { Z = Z - 1 };
	public Point3d Back()  => this with { Z = Z + 1 };
	public Point3d Right() => this with { X = X + 1 };
	public Point3d Left()  => this with { X = X - 1 };
	public Point3d Up()    => this with { Y = Y - 1 };
	public Point3d Down()  => this with { Y = Y + 1 };

	public IEnumerable<Point3d> Adjacent() {
		Point3d p = this;
		return CARDINAL_DIRECTIONS.Select(d => p with { X = p.X + d.dX, Y = p.Y + d.dY, Z = p.Z + d.dZ});
	}

	public IEnumerable<Point3d> AllAdjacent() {
		Point3d p = this;
		for (int z = -1; z <= 1; z++) {
			for (int y = -1; y <= 1; y++) {
				for (int x = -1; x <= 1; x++) {
					if (x == 0 && y == 0 && z == 0)
					{
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
