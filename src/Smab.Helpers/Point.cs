namespace Smab.Helpers;

public record struct Point(int X, int Y) {

	public Point((int X, int Y) point) : this(point.X, point.Y) { }


	public static implicit operator (int x, int y)(Point p) {
		p.Deconstruct(out int x, out int y);
		return (x, y);
	}

	public void Deconstruct(out int x, out int y) {
		x = X;
		y = Y;
	}

	public static Point operator +(Point p1, Point p2)          => new(p1.X + p2.X, p1.Y + p2.Y);
	public static Point operator +((int X, int Y) p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);
	public static Point operator +(Point p1, (int X, int Y) p2) => new(p1.X + p2.X, p1.Y + p2.Y);

	public static Point operator -(Point p1, Point p2)          => new(p1.X - p2.X, p1.Y - p2.Y);
	public static Point operator -(Point p1, (int X, int Y) p2) => new(p1.X - p2.X, p1.Y - p2.Y);
	public static Point operator -((int X, int Y) p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);
	public static Point operator -(Point p1)                    => new(-p1.X, -p1.Y);

	public static Point operator *(in Point lhs, int rhs) => new(lhs.X * rhs, lhs.Y * rhs);
	public static Point operator *(int lhs, in Point rhs) => new(rhs.X * lhs, rhs.Y * lhs);


	public IEnumerable<Point> Adjacent {
		get {
			Point p = this;
			return CARDINAL_DIRECTIONS.Select(d => p with { X = p.X + d.dX, Y = p.Y + d.dY });
		}
	}

	public IEnumerable<Point> DiagonallyAdjacent {
		get {
			Point p = this;
			return ORDINAL_DIRECTIONS.Select(d => p with { X = p.X + d.dX, Y = p.Y + d.dY });
		}
	}

	public IEnumerable<Point> AllAdjacent {
		get {
			Point p = this;
			return ALL_DIRECTIONS.Select(d => p with { X = p.X + d.dX, Y = p.Y + d.dY });
		}
	}

	public Point East()  => this with { X = X + 1 };
	public Point West()  => this with { X = X - 1 };
	public Point North() => this with { Y = Y - 1 };
	public Point South() => this with { Y = Y + 1 };

	private static readonly List<(int dX, int dY)> CARDINAL_DIRECTIONS = new() {
		( 0, -1),
		( 0,  1),
		(-1,  0),
		( 1,  0),
	};
	private static readonly List<(int dX, int dY)> ORDINAL_DIRECTIONS = new() {
		( 1, -1),
		( 1,  1),
		(-1,  1),
		(-1, -1),
	};
	private static readonly List<(int dX, int dY)> ALL_DIRECTIONS = new() {
		( 0, -1),
		( 1, -1),
		( 1,  0),
		( 1,  1),
		( 0,  1),
		(-1,  1),
		(-1,  0),
		(-1, -1),
	};

	public override string ToString() => $"({X}, {Y})";

}