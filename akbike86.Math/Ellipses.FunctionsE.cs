using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static akbike86.Geometry.Ellipses.Functions;

namespace akbike86.Geometry
{
    public static partial class Ellipses
    {
        public static partial class Functions
        {
            /// <summary>
            /// Provides the following methods to implement ellipse equation to find the elliptic eccentricity (<b>e</b>)
            /// <code>EFromAB: e = √(1 - (b² / a²))</code>
            /// <code>EFromAC: e = c / a</code>
            /// <code>EFromBC: e = c / √(b² + c²)</code>
            /// <code>EFromAL: e = √(1 - (l / a))</code>
            /// <code>EFromBL: e = √(1 - (l² / b²))</code>
            /// <code>EFromCL: e = (2c / l) + √(l² - 4c²))</code>
            /// <para>Squares:</para>
            /// <code>E2FromA2B2: e² = 1 - (b² / a²)</code>
            /// <code>E2FromA2C2: e² = c² * a²</code>
            /// <code>E2FromB2C2: e² = c² / (b² + c²)</code>
            /// <code>E2FromA2L2: e² = 1 - √(l² / a²)</code>
            /// <code>E2FromB2L2: e² = 1 - (l² / b²)</code>
            /// <code>E2FromC2L2: e² = 4c² / (l² * ((l² / 4) + c²))</code>
            /// <para>Misc:</para>
            /// <code>InverseE2FromAB: (1 - e²) = b * b / (a * a)</code>
            /// <code>InverseE2FromA2B2: (1 - e²) = b² / a²</code>
            /// </summary>
            public static class E
            {
                /// <summary> 
                /// Calculate elliptic eccentricity (<c>e</c>) from semi-major axis (<c>a</c>) and semi-minor axis (<c>b</c>) lengths
                /// <code>e = √(1 - (b² / a²))</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="b">semi-minor axis length</param>
                /// <returns>elliptic eccentricity (<c>e</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double EFromAB(double a, double b) => System.Math.Sqrt(1 - (b * b / (a * a)));

                /// <summary> 
                /// Calculate elliptic eccentricity (<c>e</c>) from semi-major axis (<c>a</c>) and linear eccentricity (<c>c</c>) lengths
                /// <code>e = c / a</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="c">linear eccentricity length</param>
                /// <returns>elliptic eccentricity (<c>e</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double EFromAC(double a, double c) => c / a;

                /// <summary> 
                /// Calculate elliptic eccentricity (<c>e</c>) from semi-minor axis (<c>b</c>) and linear eccentricity (<c>c</c>) lengths
                /// <code>e = c / √(b² + c²)</code>
                /// </summary>
                /// <param name="b">semi-minor axis length</param>
                /// <param name="c">linear eccentricity length</param>
                /// <returns>elliptic eccentricity (<c>e</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double EFromBC(double b, double c) => c / System.Math.Sqrt((b * b) + (c * c));

                /// <summary> 
                /// Calculate elliptic eccentricity (<c>e</c>) from semi-major axis (<c>a</c>) and semi-latus rectum (<c>l</c>) lengths
                /// <code>e = √(1 - (l / a))</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>elliptic eccentricity (<c>e</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double EFromAL(double a, double l) => System.Math.Sqrt(1 - (l / a));

                /// <summary> 
                /// Calculate elliptic eccentricity (<c>e</c>) from semi-minor axis (<c>b</c>) and semi-latus rectum (<c>l</c>) lengths
                /// <code>e = √(1 - (l² / b²))</code>
                /// </summary>
                /// <param name="b">semi-minor axis length</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>elliptic eccentricity (<c>e</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double EFromBL(double b, double l) => System.Math.Sqrt(1 - (l * l / (b * b)));

