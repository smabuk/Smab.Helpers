namespace Smab.Helpers;

[Flags]
public enum Direction {
	None = 0,

	North = 1,
	East  = 2,
	South = 4,
	West  = 8,

	NorthEast = North | East,
	NorthWest = North | West,
	SouthEast = South | East,
	SouthWest = South | West,

	N  = North,
	NE = NorthEast,
	E  = East,
	SE = SouthEast,
	S  = South,
	SW = SouthWest,
	W  = West,
	NW = NorthWest,

	Up    = North,
	Right = East,
	Down  = South,
	Left  = West,

	U = North,
	R = East,
	D = South,
	L = West,
}

