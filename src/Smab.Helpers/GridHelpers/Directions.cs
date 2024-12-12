using static Smab.Helpers.ArrayHelpers;
using static Smab.Helpers.Direction;

namespace Smab.Helpers;

public static partial class Directions {
	public static readonly IEnumerable<Direction> CardinalDirections   = [North, East, South, West];
	public static readonly IEnumerable<Direction> OrdinalDirections    = [NorthWest, NorthEast, SouthEast, SouthWest];
	public static readonly IEnumerable<Direction> AllCompassDirections = [.. CardinalDirections, .. OrdinalDirections];
	
	public static readonly IEnumerable<Direction> URDL = [Up, Right, Down, Left];
	public static readonly IEnumerable<Direction> UDLR = [Up, Down, Left, Right];
	public static readonly IEnumerable<Direction> NESW = [North, East, South, West];
	public static readonly IEnumerable<Direction> NSEW = [North, South, East, West];


	public static Direction Reverse(this Direction direction)
		=> direction switch {
			Up    => Down,
			Right => Left,
			Down  => Up,
			Left  => Right,
			NorthWest => SouthEast,
			NorthEast => SouthWest,
			SouthEast => NorthWest,
			SouthWest => NorthEast,
			_ => throw new NotImplementedException(),
		};

	public static Direction TurnRight(this Direction direction)
		=> direction switch {
			Up    => Right,
			Right => Down,
			Down  => Left,
			Left  => Up,
			_ => throw new NotImplementedException(),
		};

	public static Direction TurnLeft(this Direction direction)
		=> direction switch {
			Up    => Left,
			Right => Up,
			Down  => Right,
			Left  => Down,
			_ => throw new NotImplementedException(),
		};

	public static (int dX, int dY) Delta(this Direction direction)
		=> direction switch {
			North | Up    => NORTH,
			East  | Right => EAST,
			South | Down  => SOUTH,
			West  | Left  => WEST,
			NorthWest     => NORTH_WEST,
			NorthEast     => NORTH_EAST,
			SouthEast     => SOUTH_EAST,
			SouthWest     => SOUTH_WEST,
			_ => throw new NotImplementedException(),
		};

	public static bool IsDiagonal(this Direction direction) => direction is NorthWest or NorthEast or SouthEast or SouthWest;
	public static bool IsHorizontal(this Direction direction) => direction is East or West;
	public static bool IsVertical(this Direction direction) => direction is North or South;
}
