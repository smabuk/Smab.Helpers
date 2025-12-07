using static Smab.Helpers.ArrayHelpers;

namespace Smab.Helpers;

public static partial class PointHelpers {
	extension(Point) {

		public static Point operator +(Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);
		public static Point operator +((int X, int Y) p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);
		public static Point operator +(int lhs, Point p2) => new(lhs + p2.X, lhs + p2.Y);
		public static Point operator +(Point p1, int rhs) => new(rhs + p1.X, rhs + p1.Y);
		public static Point operator +(Point p1, (int X, int Y) p2) => new(p1.X + p2.X, p1.Y + p2.Y);

		public static Point operator -(Point p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);
		public static Point operator -(Point p1, (int X, int Y) p2) => new(p1.X - p2.X, p1.Y - p2.Y);
		public static Point operator -(Point p1, int rhs) => new(p1.X - rhs, p1.Y - rhs);
		public static Point operator -((int X, int Y) p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);
		public static Point operator -(Point p1) => Point.Zero - p1;

		public static Point operator *(Point p1, Point p2) => new(p1.X * p2.X, p1.Y * p2.Y);
		public static Point operator *(Point p1, (int X, int Y) p2) => new(p1.X * p2.X, p1.Y * p2.Y);
		public static Point operator *((int X, int Y) p1, Point p2) => new(p1.X * p2.X, p1.Y * p2.Y);
		public static Point operator *(in Point lhs, int rhs) => new(lhs.X * rhs, lhs.Y * rhs);
		public static Point operator *(int lhs, in Point rhs) => new(rhs.X * lhs, rhs.Y * lhs);

		public static Point operator %(Point p1, Point p2) => new(p1.X % p2.X, p1.Y % p2.Y);
		public static Point operator %(Point p1, (int X, int Y) p2) => new(p1.X % p2.X, p1.Y % p2.Y);
		public static Point operator %(Point p1, int rhs) => new(p1.X % rhs, p1.Y % rhs);
		public static Point operator %((int X, int Y) p1, Point p2) => new(p1.X % p2.X, p1.Y % p2.Y);


		public static bool operator <(Point point1, Point point2) => point1.CompareTo(point2) < 0;
		public static bool operator >(Point point1, Point point2) => point1.CompareTo(point2) > 0;
		public static bool operator <=(Point point1, Point point2) => point1.CompareTo(point2) <= 0;
		public static bool operator >=(Point point1, Point point2) => point1.CompareTo(point2) >= 0;


		public static Point operator /(Point p1, Point p2) {
			if (p2.X == 0 || p2.Y == 0) {
				throw new DivideByZeroException($"Cannot divide {p1} by {p2}: divisor contains zero.");
			}
			if (p1.X % p2.X != 0 || p1.Y % p2.Y != 0) {
				throw new ArgumentException($"Division of {p1} by {p2} does not result in integer coordinates.");
			}
			return new(p1.X / p2.X, p1.Y / p2.Y);
		}

		public static Point operator /(Point p1, (int X, int Y) p2) {
			if (p2.X == 0 || p2.Y == 0) {
				throw new DivideByZeroException($"Cannot divide {p1} by ({p2.X}, {p2.Y}): divisor contains zero.");
			}
			if (p1.X % p2.X != 0 || p1.Y % p2.Y != 0) {
				throw new ArgumentException($"Division of {p1} by ({p2.X}, {p2.Y}) does not result in integer coordinates.");
			}
			return new(p1.X / p2.X, p1.Y / p2.Y);
		}

		public static Point operator /(Point p1, int rhs) {
			if (rhs == 0) {
				throw new DivideByZeroException($"Cannot divide {p1} by zero.");
			}
			if (p1.X % rhs != 0 || p1.Y % rhs != 0) {
				throw new ArgumentException($"Division of {p1} by {rhs} does not result in integer coordinates.");
			}
			return new(p1.X / rhs, p1.Y / rhs);
		}

		public static Point operator /((int X, int Y) p1, Point p2) {
			if (p2.X == 0 || p2.Y == 0) {
				throw new DivideByZeroException($"Cannot divide ({p1.X}, {p1.Y}) by {p2}: divisor contains zero.");
			}
			if (p1.X % p2.X != 0 || p1.Y % p2.Y != 0) {
				throw new ArgumentException($"Division of ({p1.X}, {p1.Y}) by {p2} does not result in integer coordinates.");
			}
			return new(p1.X / p2.X, p1.Y / p2.Y);
		}
	}



	extension(Point point) {

		/// <summary>
		/// Gets the column index represented by this point.
		/// </summary>
		public int Col => point.X;
		/// <summary>
		/// Gets the zero-based row index represented by this point.
		/// </summary>
		public int Row => point.Y;

