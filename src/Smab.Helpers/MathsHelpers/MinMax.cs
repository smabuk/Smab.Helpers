using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {
	extension<T>(T number1) where T : INumber<T> {
		/// <summary>
		/// Determines the minimum and maximum values between two numbers.
		/// </summary>
		/// <remarks>This method compares the two input numbers and returns a tuple where the first element is the
		/// smaller of the two numbers and the second element is the larger. If the numbers are equal, both elements of the
		/// tuple will have the same value.</remarks>
		/// <typeparam name="T">The numeric type of the input values. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="number1">The first number to compare.</param>
		/// <param name="number2">The second number to compare.</param>
		/// <returns>A tuple containing the minimum value as <c>Min</c> and the maximum value as <c>Max</c>.</returns>
		public (T Min, T Max) MinMax(T number2) => number1 < number2 ? (number1, number2) : (number2, number1);
	}

	extension<T>((T number1, T number2) tuple) where T : INumber<T> {
		/// <summary>
		/// Determines the minimum and maximum values from a tuple of two numbers.
		/// </summary>
		/// <remarks>This method uses the comparison operators defined by the <see cref="INumber{T}"/> interface to
		/// determine the order of the values.</remarks>
		/// <typeparam name="T">The numeric type of the tuple elements. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="tuple">A tuple containing two numeric values to compare.</param>
		/// <returns>A tuple where the first element is the smaller of the two input values, and the second element is the larger.</returns>
		public (T Min, T Max) MinMax() => tuple.number1 < tuple.number2 ? (tuple.number1, tuple.number2) : (tuple.number2, tuple.number1);
	}

	extension(Point point) {
		/// <summary>
		/// Determines the minimum and maximum values between the X and Y coordinates of the specified <see cref="Point"/>.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> instance whose X and Y coordinates are compared.</param>
		/// <returns>A tuple containing the minimum and maximum values of the X and Y coordinates. The first item in the tuple is the
		/// minimum value, and the second item is the maximum value.</returns>
		public (int Min, int Max) MinMax()
			=> point.X < point.Y ? (point.X, point.Y) : (point.Y, point.X);
	}

	extension<T>(IEnumerable<T> numbers) where T : INumber<T> {
		/// <summary>
		/// Returns the minimum and maximum values from a sequence of numbers.
		/// </summary>
		/// <remarks>This method iterates through the sequence once to determine the minimum and maximum
		/// values.</remarks>
		/// <typeparam name="T">The numeric type of the elements in the sequence. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="numbers">The sequence of numbers to evaluate. Must not be null or empty.</param>
		/// <returns>A tuple containing the minimum value as <see cref="ValueTuple{T1, T2}.Item1"/> and the maximum value as <see
		/// cref="ValueTuple{T1, T2}.Item2"/>.</returns>
		public (T Min, T Max) MinMax() {
			T first = numbers.First();
			T min = first;
			T max = first;

			foreach (T number in numbers.Skip(1)) {
				min = T.MinNumber(min, number);
				max = T.MaxNumber(max, number);
			}
			return (min, max);
		}
	}

	extension<T>(IEnumerable<(T number1, T number2)> tuples) where T : INumber<T> {
		/// <summary>
		/// Finds the minimum and maximum values from a sequence of tuples containing two numbers each.
		/// </summary>
		/// <remarks>This method processes all tuples in the input sequence and evaluates both elements of each tuple to
		/// determine the overall minimum and maximum values. If the sequence is empty, the behavior depends on the
		/// implementation of the <see cref="INumber{T}"/> type.</remarks>
		/// <typeparam name="T">The numeric type of the values in the tuples. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="tuples">A sequence of tuples, where each tuple contains two numeric values.</param>
		/// <returns>A tuple containing the minimum and maximum values across all the numbers in the input sequence. The <c>Min</c>
		/// field represents the smallest value, and the <c>Max</c> field represents the largest value.</returns>
		public (T Min, T Max) MinMax() => tuples.SelectMany(((T, T) number) => (T[])[number.Item1, number.Item2]).MinMax<T>();
	}

	extension(IEnumerable<Point> points) {
		/// <summary>
		/// Determines the minimum and maximum values of the X and Y coordinates from a sequence of <see cref="Point"/>
		/// objects.
		/// </summary>
		/// <remarks>This method evaluates the X and Y coordinates of all <see cref="Point"/> objects in the sequence
		/// and returns the overall minimum and maximum values. If the sequence is empty, the behavior depends on the
		/// implementation of the underlying <c>MinMax</c> method.</remarks>
		/// <param name="points">The sequence of <see cref="Point"/> objects to evaluate. Cannot be null.</param>
		/// <returns>A tuple containing the minimum and maximum values of the X and Y coordinates in the sequence. The first item of the
		/// tuple represents the minimum value, and the second item represents the maximum value.</returns>
		public (int Min, int Max) MinMax()
			=> points.Select(point => (point.X, point.Y).MinMax()).MinMax<int>();
	}
}
