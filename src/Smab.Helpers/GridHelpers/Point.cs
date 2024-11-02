namespace Smab.Helpers;

[DebuggerDisplay("{DebugDisplay,nq}")]
public record struct Point(int X, int Y) : IParsable<Point> {

	public Point((int X, int Y) point) : this(point.X, point.Y) { }


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
	public static Point operator -(Point p1)                    => new(-p1.X, -p1.Y);

	public static Point operator *(in Point lhs, int rhs) => new(lhs.X * rhs, lhs.Y * rhs);
	public static Point operator *(int lhs, in Point rhs) => new(rhs.X * lhs, rhs.Y * lhs);

	public readonly void Deconstruct(out int x, out int y) {
		x = X;
		y = Y;
	}

	public IEnumerable<Point> Adjacent() {
		Point p = this;
		return CARDINAL_DIRECTIONS.Select(d => p with { X = p.X + d.dX, Y = p.Y + d.dY });
	}

	public IEnumerable<Point> DiagonallyAdjacent() {
		Point p = this;
		return ORDINAL_DIRECTIONS.Select(d => p with { X = p.X + d.dX, Y = p.Y + d.dY });
	}

	public IEnumerable<Point> AllAdjacent() {
		Point p = this;
		return ALL_DIRECTIONS.Select(d => p with { X = p.X + d.dX, Y = p.Y + d.dY });
	}

	public readonly Point Transpose() => new(Y, X);

	public Point East(int distance = 1)  => this with { X = X + distance };
	public Point West(int distance = 1)  => this with { X = X - distance };
	public Point North(int distance = 1) => this with { Y = Y - distance };
	public Point South(int distance = 1) => this with { Y = Y + distance };

	public Point Right(int distance = 1) => this with { X = X + distance };
	public Point Left(int distance = 1)  => this with { X = X - distance };
	public Point Up(int distance = 1)    => this with { Y = Y - distance };
	public Point Down(int distance = 1)  => this with { Y = Y + distance };

	public static readonly Point Zero = new(0, 0);

	private static readonly List<(int dX, int dY)> CARDINAL_DIRECTIONS = [
		( 0, -1),
		( 0,  1),
		(-1,  0),
		( 1,  0),
	];
	private static readonly List<(int dX, int dY)> ORDINAL_DIRECTIONS = [
		( 1, -1),
		( 1,  1),
		(-1,  1),
		(-1, -1),
	];
	private static readonly List<(int dX, int dY)> ALL_DIRECTIONS = [
		( 0, -1),
		( 1, -1),
		( 1,  0),
		( 1,  1),
		( 0,  1),
		(-1,  1),
		(-1,  0),
		(-1, -1),
	];

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