                /// <summary> 
                /// Calculate elliptic eccentricity (<c>e</c>) from linear eccentricity (<c>c</c>) and semi-latus rectum (<c>l</c>) lengths
                /// <code>e = (2c / l) + √(l² - 4c²))</code>
                /// </summary>
                /// <param name="c">linear eccentricity length</param>
                /// <param name="l">semi-latus rectum length</param>
                /// <returns>elliptic eccentricity (<c>e</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double EFromCL(double c, double l) => 2 * c / (l + System.Math.Sqrt((l * l) + (4 * c * c)));



                /// <summary>
                /// Calculate the square of the elliptic eccentricity (<c>e²</c>) from the squares of the semi-major axis (<c>a²</c>) and semi-minor axis (<c>b²</c>)
                /// <code>e² = 1 - (b² / a²)</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <returns>square of the elliptic eccentricity (<c>e²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double E2FromA2B2(double a2, double b2) => 1 - (b2 / a2);

                /// <summary>
                /// Calculate the square of the elliptic eccentricity (<c>e²</c>) from the squares of the semi-major axis (<c>a²</c>) and linear eccentricity (<c>c²</c>)
                /// <code>e² = c² * a²</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <returns>square of the elliptic eccentricity (<c>e²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double E2FromA2C2(double a2, double c2) => c2 * a2;

                /// <summary>
                /// Calculate the square of the elliptic eccentricity (<c>e²</c>) from the squares of the semi-minor axis (<c>b²</c>) and linear eccentricity (<c>c²</c>)
                /// <code>e² = c² / (b² + c²)</code>
                /// </summary>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <returns>square of the elliptic eccentricity (<c>e²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double E2FromB2C2(double b2, double c2) => c2 / (b2 + c2);

                /// <summary>
                /// Calculate the square of the elliptic eccentricity (<c>e²</c>) from the squares of the semi-major axis (<c>a²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>e² = 1 - √(l² / a²)</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the elliptic eccentricity (<c>e²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double E2FromA2L2(double a2, double l2) => 1 - System.Math.Sqrt(l2 / a2);

                /// <summary>
                /// Calculate the square of the elliptic eccentricity (<c>e²</c>) from the squares of the semi-minor axis (<c>b²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>e² = 1 - (l² / b²)</code>
                /// </summary>
                /// <param name="b2">square of the semi-minor axis</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the elliptic eccentricity (<c>e²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double E2FromB2L2(double b2, double l2) => 1 - (l2 / b2);

                /// <summary>
                /// Calculate the square of the elliptic eccentricity (<c>e²</c>) from the squares of the linear eccentricity (<c>c²</c>) and semi-latus rectum (<c>l²</c>)
                /// <code>e² = 4c² / (l² * ((l² / 4) + c²))</code>
                /// </summary>
                /// <param name="c2">square of the linear eccentricity</param>
                /// <param name="l2">square of the semi-latus rectum</param>
                /// <returns>square of the elliptic eccentricity (<c>e²</c>)</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double E2FromC2L2(double c2, double l2) => 4 * c2 / (l2 * ((l2 / 4) + c2));



                /// <summary>
                /// Calculate the inverse of the square of eccentricity (<b>e</b>) from the semi-major (<b>a</b>) and semi-minor (<b>b</b>) axes
                /// <code>(1 - e²) = b² / a²</code>
                /// </summary>
                /// <param name="a">semi-major axis length</param>
                /// <param name="b">semi-minor axis length</param>
                /// <returns>The value of the inverse of the square of eccentricity</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double InverseE2FromAB(double a, double b) => (b * b) / (a * a);

                /// <summary>
                /// Calculate the inverse of the square of eccentricity (<b>e</b>) from the squares of the semi-major (<b>a</b>) and semi-minor (<b>b</b>) axes
                /// <code>(1 - e²) = b² / a²</code>
                /// </summary>
                /// <param name="a2">square of the semi-major axis length</param>
                /// <param name="b2">square of the semi-minor axis length</param>
                /// <returns>The value of the inverse of the square of eccentricity</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static double InverseE2FromA2B2(double a2, double b2) => b2 / a2;
            }
        }
    }
}
