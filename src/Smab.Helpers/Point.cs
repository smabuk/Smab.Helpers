namespace Smab.Helpers;
public record struct Point(int X, int Y)
{
    public Point((int X, int Y) point) : this(point.X, point.Y) { }

    //public static implicit operator Point((int x, int y) p) =>
    //    new(p.x, p.y);

    public static implicit operator (int x, int y)(Point p)
    {
        p.Deconstruct(out int x, out int y);
        return (x, y);
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public static Point operator +(Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);
    public static Point operator +(Point p1, (int X, int Y) p2) => new(p1.X + p2.X, p1.Y + p2.Y);
    public static Point operator +((int X, int Y) p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);

    public static Point operator -(Point p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);
    public static Point operator -(Point p1, (int X, int Y) p2) => new(p1.X - p2.X, p1.Y - p2.Y);
    public static Point operator -((int X, int Y) p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);
};
