﻿using System.Numerics;

namespace Smab.Helpers;
public static partial class AlgorithmicHelpers {
	public static T ManhattanDistance<T>(this (T X, T Y) point1, (T X, T Y) point2) where T : INumber<T>
		=> T.Abs(point1.X - point2.X) + T.Abs(point1.Y - point2.Y);

	public static T ManhattanDistance<T>(this IEnumerable<(T X, T Y)> points) where T : INumber<T>
		=> points.Count() == 2
			? T.Abs(points.First().X - points.Last().X) + T.Abs(points.First().Y - points.Last().Y)
			: throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");

	public static int ManhattanDistance(this IEnumerable<Point> points)
		=> points.Count() == 2
			? int.Abs(points.First().X - points.Last().X) + int.Abs(points.First().Y - points.Last().Y)
			: throw new InvalidOperationException($"You have {points.Count()} elements and there must be exactly 2.");

	public static int ManhattanDistance(this Point point1, Point point2) => Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);

	public static IEnumerable<long> ManhattanDistances(this IEnumerable<IEnumerable<Point>> listOfPoints)
		=> listOfPoints.Select(pair => (long)pair.ManhattanDistance());
}
