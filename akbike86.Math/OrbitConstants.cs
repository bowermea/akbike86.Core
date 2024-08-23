using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math
{
    public static class OrbitalConstants
    {
        public class OrbitalData
        {
            /// <summary>
            /// semi-major axis in meters
            /// </summary>
            public readonly double a;
            /// <summary>
            /// semi-major axis in AU (measured)
            /// </summary>
            public readonly double a_AU;
            /// <summary>
            /// calcuated semi-major axis in AU
            /// </summary>
            public double AU => a / OrbitalConstants.AU;
            /// <summary>
            /// orbital eccentricity
            /// </summary>
            public readonly double e;
            /// <summary>
            /// orbital period in seconds
            /// </summary>
            public readonly double T;
            /// <summary>
            /// orbital period in earth years
            /// </summary>
            public readonly double T_yr;
            /// <summary>
            /// calculated period in earth years
            /// </summary>
            public double YR => T / OrbitalConstants.T_earth;
            /// <summary>
            /// mass in kg
            /// </summary>
            public readonly double m;
            /// <summary>
            /// standard gravitational constant
            /// </summary>
            public readonly double GM;
            /// <summary>
            /// orbital inclination
            /// </summary>
            public readonly double i;
            public readonly double perihelion;

            // rotation values
            public readonly double d;
            public readonly double t;

            // planetary values
            public readonly double r;
            public readonly double r_E;
            public readonly double r_P;
        }

        public static readonly OrbitalData Mercury => new OrbitalData(

            5.7909e10, 0.38709893);
        public const double GM_sun = 1.32712440018e20;
        public const double GM_sol = 1.32712440042e20;
        public const double GM_earth = 3.986004418e14;
        public const double GM_mercury = 2.2032e13;
        public const double GM_venus = 3.24859e14;
        public const double GM_moon = 4.9048695e12;
        public const double GM_jupiter = 1.26686534e17;
        public const double GM_saturn = 3.7931187e16;
        public const double GM_uranus = 5.793939e15;
        public const double GM_neptune = 6.836529e15;
        public const double GM_pluto = 8.71e11;
        public const double G = 6.6743e-11;
        public const long AU = 149597870700;
        public const double T_earth = 3.1558148626e7;
    }
}
