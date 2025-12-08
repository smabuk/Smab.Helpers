namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

	extension<T>((T X, T Y) point1) where T : INumber<T> {
		// 2d
		public double EuclideanDistance((T X, T Y) point2) {
			double x1 = double.CreateChecked(point1.X), y1 = double.CreateChecked(point1.Y);
			double x2 = double.CreateChecked(point2.X), y2 = double.CreateChecked(point2.Y);
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}
	}

	extension<T>(IEnumerable<(T X, T Y)> points) where T : INumber<T> {
		public double EuclideanDistance() {
			if (points.Count() != 2) {
				throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");
			}
			double x1 = double.CreateChecked(points.First().X), y1 = double.CreateChecked(points.First().Y);
			double x2 = double.CreateChecked(points.Last().X), y2 = double.CreateChecked(points.Last().Y);
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}
	}

	extension(IEnumerable<Point> points) {
		public double EuclideanDistance() {
			if (points.Count() != 2) {
				throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");
			}
			double x1 = points.First().X, y1 = points.First().Y;
			double x2 = points.Last().X, y2 = points.Last().Y;
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}
	}

	extension(Point point1) {
		public double EuclideanDistance(Point point2) {
			double x1 = point1.X, y1 = point1.Y;
			double x2 = point2.X, y2 = point2.Y;
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}
	}

	extension(IEnumerable<IEnumerable<Point>> listOfPoints) {
		public IEnumerable<double> EuclideanDistances()
		=> listOfPoints.Select(pair => pair.EuclideanDistance());
	}

	extension<T>((T X, T Y, T Z) point1) where T : INumber<T> {
		// 3d
		public double EuclideanDistance((T X, T Y, T Z) point2) {
			double x1 = double.CreateChecked(point1.X), y1 = double.CreateChecked(point1.Y), z1 = double.CreateChecked(point1.Z);
			double x2 = double.CreateChecked(point2.X), y2 = double.CreateChecked(point2.Y), z2 = double.CreateChecked(point2.Z);
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
		}
	}

	extension<T>(IEnumerable<(T X, T Y, T Z)> points) where T : INumber<T> {
		public double EuclideanDistance() {
			if (points.Count() != 2) {
				throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");
			}
			double x1 = double.CreateChecked(points.First().X), y1 = double.CreateChecked(points.First().Y), z1 = double.CreateChecked(points.First().Z);
			double x2 = double.CreateChecked(points.Last().X), y2 = double.CreateChecked(points.Last().Y), z2 = double.CreateChecked(points.Last().Z);
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
		}
	}

	extension(IEnumerable<Point3d> points) {
		public double EuclideanDistance() {
			if (points.Count() != 2) {
				throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");
			}
			double x1 = points.First().X, y1 = points.First().Y, z1 = points.First().Z;
			double x2 = points.Last().X, y2 = points.Last().Y, z2 = points.Last().Z;
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
		}
	}

	extension(Point3d point1) {
		public double EuclideanDistance(Point3d point2) {
			double x1 = point1.X, y1 = point1.Y, z1 = point1.Z;
			double x2 = point2.X, y2 = point2.Y, z2 = point2.Z;
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
		}
	}

	extension(IEnumerable<IEnumerable<Point3d>> listOfPoints) {
		public IEnumerable<double> EuclideanDistances()
		=> listOfPoints.Select(pair => pair.EuclideanDistance());
	}
}
