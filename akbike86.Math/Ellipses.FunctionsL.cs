using System.Runtime.CompilerServices;

namespace akbike86.Geometry
{
    public static partial class Ellipses
    {
        public static partial class Functions
        {
            /// <summary>
            /// Provides the following methods to implement ellipse equation to find the length of the semi-latus rectum (<c>l</c>)
            /// <code>LFromAB: l = b² / a</code>
            /// <code>LFromAC: l = a - (c² / a)</code>
            /// <code>LFromBC: l = b² / √(b² + c²)</code>
            /// <code>LFromAE: l = a(1 - e²)</code>
            /// <code>LFromBE: l = b√(1 - e²)</code>
            /// <code>LFromCE: l = c / e - ce</code>
            /// <para>Squares:</para>
            /// <code>L2FromA2B2: l² = b²b² / a²</code>
            /// <code>L2FromA2C2: l² = a² + c²((c² / a²) - 2)</code>
            /// <code>L2FromB2C2: l² = b²b² / (b² + c²)</code>
            /// <code>L2FromA2E2: l² = a²(1 - e²)²</code>
            /// <code>L2FromB2E2: l² = b² - b²e²</code>
            /// <code>L2FromC2E2: l² = c²(e² + 1/e² - 2)</code>
            /// </summary>
            public static class L
            {
                /// <summary>
                /// Calculate semi-latus rectum (<c>l</c>) from semi-major axis (<c>a</c>) and semi-minor axis (<c>b</c>) lengths
                /// <code>l = b² / a</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="b">semi-minor axis length</param>
                /// <returns>semi-latus rectum (<c>l</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double LFromAB(double a, double b) => b * b / a;

                /// <summary>
                /// Calculate semi-latus rectum (<c>l</c>) from semi-major axis (<c>a</c>) and linear eccentricity (<c>c</c>) lengths
                /// <code>l = a - (c² / a)</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="c">linear eccentricity length</param>
                /// <returns>semi-latus rectum (<c>l</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double LFromAC(double a, double c) => a - (c * c / a);

                /// <summary>
                /// Calculate semi-latus rectum (<c>l</c>) from semi-minor axis (<c>b</c>) and linear eccentricity (<c>c</c>) lengths
                /// <code>l = b² / √(b² + c²)</code>
                /// </summary>
                /// <param name="b">semi-minor axis length</param>
                /// <param name="c">linear eccentricity length</param>
                /// <returns>semi-latus rectum (<c>l</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double LFromBC(double b, double c) => (b * b) / System.Math.Sqrt((b * b) + (c * c));

                /// <summary>
                /// Calculate semi-latus rectum (<c>l</c>) from semi-major axis (<c>a</c>) length and elliptic eccentricity (<c>e</c>)
                /// <code>l = a(1 - e²)</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="e">elliptic eccentricity</param>
                /// <returns>semi-latus rectum (<c>l</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double LFromAE(double a, double e) => a * (1 - (e * e));

                /// <summary>
                /// Calculate semi-latus rectum (<c>l</c>) from semi-minor axis (<c>b</c>) length and elliptic eccentricity (<c>e</c>)
                /// <code>l = b√(1 - e²)</code>
                /// </summary>
                /// <param name="b">semi-minor axis length</param>
                /// <param name="e">elliptic eccentricity</param>
                /// <returns>semi-latus rectum (<c>l</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double LFromBE(double b, double e) => b * System.Math.Sqrt(1 - (e * e));

                /// <summary>
                /// Calculate semi-latus rectum (<c>l</c>) from linear eccentricity (<c>c</c>) length and elliptic eccentricity (<c>e</c>)
                /// <code>l = c / e - ce</code>
                /// </summary>
                /// <param name="c">linear eccentricity length</param>
                /// <param name="e">elliptic eccentricity</param>
                /// <returns>semi-latus rectum (<c>l</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double LFromCE(double c, double e) => (c / e) - (c * e);



                /// <summary>
                /// Calculate the square of the semi-latus rectum (<c>l²</c>) from the squares of the semi-major axis (<c>a²</c>) and semi-minor axis (<c>b²</c>)
                /// <code>l² = b²b² / a²</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <returns>square of the semi-latus rectum (<c>l²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double L2FromA2B2(double a2, double b2) => b2 * b2 / a2;

                /// <summary>
                /// Calculate the square of the semi-latus rectum (<c>l²</c>) from the squares of the semi-major axis (<c>a²</c>) and linear eccentricity (<c>c²</c>)
                /// <code>l² = a² + c²((c² / a²) - 2)</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <returns>square of the semi-latus rectum (<c>l²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double L2FromA2C2(double a2, double c2) => a2 + (c2 * ((c2 / a2) - 2));

                /// <summary>
                /// Calculate the square of the semi-latus rectum (<c>l²</c>) from the squares of the semi-minor axis (<c>b²</c>) and linear eccentricity (<c>c²</c>)
                /// <code>l² = b²b² / (b² + c²)</code>
                /// </summary>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <returns>square of the semi-latus rectum (<c>l²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double L2FromB2C2(double b2, double c2) => (b2 * b2) / (b2 + c2);

                /// <summary>
                /// Calculate the square of the semi-latus rectum (<c>l²</c>) from the squares of the semi-major axis (<c>a²</c>) and elliptic eccentricity (<c>e²</c>)
                /// <code>l² = a²(1 - e²)²</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <returns>square of the semi-latus rectum (<c>l²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double L2FromA2E2(double a2, double e2) => a2 * (1 - e2) * (1 - e2);

                /// <summary>
                /// Calculate the square of the semi-latus rectum (<c>l²</c>) from the squares of the semi-minor axis (<c>b²</c>) and elliptic eccentricity (<c>e²</c>)
                /// <code>l² = b² - b²e²</code>
                /// </summary>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <returns>square of the semi-latus rectum (<c>l²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double L2FromB2E2(double b2, double e2) => b2 - (b2 * e2);

                /// <summary>
                /// Calculate the square of the semi-latus rectum (<c>l²</c>) from the squares of the linear eccentricity (<c>c²</c>) and elliptic eccentricity (<c>e²</c>)
                /// <code>l² = c² * (e² + 1/e² - 2)</code>
                /// </summary>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <returns>square of the semi-latus rectum (<c>l²</c>)</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double L2FromC2E2(double c2, double e2) => c2 * (e2 + (1 / e2) - 2);
            }
        }
    }
}