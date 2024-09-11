using akbike86.Math.Trig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math.Astro
{
    public partial class Orbit
    {
        public partial class Functions
        {
            public static double Period(double distance, double gravitationalParameter)
            {
                if (gravitationalParameter <= 0)
                { throw new ArgumentOutOfRangeException(nameof(gravitationalParameter), $"standard gravitational parameter must be a positive number {gravitationalParameter}"); }
                if (distance <= 0)
                { throw new ArgumentOutOfRangeException(nameof(distance), $"distance must be a positive number {distance}"); }
                return 2 * System.Math.PI * System.Math.Pow(distance, 1.5) / System.Math.Sqrt(gravitationalParameter);
            }
            public static double Period(double distance, double primaryMass, double secondaryMass = 0)
            {
                return Period(distance, (primaryMass + secondaryMass) * Constants.G);
            }

            public static double OrbitalDistance(double period, double gravitationalParameter)
            {
                throw new NotImplementedException();
            }
            
            public static double MeanAngularMotion(double distance, double gravitationalParameter)
            {
                return double.Sqrt(gravitationalParameter / (distance * distance * distance));
            }

            public static double n(double a, double GM) => MeanAngularMotion(a, GM);

            /// <summary>
            /// Calculate the mean anomaly of an Kepler orbit
            /// </summary>
            /// <param name="e">eccentricity of orbit</param>
            /// <param name="E">eccentric anomaly</param>
            /// <returns></returns>
            public static double MeanAnomaly(double eccentricty, Angle eccentricAnomaly)
            {
                return eccentricAnomaly.Radians - (eccentricty * eccentricAnomaly.Sin);
            }
            public static double M(double e, Angle E) => MeanAnomaly(e, E);

            public static double MeanAnomaly(Angle meanLogitude, Angle longitudeOfPericenter) {
                return (meanLogitude - longitudeOfPericenter).Radians;
            }
            public static double M(Angle l, Angle w) => MeanAnomaly(l, w);

            public static double MeanAnomaly(Angle trueAnomaly, double eccentricty) {
                (double sinf, double cosf) = double.SinCos(trueAnomaly.Radians);
                double eInv = double.Sqrt(1 - (eccentricty * eccentricty));
                return double.Atan2(-eInv * sinf, -eccentricty - cosf) + double.Pi -
                        (eccentricty * eInv * sinf / (1 + (eccentricty * cosf)));
            }
            public static double M(Angle f, double e) => MeanAnomaly(f, e);


            public static double MeanAnomaly(double time, double distance, double gravitationalParameter, double timeOfPericenter)
            {
                return n(distance, gravitationalParameter)*(time - timeOfPericenter);
            }
            public static double M(double a, double GM, double t, double r) => MeanAnomaly(t, a, GM, r);

        }
    }
}
