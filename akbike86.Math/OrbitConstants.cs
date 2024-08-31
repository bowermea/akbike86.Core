using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static akbike86.Geometry.Ellipses.Functions;

namespace akbike86.Math
{
    public static partial class Constants
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
            public double AU => a / Constants.AU;
            /// <summary>
            /// perihelion distance
            /// </summary>
            public readonly double a_p;
            /// <summary>
            /// aphelion distance
            /// </summary>
            public readonly double a_a;
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
            public double YR => T / Constants.T_earth;
            /// <summary>
            /// mass in kg
            /// </summary>
            public readonly double mass;
            /// <summary>
            /// standard gravitational constant
            /// </summary>
            public readonly double GM;
            /// <summary>
            /// orbital inclination
            /// </summary>
            public readonly double i;
            /// <summary>
            /// logitude of ascension
            /// </summary>
            public readonly double L_a;
            /// <summary>
            /// longitude of perihelion
            /// </summary>
            public readonly double L_p;

            // rotation values
            /// <summary>
            /// length of day in seconds
            /// </summary>
            public readonly double d;
            /// <summary>
            /// tilt or obliguity of rotation in degrees
            /// </summary>
            public readonly double t;

            #region planetary values
            /// <summary>
            /// mean radius in meters
            /// </summary>
            public readonly double radiusMean;
            /// <summary>
            /// equatorial radius in meters
            /// </summary>
            public readonly double radiusEquatorial;
            /// <summary>
            /// polar radius in meters
            /// </summary>
            public readonly double radiusPolar;
            /// <summary>
            /// Ellipticity or flattening of the ellipsoid
            /// </summary>
            public readonly double ellipticity;
            /// <summary>
            /// ellipsoid volume in m³
            /// </summary>
            public readonly double volume;
            /// <summary>
            /// mean density in kg/m³
            /// </summary>
            public readonly double density;
            /// <summary>
            /// cacluated density (mass/volume) in kg/m³
            /// </summary>
            public double densityCalc => mass / volume;
            //calc ellipticity
            #region
            public OrbitalData(double a, double a_AU, double a_p, double a_a, double e, double T, double T_yr, double m, double GM, 
                double i, double L_a, double L_p, double d, double t, 
                double r, double r_E, double r_P, )
            {
                this.a = a;
                this.a_AU = a_AU;
                this.a_p = a_p;
                this.a_a = a_a;
                this.e = e;
                this.T = T;
                this.T_yr = T_yr;
                this.mass = m;
                this.GM = GM;
                this.i = i;
                this.L_a = L_a;
                this.L_p = L_p;
                this.d = d;
                this.t = t;
                this.radiusMean = r;
                this.radiusEquatorial = r_E;
                this.radiusPolar = r_P;
            }
        }

        // ****************
        // NASA.gov data
        // ****************

        public static readonly OrbitalData MERCURY = new(57.909e9,0.38709893,46e9,69.818e9,0.20563069,
            7.6005216e6,0.241,0.33010e24,0.022032e15,7.00487,48.33167,77.45645,
            1.520136e7,0.034,2.4397e6,2.4405e6,2.4383e6);
        public static readonly OrbitalData VENUS = new(108.210e9, 0.72333199, 107.480e9, 108.941e9, 0.00677323,
            1.94141664e7, 0.615, 4.8673e24, 0.32486e15, 3.39471, 76.68069, 131.53298,
            1.0087200e7, 177.36, 6.0518e6, 6.0518e6, 6.0518e6);
        /*
        public static readonly OrbitalData [OBJ] = new(a, a_AU, a_p, a_a, e,
            T, T_yr, m, GM, i, L_a, L_p,
            d, t, r, r_E, r_P);
        */
        public const double GM_sun = 1.32712440018e20;
        public const double GM_sol = 1.32712440042e20;
        public const double GM_earth = 3.986004418e14;
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


        public const double OneDegreeOfPI = 0.017453292519943295769; // double.Pi/180
        public const double OneArcSecOfPI = 4.8481368110953599358991410235795e-6; // double.Pi/648000
        public const double TwoPIof32768 = 0.00019174759848570515;
    }
}
