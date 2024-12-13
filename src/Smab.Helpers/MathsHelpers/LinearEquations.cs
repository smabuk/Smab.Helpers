namespace Smab.Helpers;

public static partial class MathsHelpers {
	/// <summary>
	/// Attempts to solve 2 equations
	///    ax + bx = cx   and ay + by = cy
	/// </summary>
	/// <param name="ax"></param>
	/// <param name="bx"></param>
	/// <param name="cx"></param>
	/// <param name="ay"></param>
	/// <param name="by"></param>
	/// <param name="cy"></param>
	/// <param name="result"></param>
	/// <returns>will return TRUE and tha values A and B, but only if those values are integer numbers. Otherwise returns false.</returns>
	public static bool TrySolveLinearEquations(long ax, long bx, long cx, long ay, long by, long cy, out (long A, long B) result) {

		result = (0, 0);

		//long ax = equation.ax;
		//long bx = equation.bx;
		//long cx = equation.cx;
		//long ay = equation.ay;
		//long by = equation.by;
		//long cy = equation.cy;

		long axby = ax * by;
		long pxby = cx * by;

		long aybx = ay * bx;
		long pybx = cy * bx;

		long X = axby - aybx;
		long P = pxby - pybx;

		(long a, long remainder) = long.DivRem(P, X);
		if (remainder is not 0) {
			return false;
		}

		(long b, remainder) = long.DivRem(cx - (ax * a), bx);
		if (remainder is not 0) {
			return false;
		}

		result = (a, b);
		return true;
	}

}
