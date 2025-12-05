namespace Smab.Helpers;

/// <summary>
/// Represents a set of directional values, supporting combinations of multiple directions.
/// </summary>
/// <remarks>This enumeration uses the <see cref="FlagsAttribute"/> to allow bitwise combinations of its values.
/// It includes primary cardinal directions (e.g., <see cref="North"/>, <see cref="East"/>),  intercardinal directions
/// (e.g., <see cref="NorthEast"/>, <see cref="SouthWest"/>),  and shorthand aliases (e.g., <see cref="N"/>, <see
/// cref="SE"/>).  Additionally, alternative names such as <see cref="Up"/> and <see cref="Right"/> are provided for
/// convenience.</remarks>
[Flags]
public enum Direction {
	None = 0,

	North = 1,
	East = 2,
	South = 4,
	West = 8,

	NorthEast = North | East,
	NorthWest = North | West,
	SouthEast = South | East,
	SouthWest = South | West,

	N = North,
	NE = NorthEast,
	E = East,
	SE = SouthEast,
	S = South,
	SW = SouthWest,
	W = West,
	NW = NorthWest,

	Up = North,
	Right = East,
	Down = South,
	Left = West,

	U = North,
	R = East,
	D = South,
	L = West,
}

