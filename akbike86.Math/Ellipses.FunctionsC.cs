using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Geometry
{
    public static partial class Ellipses
    {
        public static partial class Functions
        {
            /// <summary>
            /// Provides the following methods to implement ellipse equation to find the linear eccentricity (<b>c</b>)
            /// <code>CFromAB: c = √(a² - b²)</code>
            /// <code>CFromAE: c = a * e</code>
            /// <code>CFromBE: c = b * e / √(1 - e²)</code>
            /// <code>CFromAL: c = √(a * (a - l))</code>
            /// <code>CFromBL: c = b * √((b² / l²) - 1)</code>
            /// <code>CFromEL: c = l * e / (1 - e²)</code>
            /// <para>Squares:</para>
            /// <code>C2FromA2B2: c² = a² - b²</code>
            /// <code>C2FromA2E2: c² = a²e²</code>
            /// <code>C2FromB2E2: c² = b²e² / (1 - e²)</code>
            /// <code>C2FromA2L2: c² = a² - √(a² * l²)</code>
            /// <code>C2FromB2L2: c² = (b²b² / l²) - b² </code>
            /// <code>C2FromE2L2: c² = e²l² / (1 - e²)²</code>
            /// </summary>
            public static class C
            {
                /// <summary> 
                /// Calculate linear eccentricity (<c>c</c>) from semi-major axis (<c>a</c>) and semi-minor axis (<c>b</c>) lengths
                /// <code>c = √(a² - b²)</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="b">semi-minor axis length</param>
                /// <returns>linear eccentricity (<c>c</c>) length</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double CFromAB(double a, double b) => System.Math.Sqrt((a * a) - (b * b));

                /// <summary> 
                /// Calculate linear eccentricity (<c>c</c>) from semi-major axis (<c>a</c>) length and elliptic eccentricity (<c>e</c>)
                /// <code>c = a * e</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="e">elliptic eccentricity</param>
                /// <returns>linear eccentricity (<c>c</c>) length</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double CFromAE(double a, double e) => a * e;

                /// <summary>
                /// Calculate linear eccentricity (<c>c</c>) from semi-minor axis (<c>b</c>) length and elliptic eccentricity (<c>e</c>)
                /// <code>c = b * e / √(1 - e²)</code>
                /// </summary>
                /// <param name="b">semi-minor axis length</param>
                /// <param name="e">elliptic eccentricity</param>
                /// <returns>linear eccentricity (<c>c</c>) length</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double CFromBE(double b, double e) => b * e / System.Math.Sqrt(1 - (e * e));

                /// <summary> 
                /// Calculate linear eccentricity (<c>c</c>) from semi-major axis (<c>a</c>) and semi-latus rectum (<c>l</c>) length
                /// <code>c = √(a * (a - l))</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>linear eccentricity (<c>c</c>) length</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double CFromAL(double a, double l) => System.Math.Sqrt(a * (a - l));

                /// <summary> 
                /// Calculate linear eccentricity (<c>c</c>) from semi-minor axis (<c>b</c>) and semi-latus rectum (<c>l</c>) length
                /// <code>c = b * √((b² / l²) - 1)</code>
                /// </summary>
                /// <param name="b">semi-minor axis length</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>linear eccentricity (<c>c</c>) length</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double CFromBL(double b, double l) => b * System.Math.Sqrt((b * b / l / l) - 1);

                /// <summary> 
                /// Calculate linear eccentricity (<c>c</c>) from elliptic eccentricity (<c>e</c>) and semi-latus rectum (<c>l</c>) length
                /// <code>c = l * e / (1 - e²)</code>
                /// </summary>
                /// <param name="e">elliptic eccentricity</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>linear eccentricity (<c>c</c>) length</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double CFromEL(double e, double l) => l * e / (1 - (e * e));



                /// <summary>
                /// Calculate the square of the linear eccentricity (<c>c²</c>) from the squares of the semi-major axis (<c>a²</c>) and semi-minor axis (<c>b²</c>)
                /// <code>c² = a² - b²</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <returns>square of the linear eccentricity (<c>c²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double C2FromA2B2(double a2, double b2) => a2 - b2;

                /// <summary>
                /// Calculate the square of the linear eccentricity (<c>c²</c>) from the squares of the semi-major axis (<c>a²</c>) and elliptic eccentricity (<c>e²</c>)
                /// <code>c² = a²e²</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <returns>square of the linear eccentricity (<c>c²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double C2FromA2E2(double a2, double e2) => a2 * e2;

                /// <summary>
                /// Calculate the square of the linear eccentricity (<c>c²</c>) from the squares of the semi-minor axis (<c>b²</c>) and elliptic eccentricity (<c>e²</c>)
                /// <code>c² = b²e² / (1 - e²)</code>
                /// </summary>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <returns>square of the linear eccentricity (<c>c²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double C2FromB2E2(double b2, double e2) => b2 * e2 / (1 - e2);

                /// <summary>
                /// Calculate the square of the linear eccentricity (<c>c²</c>) from the squares of the semi-major axis (<c>a²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>c² = a² - √(a² * l²)</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the linear eccentricity (<c>c²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double C2FromA2L2(double a2, double l2) => a2 - System.Math.Sqrt(a2 * l2);

                /// <summary>
                /// Calculate the square of the linear eccentricity (<c>c²</c>) from the squares of the semi-minor axis (<c>b²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>c² = (b²b² / l²) - b² </code>
                /// </summary>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the linear eccentricity (<c>c²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double C2FromB2L2(double b2, double l2) => (b2 * b2 / l2) - b2;

                /// <summary>
                /// Calculate the square of the linear eccentricity (<c>c²</c>) from the squares of the elliptic eccentricity (<c>e²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>c² = e²l² / (1 - e²)²</code>
                /// </summary>
                /// <param name="e2">square of the elliptic eccentricity</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the linear eccentricity (<c>c²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double C2FromE2L2(double e2, double l2) => e2 * l2 / (1 - e2) / (1 - e2);
            }
        }
    }
}
