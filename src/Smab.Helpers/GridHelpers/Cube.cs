namespace Smab.Helpers;

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

	public void Deconstruct(out int x, out int y, out int z, out T value) {
		x = Position.X;
		y = Position.Y;
		z = Position.Z;
		value = Value;
	}
}
