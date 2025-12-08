namespace Smab.Helpers;

public static partial class MathsHelpers {

	extension<T>(IEnumerable<T> numbers) where T : INumber<T> {
		/// <summary>
		/// Calculates the product of all numbers in the collection.
		/// </summary>
		/// <remarks>If the collection is empty, this method returns <see cref="INumber{T}.One"/> (the multiplicative identity,
		/// which is 1 for most numeric types). This follows the mathematical convention that the product of an empty set equals
		/// the multiplicative identity.</remarks>
		/// <returns>The product of all elements in the collection as a value of type <typeparamref name="T"/>, or
		/// <see cref="INumber{T}.One"/> if the collection is empty.</returns>
		public T Product() => numbers.Aggregate(T.One, (acc, x) => acc * x);
	}

	extension<TIn, TOut>(IEnumerable<TIn> numbers) where TIn : INumber<TIn> where TOut : INumber<TOut> {
		/// <summary>
		/// Calculates the product of all numbers in the collection, converting each element to type <typeparamref name="TOut"/>
		/// using checked arithmetic.
		/// </summary>
		/// <remarks>If the collection is empty, this method returns <see cref="INumber{T}.One"/> for type <typeparamref name="TOut"/>
		/// (the multiplicative identity). Each input element is converted to <typeparamref name="TOut"/> using
		/// <see cref="INumber{T}.CreateChecked"/>, which throws an <see cref="OverflowException"/> if the conversion or
		/// multiplication would result in overflow.</remarks>
		/// <returns>The product of all numbers in the collection, represented as a value of type <typeparamref name="TOut"/>, or
		/// <see cref="INumber{T}.One"/> if the collection is empty.</returns>
		public TOut Product() => numbers.Aggregate(TOut.One, (acc, x) => acc * TOut.CreateChecked(x));
	}
}
