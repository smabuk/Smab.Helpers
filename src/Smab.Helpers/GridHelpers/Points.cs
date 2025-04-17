using static Smab.Helpers.ArrayHelpers;

namespace Smab.Helpers;

public static partial class Directions {
	/// <summary>
	/// Moves the specified <see cref="Point"/> in the given direction by a specified distance.
	/// </summary>
	/// <param name="point">The starting point to move.</param>
	/// <param name="direction">The direction in which to move the point.</param>
	/// <param name="distance">The distance to move the point in the specified direction. Defaults to <see langword="1"/> if not provided.</param>
	/// <returns>A new <see cref="Point"/> representing the position after moving the specified distance in the given direction.</returns>
	public static Point Move( this Point point, Direction direction, int distance = 1)
		=> point with { X = point.X + (direction.Delta().dX * distance), Y = point.Y + (direction.Delta().dY * distance)};

	/// <summary>
	/// Moves the specified <see cref="Point"/> east by a given distance.
	/// </summary>
	/// <param name="point">The starting <see cref="Point"/> to move.</param>
	/// <param name="distance">The distance to move the point east, in units. Defaults to <see langword="1"/> if not specified.</param>
	/// <returns>A new <see cref="Point"/> that is the result of moving the original point east by the specified distance.</returns>
	public static Point MoveEast( this Point point, int distance = 1) => point with { X = point.X + distance };
	/// <summary>
	/// Moves the specified <see cref="Point"> west (decreasing its X-coordinate) by the given distance.
	/// </summary>
	/// <param name="point">The <see cref="Point"> to move.</param>
	/// <param name="distance">The distance to move the point west. Defaults to <see langword="1"/> if not specified.  Must be a non-negative
	/// value.</param>
	/// <returns>A new <see cref="Point"> with its X-coordinate decreased by the specified distance,  while retaining the original
	/// Y-coordinate.</returns>
	public static Point MoveWest (this Point point, int distance = 1) => point with { X = point.X - distance };
	/// <summary>
	/// Moves the specified <see cref="Point"/> north by a given distance.
	/// </summary>
	/// <remarks>Moving north decreases the <see cref="Point.Y"/> coordinate by the specified distance.</remarks>
	/// <param name="point">The starting point to move.</param>
	/// <param name="distance">The distance to move north, in units. Defaults to <see langword="1"/> if not specified.</param>
	/// <returns>A new <see cref="Point"/> representing the position after moving north by the specified distance.</returns>
	public static Point MoveNorth(this Point point, int distance = 1) => point with { Y = point.Y - distance };
	/// <summary>
	/// Moves the specified <see cref="Point"/> south by a given distance.
	/// </summary>
	/// <param name="point">The starting point to move.</param>
	/// <param name="distance">The distance to move south, in units. Defaults to <see langword="1"/> if not specified.</param>
	/// <returns>A new <see cref="Point"/> representing the position after moving south by the specified distance.</returns>
	public static Point MoveSouth(this Point point, int distance = 1) => point with { Y = point.Y + distance };
	

	/// <summary>
	/// Moves the specified <see cref="Point"/> to the right by a given distance.
	/// </summary>
	/// <param name="point">The <see cref="Point"/> to move.</param>
	/// <param name="distance">The number of units to move the point to the right. Defaults to <see langword="1"/> if not specified.</param>
	/// <returns>A new <see cref="Point"/> with its X-coordinate increased by the specified distance.</returns>
	public static Point MoveRight(this Point point, int distance = 1) => point with { X = point.X + distance };
	/// <summary>
	/// Moves the specified <see cref="Point"/> to the left by a given distance.
	/// </summary>
	/// <param name="point">The <see cref="Point"/> to move.</param>
	/// <param name="distance">The number of units to move the point to the left. Defaults to <see langword="1"/> if not specified.</param>
	/// <returns>A new <see cref="Point"/> with its X-coordinate decreased by the specified distance.</returns>
	public static Point MoveLeft (this Point point, int distance = 1) => point with { X = point.X - distance };
	/// <summary>
	/// Moves the specified <see cref="Point"/> upward by a given distance.
	/// </summary>
	/// <param name="point">The <see cref="Point"/> to move.</param>
	/// <param name="distance">The distance to move the point upward, in units. Defaults to <see langword="1"/> if not specified.</param>
	/// <returns>A new <see cref="Point"/> that is moved upward by the specified distance.</returns>
	public static Point MoveUp   (this Point point, int distance = 1) => point with { Y = point.Y - distance };
	/// <summary>
	/// Moves the specified <see cref="Point"/> downward by a given distance.
	/// </summary>
	/// <param name="point">The <see cref="Point"/> to move.</param>
	/// <param name="distance">The distance to move downward along the Y-axis. Defaults to <see langword="1"/> if not specified.</param>
	/// <returns>A new <see cref="Point"/> with its Y-coordinate increased by the specified distance.</returns>
	public static Point MoveDown (this Point point, int distance = 1) => point with { Y = point.Y + distance };

	
	/// <summary>
	/// Returns the points adjacent to the specified point in cardinal directions.
	/// </summary>
	/// <remarks>Adjacent points are determined based on the cardinal directions (up, down, left, and
	/// right).</remarks>
	/// <param name="point">The point for which to find adjacent points.</param>
	/// <returns>An enumerable collection of points that are adjacent to the specified point in cardinal directions.</returns>
	public static IEnumerable<Point> Adjacent(this Point point) => CARDINAL_DIRECTIONS.Select(d => point + d);

