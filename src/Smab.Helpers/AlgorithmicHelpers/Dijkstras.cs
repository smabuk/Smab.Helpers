namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

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
	///          for each neighbour v of u:              // only v that are still in Q
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

			foreach ((int x, int y, T value) in grid.GetAdjacentsAsCells(cell.Index)) {
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
}
