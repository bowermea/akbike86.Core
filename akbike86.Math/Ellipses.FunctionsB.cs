using System.Runtime.CompilerServices;

namespace akbike86.Geometry
{
    public static partial class Ellipses
    {
        public static partial class Functions
        {
            /// <summary>
            /// Provides the following methods to implement ellipse equation to find the length of the semi-minor axis (<b>b</b>)
            /// <code>BFromAC: b = √(a² - c²)</code>
            /// <code>BFromAE: b = a√(1 - e²)</code>
            /// <code>BFromCE: b = c / e * √(1 - e²)</code>
            /// <code>BFromAL: b = √(a * l)</code>
            /// <code>BFromCL: b = √(l * (l + √(l² + 4c²)) / 2)</code>
            /// <code>BFromEL: b = l / √(1 - e²)</code>
            /// <para>Squares:</para>
            /// <code>B2FromA2C2: b² = a² - c²</code>
            /// <code>B2FromA2E2: b² = a²(1 - e²)</code>
            /// <code>B2FromC2E2: b² = c² / e² - c²</code>
            /// <code>B2FromA2L2: b² = √(a² * l²)</code>
            /// <code>B2FromC2L2: b² = (l² + √(l² * (l² + 4c²))) / 2</code>
            /// <code>B2FromE2L2: b² = l² / (1 - e²)</code>
            /// </summary>
            public static class B
            {

                /// <summary> 
                /// Calculate semi-minor axis (<c>b</c>) from semi-major axis (<c>a</c>) and linear eccentricity (<c>c</c>) lengths
                /// <code>b = √(a² - c²)</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="c">linear eccentricity length</param>
                /// <returns>semi-minor axis (<c>b</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double BFromAC(double a, double c) => System.Math.Sqrt((a * a) - (c * c));

                /// <summary>
                /// Calculate semi-minor axis (<c>b</c>) from semi-major axis (<c>a</c>) length and elliptic eccentricity (<c>e</c>)
                /// <code>b = a√(1 - e²)</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>semi-major axis (<c>a</c>) 
                /// <param name="e">elliptic eccentricity</param>elliptic eccentricity (<c>e</c>)
                /// <returns>semi-minor axis (<c>b</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double BFromAE(double a, double e) => a * System.Math.Sqrt(1 - (e * e));

                /// <summary>
                /// Calculate semi-minor axis (<c>b</c>) from linear eccentricity (<c>c</c>) length and elliptic eccentricity (<c>e</c>)
                /// <code>b = c / e * √(1 - e²)</code>
                /// </summary>
                /// <param name="c">linear eccentricity length</param>
                /// <param name="e">elliptic eccentricity</param>
                /// <returns>semi-minor axis (<c>b</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double BFromCE(double c, double e) => c / e * System.Math.Sqrt(1 - (e * e)); // c * Math.Sqrt((1 / e / e) - 1)

                /// <summary>
                /// Calculate semi-minor axis (<c>b</c>) from semi-major axis (<c>a</c>) and semi-latus rectum (<c>l</c>) lengths
                /// <code>b = √(a * l)</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>semi-minor axis (<c>b</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double BFromAL(double a, double l) => System.Math.Sqrt(a * l);

                /// <summary>
                /// Calculate semi-minor axis (<c>b</c>) from linear eccentricity (<c>c</c>) and semi-latus rectum (<c>l</c>) lengths
                /// <code>b = √(l * (l + √(l² + 4c²)) / 2)</code>
                /// </summary>
                /// <param name="c">linear eccentricity length</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>semi-minor axis (<c>b</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double BFromCL(double c, double l) => System.Math.Sqrt(l * (l + System.Math.Sqrt(l * l + 4 * c * c)) / 2);

                /// <summary>
                /// Calculate semi-minor axis (<c>b</c>) from elliptic eccentricity (<c>e</c>) and semi-latus rectum (<c>l</c>) length
                /// <code>b = l / √(1 - e²)</code>
                /// </summary>
                /// <param name="e">elliptic eccentricity</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>semi-minor axis (<c>b</c>) length</returns>
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double BFromEL(double e, double l) => l / System.Math.Sqrt(1 - (e * e));


                /// <summary>
                /// Calculate the square of the semi-minor axis (<c>b²</c>) from the squares of the semi-major axis (<c>a²</c>) and linear eccentricity (<c>c²</c>)
                /// <code>b² = a² - c²</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <returns>square of the semi-minor axis (<c>b²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double B2FromA2C2(double a2, double c2) => a2 - c2;

                /// <summary>
                /// Calculate the square of the semi-minor axis (<c>b²</c>) from the squares of the semi-major axis (<c>a²</c>) and elliptic eccentricity (<c>e²</c>)
                /// <code>b² = a²(1 - e²)</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <returns>square of the semi-minor axis (<c>b²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double B2FromA2E2(double a2, double e2) => a2 * (1 - e2);

                /// <summary>
                /// Calculate the square of the semi-minor axis (<c>b²</c>) from the squares of the linear eccentricity (<c>c²</c>) and elliptic eccentricity (<c>e²</c>)
                /// <code>b² = c² / e² - c²</code>
                /// </summary>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <returns>square of the semi-minor axis (<c>b²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double B2FromC2E2(double c2, double e2) => (c2 / e2) - c2;

                /// <summary>
                /// Calculate the square of the semi-minor axis (<c>b²</c>) from the squares of the semi-major axis (<c>a²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>b² = √(a² * l²)</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the semi-minor axis (<c>b²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double B2FromA2L2(double a2, double l2) => System.Math.Sqrt(a2 * l2);

                /// <summary>
                /// Calculate the square of the semi-minor axis (<c>b²</c>) from the squares of the linear eccentricity (<c>c²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>b² = (l² + √(l² * (l² + 4c²))) / 2</code>
                /// </summary>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the semi-minor axis (<c>b²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double B2FromC2L2(double c2, double l2) => (l2 + System.Math.Sqrt(l2 * (l2 + (4 * c2)))) / 2;

                /// <summary>
                /// Calculate the square of the semi-minor axis (<c>b²</c>) from the squares of the elliptic eccentricity (<c>e²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>b² = l² / (1 - e²)</code>
                /// </summary>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the semi-minor axis (<c>b²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double B2FromE2L2(double e2, double l2) => l2 / (1 - e2);
            }
        }
    }
}
