﻿namespace Smab.Helpers;

[DebuggerDisplay("{DebugDisplay,nq}")]
public record Cell<T>(Point Index, T Value) {

	public Cell( int X, int Y, T Value)       : this(new Point(X, Y), Value) { }
	public Cell((int X, int Y, T Value) cell) : this(new Point(cell.X, cell.Y), cell.Value) { }

	public int X => Index.X;
	public int Y => Index.Y;

	public int Col => Index.X;
	public int Row => Index.Y;

	public static implicit operator (int x, int y, T Value)(Cell<T> c) {
		c.Deconstruct(out Point point, out T value);
		return (point.X, point.Y, value);
	}

	public static implicit operator	             T(Cell<T> c) => c.Value;
	public static implicit operator          Point(Cell<T> c) => c.Index;
	public static implicit operator (int X, int Y)(Cell<T> c) => c.Index;


	public void Deconstruct(out int x, out int y, out T value) {
		x = Index.X;
		y = Index.Y;
		value = Value;
	}

	private string DebugDisplay => $$"""{{nameof(Cell<T>)}} ({{Index.X}}, {{Index.Y}}) = {{Value}}""";
}
