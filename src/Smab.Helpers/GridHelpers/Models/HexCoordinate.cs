namespace Smab.Helpers;

/// <summary>
/// 
///    \  n  /
///  nw +---+ ne
/// nw /     \ ne
///  -+       +-
/// sw \     / se
///  sw +---+ se
///    /  s \
/// 
/// </summary>
/// <param name="X">Represents the NW <--> SE axis</param>
/// <param name="Y">Represents the  N <--> S  axis</param>
/// <param name="Z">Represents the NE <--> SW axis</param>
/// <seealso cref="https://www.redblobgames.com/grids/hexagons-v2/pre-index.html#coordinates"/>
public record HexCoordinate(int X, int Y, int Z) {
	/// <summary>
	/// One step towards any other hexagon requires 2 values to change 
	/// so remember to divide by 2 to get the actual value
	/// </summary>
	public int Distance => (int.Abs(X) + int.Abs(Y) + int.Abs(Z)) / 2;

	public HexCoordinate Step(HexDirection direction, int distance = 1) {
		return direction switch {
			HexDirection.N  => this with { X = X + 0, Y = Y + distance, Z = Z - distance },
			HexDirection.S  => this with { X = X + 0, Y = Y - distance, Z = Z + distance },

			HexDirection.NE => this with { X = X + distance, Y = Y + 0, Z = Z - distance },
			HexDirection.SW => this with { X = X - distance, Y = Y + 0, Z = Z + distance },

			HexDirection.NW => this with { X = X - distance, Y = Y + distance, Z = Z + 0 },
			HexDirection.SE => this with { X = X + distance, Y = Y - distance, Z = Z + 0 },

			_ => throw new NotImplementedException(),
		};
	}
}
