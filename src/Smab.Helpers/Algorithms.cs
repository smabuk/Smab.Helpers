using System.Numerics;

namespace Smab.Helpers;

public static class Algorithms {

	/// <summary>
	///  Dijkstra's algorithm
	/// 
	/// PseudoCode:
	///  function Dijkstra(Graph, source):
	///      dist[source] ← 0                           // Initialization
	/// 
	///      create vertex priority queue Q
	/// 
	///      for each vertex v in Graph:          
	///          if v ≠ source
	///              dist[v] ← INFINITY                 // Unknown distance from source to v
	///              prev[v] ← UNDEFINED                // Predecessor of v
	/// 
	///          Q.add_with_priority(v, dist[v])
	/// 
	/// 
	///      while Q is not empty:                      // The main loop
	///          u ← Q.extract_min()                    // Remove and return best vertex
	///          for each neighbor v of u:              // only v that are still in Q
	///              alt ← dist[u] + length(u, v)
	///              if alt < dist[v]
	///                  dist[v] ← alt
	///                  prev[v] ← u
	///                  Q.decrease_priority(v, alt)
	/// 
	///      return dist, prev
	/// 
	/// </summary>
	/// <see cref="https://en.wikipedia.org/wiki/Dijkstra's_algorithm"/>
	/// <param name="grid"></param>
	/// <param name="start"></param>
	/// <param name="end"></param>
	/// <returns>costs</returns>
	public static Dictionary<Point, T> DijkstrasBasedOnCellValue<T>(T[,] grid, Point start, Point end) where T : INumber<T> {

		PriorityQueue<Cell<T>, T> priorityQueue = new();
		priorityQueue.Enqueue(new(start, T.Zero), T.Zero);
		Dictionary<Point, T> costs = new() { { start, T.Zero } };

		while (priorityQueue.Count > 0) {
			Cell<T> cell = priorityQueue.Dequeue();

			foreach ((int x, int y, T value) in grid.GetAdjacentCells(cell.Index)) {
				Cell<T> neighbour = new(x, y, value);
				if (!costs.ContainsKey(neighbour.Index)) {
					T cost = costs[cell.Index] + neighbour.Value;
					costs[neighbour.Index] = cost;
					if (neighbour.Index == end) {
						break;
					}
					priorityQueue.Enqueue(neighbour, cost);
				}
			}
		}

		return costs;
	}

	public static T LowestCommonMultiple<T>(this IEnumerable<T> numbers) where T : INumber<T> => numbers.Aggregate(LowestCommonMultipleOf2Numbers);
	/// <summary>
	/// In arithmetic and number theory, the least common multiple, lowest common multiple, or smallest common 
	/// multiple of two integers a and b, usually denoted by lcm(a, b), is the smallest positive integer that 
	/// is divisible by both a and b.[1][2] Since division of integers by zero is undefined, this definition 
	/// has meaning only if a and b are both different from zero.[3] However, some authors define lcm(a, 0) as 
	/// 0 for all a, since 0 is the only common multiple of a and 0
	/// </summary>
	/// <see cref="https://en.wikipedia.org/wiki/Lowest_common_multiple"/>
	/// <typeparam name="T"></typeparam>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public static T LowestCommonMultipleOf2Numbers<T>(this T a, T b) where T : INumber<T> => T.Abs(a * b) / GreatestCommonDivisor(a, b);
	public static T GreatestCommonDivisor<T>(this T a, T b) where T : INumber<T> => b == T.Zero ? a : GreatestCommonDivisor(b, a % b);

	public static long LowestCommonMultiple(this IEnumerable<int> numbers) => numbers.Select(n => (long)n).Aggregate(LowestCommonMultipleOf2Numbers);
}