		public Point Left => point + Direction.Left.Delta();
		public Point Right => point + Direction.Right.Delta();
		public Point Up => point + Direction.Up.Delta();
		public Point Down => point + Direction.Down.Delta();
		public Point UpLeft => point + Direction.NorthWest.Delta();
		public Point UpRight => point + Direction.NorthEast.Delta();
		public Point DownLeft => point + Direction.SouthWest.Delta();
		public Point DownRight => point + Direction.SouthEast.Delta();

		public Point East => point + Direction.East.Delta();
		public Point West => point + Direction.West.Delta();
		public Point North => point + Direction.North.Delta();
		public Point South => point + Direction.South.Delta();
		public Point NorthEast => point + Direction.NorthEast.Delta();
		public Point NorthWest => point + Direction.NorthWest.Delta();
		public Point SouthEast => point + Direction.SouthEast.Delta();
		public Point SouthWest => point + Direction.SouthWest.Delta();



		/// <summary>
		/// Moves the specified <see cref="Point"/> in the given direction by a specified distance.
		/// </summary>
		/// <param name="point">The starting point to move.</param>
		/// <param name="direction">The direction in which to move the point.</param>
		/// <param name="distance">The distance to move the point in the specified direction. Defaults to <see langword="1"/> if not provided.</param>
		/// <returns>A new <see cref="Point"/> representing the position after moving the specified distance in the given direction.</returns>
		public Point Move(Direction direction, int distance = 1)
			=> point with { X = point.X + (direction.Delta().dX * distance), Y = point.Y + (direction.Delta().dY * distance) };

		/// <summary>
		/// Moves the specified <see cref="Point"/> east by a given distance.
		/// </summary>
		/// <param name="point">The starting <see cref="Point"/> to move.</param>
		/// <param name="distance">The distance to move the point east, in units. Defaults to <see langword="1"/> if not specified.</param>
		/// <returns>A new <see cref="Point"/> that is the result of moving the original point east by the specified distance.</returns>
		public Point MoveEast(int distance = 1) => point with { X = point.X + distance };
		/// <summary>
		/// Moves the specified <see cref="Point"> west (decreasing its X-coordinate) by the given distance.
		/// </summary>
		/// <param name="point">The <see cref="Point"> to move.</param>
		/// <param name="distance">The distance to move the point west. Defaults to <see langword="1"/> if not specified.  Must be a non-negative
		/// value.</param>
		/// <returns>A new <see cref="Point"> with its X-coordinate decreased by the specified distance,  while retaining the original
		/// Y-coordinate.</returns>
		public Point MoveWest(int distance = 1) => point with { X = point.X - distance };
		/// <summary>
		/// Moves the specified <see cref="Point"/> north by a given distance.
		/// </summary>
		/// <remarks>Moving north decreases the <see cref="Point.Y"/> coordinate by the specified distance.</remarks>
		/// <param name="point">The starting point to move.</param>
		/// <param name="distance">The distance to move north, in units. Defaults to <see langword="1"/> if not specified.</param>
		/// <returns>A new <see cref="Point"/> representing the position after moving north by the specified distance.</returns>
		public Point MoveNorth(int distance = 1) => point with { Y = point.Y - distance };
		/// <summary>
		/// Moves the specified <see cref="Point"/> south by a given distance.
		/// </summary>
		/// <param name="point">The starting point to move.</param>
		/// <param name="distance">The distance to move south, in units. Defaults to <see langword="1"/> if not specified.</param>
		/// <returns>A new <see cref="Point"/> representing the position after moving south by the specified distance.</returns>
		public Point MoveSouth(int distance = 1) => point with { Y = point.Y + distance };


		/// <summary>
		/// Moves the specified <see cref="Point"/> to the right by a given distance.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> to move.</param>
		/// <param name="distance">The number of units to move the point to the right. Defaults to <see langword="1"/> if not specified.</param>
		/// <returns>A new <see cref="Point"/> with its X-coordinate increased by the specified distance.</returns>
		public Point MoveRight(int distance = 1) => point with { X = point.X + distance };
		/// <summary>
		/// Moves the specified <see cref="Point"/> to the left by a given distance.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> to move.</param>
		/// <param name="distance">The number of units to move the point to the left. Defaults to <see langword="1"/> if not specified.</param>
		/// <returns>A new <see cref="Point"/> with its X-coordinate decreased by the specified distance.</returns>
		public Point MoveLeft(int distance = 1) => point with { X = point.X - distance };
		/// <summary>
		/// Moves the specified <see cref="Point"/> upward by a given distance.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> to move.</param>
		/// <param name="distance">The distance to move the point upward, in units. Defaults to <see langword="1"/> if not specified.</param>
		/// <returns>A new <see cref="Point"/> that is moved upward by the specified distance.</returns>
		public Point MoveUp(int distance = 1) => point with { Y = point.Y - distance };
		/// <summary>
		/// Moves the specified <see cref="Point"/> downward by a given distance.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> to move.</param>
		/// <param name="distance">The distance to move downward along the Y-axis. Defaults to <see langword="1"/> if not specified.</param>
		/// <returns>A new <see cref="Point"/> with its Y-coordinate increased by the specified distance.</returns>
		public Point MoveDown(int distance = 1) => point with { Y = point.Y + distance };


