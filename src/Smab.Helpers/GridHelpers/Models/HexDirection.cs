namespace Smab.Helpers;

/// <summary>
/// Represents the possible directions in a hexagonal grid.
/// </summary>
/// <remarks>This enumeration defines the primary directions used for navigation or positioning within a hexagonal
/// grid. The directions are based on a standard hexagonal layout and include cardinal and intercardinal directions, as
/// well as a <see cref="None"/> value to represent no direction.</remarks>
public enum HexDirection {
	None = 0,
	NW,
	N,
	NE,
	SE,
	S,
	SW
}
