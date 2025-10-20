using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {
	extension<T>(T value) where T : INumber<T> {
		/// <summary>
		/// Determines whether the specified value is an even integer.
		/// </summary>
		/// <remarks>This method uses the <see cref="INumber{T}.IsEvenInteger(T)"/> method to determine if the value is
		/// even.</remarks>
		/// <typeparam name="T">The numeric type of the value. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="value">The value to evaluate.</param>
		/// <returns><see langword="true"/> if the specified value is an even integer; otherwise, <see langword="false"/>.</returns>
		public bool IsEven() => T.IsEvenInteger(value);

		/// <summary>
		/// Determines whether the specified value is an odd integer.
		/// </summary>
		/// <remarks>This method uses the <see cref="INumber{T}.IsOddInteger(T)"/> method to determine if the value is
		/// odd.</remarks>
		/// <typeparam name="T">The numeric type of the value. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="value">The value to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="value"/> is an odd integer; otherwise, <see langword="false"/>.</returns>
		public bool IsOdd() => T.IsOddInteger(value);

		/// <summary>
		/// Determines whether the specified value is an integer.
		/// </summary>
		/// <remarks>This method uses the <see cref="INumber{T}.IsInteger(T)"/> implementation of the numeric type
		/// <typeparamref name="T"/>  to determine whether the value is an integer.</remarks>
		/// <typeparam name="T">The numeric type of the value. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="value">The value to evaluate.</param>
		/// <returns><see langword="true"/> if the specified value is an integer; otherwise, <see langword="false"/>.</returns>
		public bool IsInteger() => T.IsInteger(value);

		/// <summary>
		/// Determines whether the specified value is not a number (NaN).
		/// </summary>
		/// <remarks>This method is an extension method for numeric types that implement <see cref="INumber{T}"/>. It
		/// provides a type-safe way to check for NaN values across different numeric types.</remarks>
		/// <typeparam name="T">The numeric type of the value. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="value">The value to check for NaN.</param>
		/// <returns><see langword="true"/> if the specified value is NaN; otherwise, <see langword="false"/>.</returns>
		public bool IsNaN() => T.IsNaN(value);

		/// <summary>
		/// Determines whether the specified numeric value is negative.
		/// </summary>
		/// <remarks>This method uses the <see cref="INumber{T}.IsNegative(T)"/> implementation of the numeric type
		/// <typeparamref name="T"/>.</remarks>
		/// <typeparam name="T">The numeric type of the value. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="value">The numeric value to evaluate.</param>
		/// <returns><see langword="true"/> if the specified value is negative; otherwise, <see langword="false"/>.</returns>
		public bool IsNegative() => T.IsNegative(value);

		/// <summary>
		/// Determines whether the specified numeric value is positive.
		/// </summary>
		/// <remarks>This method uses the <see cref="INumber{T}.IsPositive(T)"/> method to determine if the value is
		/// positive.</remarks>
		/// <typeparam name="T">The numeric type of the value. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="value">The numeric value to evaluate.</param>
		/// <returns><see langword="true"/> if the specified value is positive; otherwise, <see langword="false"/>.</returns>
		public bool IsPositive() => T.IsPositive(value);

		/// <summary>
		/// Determines whether the specified value is equal to zero.
		/// </summary>
		/// <remarks>This method uses the <see cref="INumber{T}.IsZero(T)"/> method to determine if the value is
		/// zero.</remarks>
		/// <typeparam name="T">The numeric type of the value. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="value">The value to check.</param>
		/// <returns><see langword="true"/> if the specified value is equal to zero; otherwise, <see langword="false"/>.</returns>
		public bool IsZero() => T.IsZero(value);
	}
}
