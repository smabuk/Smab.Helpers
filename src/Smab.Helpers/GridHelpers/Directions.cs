using static Smab.Helpers.ArrayHelpers;
using static Smab.Helpers.Direction;

namespace Smab.Helpers;

public static partial class Directions {
	public static readonly IEnumerable<Direction> CardinalDirections = [North, East, South, West];
	public static readonly IEnumerable<Direction> OrdinalDirections = [NorthWest, NorthEast, SouthEast, SouthWest];
	public static readonly IEnumerable<Direction> AllCompassDirections = [.. CardinalDirections, .. OrdinalDirections];

	public static readonly IEnumerable<Direction> URDL = [Up, Right, Down, Left];
	public static readonly IEnumerable<Direction> UDLR = [Up, Down, Left, Right];
	public static readonly IEnumerable<Direction> NESW = [North, East, South, West];
	public static readonly IEnumerable<Direction> NSEW = [North, South, East, West];

	extension(Direction direction) {
		/// <summary>
		/// Reverses the specified <see cref="Direction"/> to its opposite direction.
		/// </summary>
		/// <param name="direction">The <see cref="Direction"/> to reverse.</param>
		/// <returns>The opposite <see cref="Direction"/> of the specified <paramref name="direction"/>.</returns>
		/// <exception cref="NotImplementedException">Thrown if the specified <paramref name="direction"/> is not a recognized value.</exception>
		public Direction Reverse()
			=> direction switch {
				Up => Down,
				Right => Left,
				Down => Up,
				Left => Right,
				NorthWest => SouthEast,
				NorthEast => SouthWest,
				SouthEast => NorthWest,
				SouthWest => NorthEast,
				_ => throw new NotImplementedException(),
			};

		/// <summary>
		/// Rotates the specified <see cref="Direction"/> 90 degrees clockwise.
		/// </summary>
		/// <param name="direction">The current direction to rotate.</param>
		/// <returns>The <see cref="Direction"/> resulting from a 90-degree clockwise rotation.</returns>
		/// <exception cref="NotImplementedException">Thrown if the provided <paramref name="direction"/> is not a valid <see cref="Direction"/> value.</exception>
		public Direction TurnRight()
			=> direction switch {
				Up => Right,
				Right => Down,
				Down => Left,
				Left => Up,
				_ => throw new NotImplementedException(),
			};

		/// <summary>
		/// Rotates the specified <see cref="Direction"/> 90 degrees counterclockwise.
		/// </summary>
		/// <param name="direction">The current direction to rotate from.</param>
		/// <returns>The <see cref="Direction"/> resulting from a 90-degree counterclockwise rotation.</returns>
		/// <exception cref="NotImplementedException">Thrown if the specified <paramref name="direction"/> is not a valid <see cref="Direction"/> value.</exception>
		public Direction TurnLeft()
			=> direction switch {
				Up => Left,
				Right => Up,
				Down => Right,
				Left => Down,
				_ => throw new NotImplementedException(),
			};

		/// <summary>
		/// Calculates the change in X and Y coordinates (delta) corresponding to the specified direction.
		/// </summary>
		/// <param name="direction">The direction for which to calculate the delta. Must be a valid <see cref="Direction"/> value.</param>
		/// <returns>A tuple containing the change in X and Y coordinates as integers.  The first item (<c>dX</c>) represents the change
		/// in the X-axis, and the second item (<c>dY</c>) represents the change in the Y-axis.</returns>
		/// <exception cref="NotImplementedException">Thrown if the specified <paramref name="direction"/> is not implemented or is invalid.</exception>
		public (int dX, int dY) Delta()
			=> direction switch {
				North | Up => NORTH,
				East | Right => EAST,
				South | Down => SOUTH,
				West | Left => WEST,
				NorthWest => NORTH_WEST,
				NorthEast => NORTH_EAST,
				SouthEast => SOUTH_EAST,
				SouthWest => SOUTH_WEST,
				_ => throw new NotImplementedException(),
			};

		/// <summary>
		/// Determines whether the specified <see cref="Direction"/> represents a diagonal direction.
		/// </summary>
		/// <param name="direction">The <see cref="Direction"/> to evaluate.</param>
		/// <returns><see langword="true"/> if the <paramref name="direction"/> is diagonal  (i.e., <see cref="Direction.NorthWest"/>,
		/// <see cref="Direction.NorthEast"/>,  <see cref="Direction.SouthEast"/>, or <see cref="Direction.SouthWest"/>);
		/// otherwise, <see langword="false"/>.</returns>
		public bool IsDiagonal() => direction is NorthWest or NorthEast or SouthEast or SouthWest;

		/// <summary>
		/// Determines whether the specified <see cref="Direction"/> represents a horizontal direction.
		/// </summary>
		/// <param name="direction">The <see cref="Direction"/> to evaluate.</param>
		/// <returns><see langword="true"/> if the <paramref name="direction"/> is <see cref="Direction.East"/> or <see
		/// cref="Direction.West"/>; otherwise, <see langword="false"/>.</returns>
		public bool IsHorizontal() => direction is East or West;

		/// <summary>
		/// Determines whether the specified <see cref="Direction"/> represents a vertical direction.
		/// </summary>
		/// <param name="direction">The <see cref="Direction"/> to evaluate.</param>
		/// <returns><see langword="true"/> if the <paramref name="direction"/> is <see cref="Direction.North"/> or <see
		/// cref="Direction.South"/>; otherwise, <see langword="false"/>.</returns>
		public bool IsVertical() => direction is North or South;
	}
}