		/// <summary>
		/// Returns the points adjacent to the specified point in cardinal directions.
		/// </summary>
		/// <remarks>Adjacent points are determined based on the cardinal directions (up, down, left, and
		/// right).</remarks>
		/// <param name="point">The point for which to find adjacent points.</param>
		/// <returns>An enumerable collection of points that are adjacent to the specified point in cardinal directions.</returns>
		public IEnumerable<Point> Adjacent() => CARDINAL_DIRECTIONS.Select(d => point + d);

		/// <summary>
		/// Returns the points that are diagonally adjacent to the specified point.
		/// </summary>
		/// <remarks>Diagonally adjacent points are determined by adding predefined diagonal direction vectors to the
		/// given point.</remarks>
		/// <param name="point">The point for which to find diagonally adjacent points.</param>
		/// <returns>An enumerable collection of <see cref="Point"/> objects representing the diagonally adjacent points.</returns>
		public IEnumerable<Point> DiagonallyAdjacent() => ORDINAL_DIRECTIONS.Select(d => point + d);

		/// <summary>
		/// Returns all adjacent points to the specified point in a two-dimensional space.
		/// </summary>
		/// <remarks>This method assumes a two-dimensional grid where each point has up to eight neighbours. The returned
		/// points are calculated by adding predefined directional offsets to the specified point.</remarks>
		/// <param name="point">The point for which to find adjacent points.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Point"/> objects representing the points adjacent to the specified
		/// point. The result includes all directly neighbouring points in eight possible directions (up, down, left, right, and
		/// diagonals).</returns>
		public IEnumerable<Point> AllAdjacent() => ALL_DIRECTIONS.Select(d => point + d);

		/// <summary>
		/// Translates the specified <see cref="Point"/> by a given distance in the specified direction.
		/// </summary>
		/// <remarks>This method uses the <see cref="Direction.Delta"/> method to determine the translation vector for
		/// the specified direction.</remarks>
		/// <param name="point">The starting point to translate.</param>
		/// <param name="direction">The direction in which to translate the point.</param>
		/// <param name="distance">The distance to translate the point. Defaults to <see langword="1"/> if not specified. Must be a non-negative
		/// value.</param>
		/// <returns>A new <see cref="Point"/> that represents the translated position.</returns>
		public Point Translate(Direction direction, int distance = 1)
			=> point with { X = point.X + (direction.Delta().dX * distance), Y = point.Y + (direction.Delta().dY * distance) };

		/// <summary>
		/// Transposes the coordinates of the specified <see cref="Point"/> by swapping its X and Y values.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> to transpose.</param>
		/// <returns>A new <see cref="Point"/> with its X and Y values swapped.</returns>
		public Point Transpose() => new(point.Y, point.X);

		/// <summary>
		/// Returns a new <see cref="Point"/> with each coordinate set to the absolute value of the corresponding coordinate in
		/// the specified <paramref name="point"/>.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> whose coordinates will be converted to their absolute values.</param>
		/// <returns>A new <see cref="Point"/> where both <see cref="Point.X"/> and <see cref="Point.Y"/> are non-negative.</returns>
		public Point Abs() => new(int.Abs(point.X), int.Abs(point.Y));
	}

	extension(Point point1) {
		/// <summary>
		/// Compares two <see cref="Point"/> instances and returns a new <see cref="Point"/>  with the maximum X and Y values
		/// from the two points.
		/// </summary>
		/// <remarks>This method performs a component-wise comparison of the X and Y values of the two points.</remarks>
		/// <param name="point1">The first <see cref="Point"/> to compare.</param>
		/// <param name="point2">The second <see cref="Point"/> to compare.</param>
		/// <returns>A new <see cref="Point"/> where the X and Y values are the greater of the corresponding values from <paramref
		/// name="point1"/> and <paramref name="point2"/>.</returns>
		public Point Max(Point point2)
			=> new(
				point1.X > point2.X ? point1.X : point2.X,
				point1.Y > point2.Y ? point1.Y : point2.Y
			);

		/// <summary>
		/// Returns a new <see cref="Point"/> representing the minimum X and Y coordinates  between the two specified points.
		/// </summary>
		/// <param name="point1">The first point to compare.</param>
		/// <param name="point2">The second point to compare.</param>
		/// <returns>A <see cref="Point"/> where the X coordinate is the smaller of the X coordinates  of <paramref name="point1"/> and
		/// <paramref name="point2"/>, and the Y coordinate  is the smaller of the Y coordinates of <paramref name="point1"/>
		/// and <paramref name="point2"/>.</returns>
		public Point Min(Point point2)
			=> new(
				point1.X < point2.X ? point1.X : point2.X,
				point1.Y < point2.Y ? point1.Y : point2.Y
			);
	}
}
