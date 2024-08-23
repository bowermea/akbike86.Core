using System.Runtime.CompilerServices;

namespace akbike86.Geometry
{
    public static partial class Ellipses
    {
        public static partial class Functions
        {
			/// <summary>
			/// Provides the following methods to implement ellipse equation to find the length of the semi-major axis (<b>a</b>)
			/// <code>AFromBC: a = √(b² - c²)</code>
			/// <code>AFromBE: a = b / √(1 - e²)</code>
			/// <code>AFromCE: a = c / e</code>
			/// <code>AFromBL: a = b² / l</code>
			/// <code>AFromCL: a = (l + √(l² + 4c²)) / 2</code>
			/// <code>AFromEL: a = l /(1 - e²)</code>
			/// <para>Squares:</para>
			/// <code>A2FromB2C2: a² = b² - c²</code>
			/// <code>A2FromB2E2: a² = b² / (1 - e²)</code>
			/// <code>A2FromC2E2: a² = c² / e²</code>
			/// <code>A2FromB2L2: a² = b² * b² / l²</code>
			/// <code>A2FromC2L2: a² = (l² + √(l² * (l² + 4c²))) / 2 + c²</code>
			/// <code>A2FromE2L2: a² = l² / (1 + e²)²</code>
			/// </summary>
			public static class A
            {
				/// <summary>
				/// Calculate semi-major axis (<c>a</c>) from semi-minor axis (<c>b</c>) and linear eccentricity (<c>c</c>) lengths
				/// <code>a = √(b² - c²)</code>
				/// </summary>
				/// <param name="b">semi-minor axis length</param>
				/// <param name="c">linear eccentricity length</param>
				/// <returns>semi-major axis (<c>a</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double AFromBC(double b, double c) => System.Math.Sqrt((b * b) + (c * c));

				/// <summary>
				/// Calculate semi-major axis (<c>a</c>) from semi-minor axis (<c>b</c>) length and elliptic eccentricity (<c>e</c>)
				/// <code>a = b / √(1 - e²)</code>
				/// </summary>
				/// <param name="b">semi-minor axis length</param>
				/// <param name="e">elliptic eccentricity</param>
				/// <returns>semi-major axis (a) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double AFromBE(double b, double e) => b / System.Math.Sqrt(1 - (e * e));

				/// <summary>
				/// Calculate semi-major axis (<c>a</c>) from linear eccentricity (<c>c</c>) and elliptic eccentricity (<c>e</c>)
				/// <code>a = c / e</code>
				/// </summary>
				/// <param name="c">linear eccentricity length</param>
				/// <param name="e">elliptic eccentricity</param>
				/// <returns>semi-major axis (<c>a</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double AFromCE(double c, double e) => c / e;

				/// <summary>
				/// Calculate semi-major axis (<c>a</c>) from semi-minor axis (<c>b</c>) and semi-latus rectum (<c>l</c>) lengths
				/// <code>a = b² / l</code>
				/// </summary>
				/// <param name="b">semi-minor axis length</param>
				/// <param name="l">semi-latus rectum length</param>
				/// <returns>semi-major axis (<c>a</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double AFromBL(double b, double l) => b * b / l;

				/// <summary>
				/// Calculate semi-major axis (<c>a</c>) from linear eccentricity (<c>c</c>) and semi-latus rectum (<c>l</c>) length
				/// <code>a = (l + √(l² + 4c²)) / 2</code>
				/// </summary>
				/// <param name="c">linear eccentricity length</param>
				/// <param name="l">semi-latus rectum length</param>
				/// <returns>semi-major axis (<c>a</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double AFromCL(double c, double l) => (l + System.Math.Sqrt((l * l) + (4 * c * c))) / 2;

				/// <summary>
				/// Calculate semi-major axis (<c>a</c>) from elliptic eccentricity (<c>e</c>) and semi-latus rectum (<c>l</c>) length
				/// <code>a = l /(1 - e²)</code>
				/// </summary>
				/// <param name="e">elliptic eccentricity</param>
				/// <param name="l">semi-latus rectum length</param>
				/// <returns>semi-major axis (<c>a</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double AFromEL(double e, double l) => l / (1 - e * e);



				/// <summary>
				/// Calculate the square of the semi-major axis (<c>a²</c>) from the squares of the semi-minor axis (<c>b²</c>) and linear eccentricity (<c>c²</c>)
				/// <code>a² = b² - c²</code>
				/// </summary>
				/// <param name="b2">square of the semi-minor axis</param>
				/// <param name="c2">square of the linear eccentricity</param>
				/// <returns>square of the semi-major axis (<c>a²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double A2FromB2C2(double b2, double c2) => b2 + c2;

				/// <summary>
				/// Calculate the square of the semi-major axis (<c>a²</c>) from the squares of the semi-minor axis (<c>b²</c>) and elliptic eccentricity (<c>e²</c>)
				/// <code>a² = b² / (1 - e²)</code>
				/// </summary>
				/// <param name="b2">square of the semi-minor axis</param>
				/// <param name="e2">square of the elliptic eccentricity</param>
				/// <returns>square of the semi-major axis (<c>a²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double A2FromB2E2(double b2, double e2) => b2 / (1 - e2);

				/// <summary>
				/// Calculate the square of the semi-major axis (<c>a²</c>) from the squares of the linear eccentricity (<c>c²</c>) and elliptic eccentricity (<c>e²</c>)
				/// <code>a² = c² / e²</code>
				/// </summary>
				/// <param name="c2">square of the linear eccentricity</param>
				/// <param name="e2">square of the elliptic eccentricity</param>
				/// <returns>square of the semi-major axis (<c>a²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double A2FromC2E2(double c2, double e2) => c2 / e2;

				/// <summary>
				/// Calculate the square of the semi-major axis (<c>a²</c>) from the squares of the semi-minor axis (<c>b²</c>) and semi-latus rectum (<c>l²</c>)
				/// <code>a² = b² * b² / l²</code>
				/// </summary>
				/// <param name="b2">square of the semi-minor axis</param>
				/// <param name="l2">square of the semi-latus rectum</param>
				/// <returns>square of the semi-major axis (<c>a²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double A2FromB2L2(double b2, double l2) => b2 * b2 / l2;

				/// <summary>
				/// Calculate the square of the semi-major axis (<c>a²</c>) from the squares of the linear eccentricity (<c>c²</c>) and semi-latus rectum (<c>l²</c>)
				/// <code>a² = (l² + √(l² * (l² + 4c²))) / 2 + c²</code>
				/// </summary>
				/// <param name="c2">square of the linear eccentricity</param>
				/// <param name="l2">square of the semi-latus rectum</param>
				/// <returns>square of the semi-major axis (<c>a²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double A2FromC2L2(double c2, double l2) => ((l2 + System.Math.Sqrt(l2 * (l2 + (4 * c2)))) / 2) + c2;

				/// <summary>
				/// Calculate the square of the semi-major axis (<c>a²</c>) from the squares of the elliptic eccentricity (<c>e²</c>) and semi-latus rectum (<c>l²</c>)
				/// <code>a² = l² / (1 + e²)²</code>
				/// </summary>
				/// <param name="e2">square of the elliptic eccentricity</param>
				/// <param name="l2">square of the semi-latus rectum</param>
				/// <returns>square of the semi-major axis (<c>a²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public static double A2FromE2L2(double e2, double l2) => l2 / (1 - e2) / (1 - e2);
			}
		}
    }
}
