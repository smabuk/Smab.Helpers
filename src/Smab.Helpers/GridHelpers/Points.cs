using static Smab.Helpers.ArrayHelpers;

namespace Smab.Helpers;

public static partial class Directions {
	public static Point Move( this Point point, Direction direction, int distance = 1)
		=> point with { X = point.X + (direction.Delta().dX * distance), Y = point.Y + (direction.Delta().dY * distance)};

	public static Point MoveEast( this Point point, int distance = 1) => point with { X = point.X + distance };
	public static Point MoveWest (this Point point, int distance = 1) => point with { X = point.X - distance };
	public static Point MoveNorth(this Point point, int distance = 1) => point with { Y = point.Y - distance };
	public static Point MoveSouth(this Point point, int distance = 1) => point with { Y = point.Y + distance };
	
	public static Point MoveRight(this Point point, int distance = 1) => point with { X = point.X + distance };
	public static Point MoveLeft (this Point point, int distance = 1) => point with { X = point.X - distance };
	public static Point MoveUp   (this Point point, int distance = 1) => point with { Y = point.Y - distance };
	public static Point MoveDown (this Point point, int distance = 1) => point with { Y = point.Y + distance };

	public static IEnumerable<Point> Adjacent(this Point point) => CARDINAL_DIRECTIONS.Select(d => point + d);
	public static IEnumerable<Point> DiagonallyAdjacent(this Point point) => ORDINAL_DIRECTIONS.Select(d => point + d);
	public static IEnumerable<Point> AllAdjacent(this Point point) => ALL_DIRECTIONS.Select(d => point + d);

	public static Point Translate(this Point point, Direction direction, int distance = 1)
		=> point with { X = point.X + (direction.Delta().dX * distance), Y = point.Y + (direction.Delta().dY * distance) };

	public static Point Transpose(this Point point) => new(point.Y, point.X);

	public static Point Abs(this Point point) => new(int.Abs(point.X), int.Abs(point.Y));

	public static Point Max(this Point point1, Point point2)
		=> new(
			point1.X > point2.X ? point1.X : point2.X,
			point1.Y > point2.Y ? point1.Y : point2.Y
		);

	public static Point Min(this Point point1, Point point2)
		=> new(
			point1.X < point2.X ? point1.X : point2.X,
			point1.Y < point2.Y ? point1.Y : point2.Y
		);
}
