namespace Smab.Helpers;

/// <summary>
/// Represents a cube in a 3D space with a specified position and associated value.
/// </summary>
/// <remarks>The <see cref="Cube{T}"/> type provides functionality to represent a cube's position in 3D space 
/// using <see cref="Point3d"/> coordinates and an associated value of type <typeparamref name="T"/>.  It supports
/// deconstruction, implicit conversions, and provides access to individual coordinates  through the <see cref="X"/>,
/// <see cref="Y"/>, and <see cref="Z"/> properties.</remarks>
/// <typeparam name="T">The type of the value associated with the cube.</typeparam>
/// <param name="Position"></param>
/// <param name="Value"></param>
[DebuggerDisplay("{DebugDisplay,nq}")]
public record Cube<T>(Point3d Position, T Value) {

	public Cube( int X, int Y, int Z, T Value)       : this(new Point3d(X, Y, Z), Value) { }
	public Cube((int X, int Y, int Z, T Value) cube) : this(new Point3d(cube.X, cube.Y, cube.Z), cube.Value) { }

	public int X => Position.X;
	public int Y => Position.Y;
	public int Z => Position.Z;

	public static implicit operator (int x, int y, int z, T Value)(Cube<T> c) {
		c.Deconstruct(out Point3d point, out T value);
		return (point.X, point.Y, point.Z, value);
	}

	public static implicit operator T(Cube<T> c) => c.Value;
	public static implicit operator Point3d(Cube<T> c) => c.Position;
	public static implicit operator (int X, int Y, int Z)(Cube<T> c) => c.Position;

	public void Deconstruct(out int x, out int y, out int z, out T value) {
		x = Position.X;
		y = Position.Y;
		z = Position.Z;
		value = Value;
	}

	private string DebugDisplay => $$"""{{nameof(Cube<T>)}} ({{X}}, {{Y}} {{Z}}) = {{Value}}""";
}