	/// <summary>
	/// Returns the points that are diagonally adjacent to the specified point.
	/// </summary>
	/// <remarks>Diagonally adjacent points are determined by adding predefined diagonal direction vectors to the
	/// given point.</remarks>
	/// <param name="point">The point for which to find diagonally adjacent points.</param>
	/// <returns>An enumerable collection of <see cref="Point"/> objects representing the diagonally adjacent points.</returns>
	public static IEnumerable<Point> DiagonallyAdjacent(this Point point) => ORDINAL_DIRECTIONS.Select(d => point + d);

	/// <summary>
	/// Returns all adjacent points to the specified point in a two-dimensional space.
	/// </summary>
	/// <remarks>This method assumes a two-dimensional grid where each point has up to eight neighbors. The returned
	/// points are calculated by adding predefined directional offsets to the specified point.</remarks>
	/// <param name="point">The point for which to find adjacent points.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Point"/> objects representing the points adjacent to the specified
	/// point. The result includes all directly neighboring points in eight possible directions (up, down, left, right, and
	/// diagonals).</returns>
	public static IEnumerable<Point> AllAdjacent(this Point point) => ALL_DIRECTIONS.Select(d => point + d);

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
	public static Point Translate(this Point point, Direction direction, int distance = 1)
		=> point with { X = point.X + (direction.Delta().dX * distance), Y = point.Y + (direction.Delta().dY * distance) };

	/// <summary>
	/// Transposes the coordinates of the specified <see cref="Point"/> by swapping its X and Y values.
	/// </summary>
	/// <param name="point">The <see cref="Point"/> to transpose.</param>
	/// <returns>A new <see cref="Point"/> with its X and Y values swapped.</returns>
	public static Point Transpose(this Point point) => new(point.Y, point.X);

	/// <summary>
	/// Returns a new <see cref="Point"/> with each coordinate set to the absolute value of the corresponding coordinate in
	/// the specified <paramref name="point"/>.
	/// </summary>
	/// <param name="point">The <see cref="Point"/> whose coordinates will be converted to their absolute values.</param>
	/// <returns>A new <see cref="Point"/> where both <see cref="Point.X"/> and <see cref="Point.Y"/> are non-negative.</returns>
	public static Point Abs(this Point point) => new(int.Abs(point.X), int.Abs(point.Y));

	/// <summary>
	/// Compares two <see cref="Point"/> instances and returns a new <see cref="Point"/>  with the maximum X and Y values
	/// from the two points.
	/// </summary>
	/// <remarks>This method performs a component-wise comparison of the X and Y values of the two points.</remarks>
	/// <param name="point1">The first <see cref="Point"/> to compare.</param>
	/// <param name="point2">The second <see cref="Point"/> to compare.</param>
	/// <returns>A new <see cref="Point"/> where the X and Y values are the greater of the corresponding values from <paramref
	/// name="point1"/> and <paramref name="point2"/>.</returns>
	public static Point Max(this Point point1, Point point2)
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
	public static Point Min(this Point point1, Point point2)
		=> new(
			point1.X < point2.X ? point1.X : point2.X,
			point1.Y < point2.Y ? point1.Y : point2.Y
		);
}
