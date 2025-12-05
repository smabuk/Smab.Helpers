namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public const int COL_DIMENSION = 0;
	public const int ROW_DIMENSION = 1;


	public static readonly (int dX, int dY) UP = (0, -1);
	public static readonly (int dX, int dY) DOWN = (0, 1);
	public static readonly (int dX, int dY) LEFT = (-1, 0);
	public static readonly (int dX, int dY) RIGHT = (1, 0);

	public static readonly (int dX, int dY) NORTH = (0, -1);
	public static readonly (int dX, int dY) SOUTH = (0, 1);
	public static readonly (int dX, int dY) WEST = (-1, 0);
	public static readonly (int dX, int dY) EAST = (1, 0);

	public static readonly (int dX, int dY) NORTH_WEST = (-1, -1);
	public static readonly (int dX, int dY) NORTH_EAST = (1, -1);
	public static readonly (int dX, int dY) SOUTH_EAST = (-1, 1);
	public static readonly (int dX, int dY) SOUTH_WEST = (1, 1);

	public static readonly List<(int dX, int dY)> CARDINAL_DIRECTIONS = [NORTH, SOUTH, EAST, WEST];
	public static readonly List<(int dX, int dY)> ORDINAL_DIRECTIONS = [NORTH_WEST, NORTH_EAST, SOUTH_EAST, SOUTH_WEST];
	public static readonly List<(int dX, int dY)> ALL_DIRECTIONS = [.. CARDINAL_DIRECTIONS, .. ORDINAL_DIRECTIONS];
}
