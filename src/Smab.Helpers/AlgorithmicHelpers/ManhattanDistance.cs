namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

	extension<T>((T X, T Y) point1) where T : INumber<T> {
		// 2d
		public T ManhattanDistance((T X, T Y) point2) => T.Abs(point1.X - point2.X) + T.Abs(point1.Y - point2.Y);
	}

	extension<T>(IEnumerable<(T X, T Y)> points) where T : INumber<T> {
		public T ManhattanDistance() => points.Count() == 2
			? T.Abs(points.First().X - points.Last().X) + T.Abs(points.First().Y - points.Last().Y)
			: throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");
	}

	extension(IEnumerable<Point> points) {
		public int ManhattanDistance()
		=> points.Count() == 2
			? int.Abs(points.First().X - points.Last().X) + int.Abs(points.First().Y - points.Last().Y)
			: throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");
	}

	extension(Point point1) {
		public int ManhattanDistance(Point point2) => Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
	}

	extension(IEnumerable<IEnumerable<Point>> listOfPoints) {
		public IEnumerable<long> ManhattanDistances()
		=> listOfPoints.Select(pair => (long)pair.ManhattanDistance());
	}

	extension<T>((T X, T Y, T Z) point1) where T : INumber<T> {
		// 3d
		public T ManhattanDistance((T X, T Y, T Z) point2) => T.Abs(point1.X - point2.X) + T.Abs(point1.Y - point2.Y) + T.Abs(point1.Z - point2.Z);
	}

	extension<T>(IEnumerable<(T X, T Y, T Z)> points) where T : INumber<T> {
		public T ManhattanDistance() => points.Count() == 2
			? T.Abs(points.First().X - points.Last().X) + T.Abs(points.First().Y - points.Last().Y + T.Abs(points.First().Z - points.Last().Z))
			: throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");
	}

	extension(IEnumerable<Point3d> points) {
		public int ManhattanDistance()
		=> points.Count() == 2
			? int.Abs(points.First().X - points.Last().X) + int.Abs(points.First().Y - points.Last().Y) + int.Abs(points.First().Z - points.Last().Z)
			: throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");
	}

	extension(Point3d point1) {
		public int ManhattanDistance(Point3d point2) => Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y) + Math.Abs(point1.Z - point2.Z);
	}

	extension(IEnumerable<IEnumerable<Point3d>> listOfPoints) {
		public IEnumerable<long> ManhattanDistances()
		=> listOfPoints.Select(pair => (long)pair.ManhattanDistance());
	}
}
