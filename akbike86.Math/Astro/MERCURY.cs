using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math.Astro
{
    public static partial class Constants
    {
        /// <summary>
        /// Constant values of astronomical observations of <see cref="MERCURY">Mercury</see>. <br/>
        /// J2000 values from <see href="https://nssdc.gsfc.nasa.gov/planetary/factsheet/mercuryfact.html">NASA.gov</see>
        /// </summary>
        public static partial class MERCURY
        {
            /// <summary>observed semi-major axis of orbit (m)</summary>
            public const double a = 57.909e9;
            /// <summary>observed semi-major axis of orbit (AU)</summary>
            public const double a_AU = 0.38709893d;
            /// <summary>observed perihelion distance (m)</summary>
            public const double a_min = 46.0012e9;
            /// <summary>observed aphelion distance (m)</summary>
            public const double a_max = 69.818e9;
            /// <summary>orbital eccentricity</summary>
            public const double e = 0.20563069d;
            /// <summary>orbital sidereal period (s)</summary>
            public const double T_side = 7.6005216e6;
            /// <summary>orbital tropical period (s)</summary>
            public const double T_trop = 7.6004352e6;
            /// <summary>orbital sidereal period (earth years)</summary>
            public const double T_yr = 0.241d;
            /// <summary>estimated mass (kg)</summary>
            public const double m = 0.33010e24;
            /// <summary>standard gravitational constant</summary>
            public const double GM = 0.022032e15;
            /// <summary>orbital inclination (°)</summary>
            public const double i = 7.00487d;
            /// <summary>logitude of ascension (°)</summary>
            public const double L_a = 48.33167d;
            /// <summary>longitude of perihelion (°)</summary>
            public const double L_p = 77.45645d;
            /// <summary>length of day (s)</summary>
            public const double Day = 15201360d;
            /// <summary>tilt or obliguity of rotation (°)</summary>
            public const double Tilt = 0.034d;
            /// <summary>mean radius (m)</summary>
            public const double r = 2.4397e6;
            /// <summary>equatorial radius (m)</summary>
            public const double r_E = 2.4405e6;
            /// <summary>polar radius (m)</summary>
            public const double r_P = 2.4383e6;
            /// <summary>ellipticity or flattening of the ellipsoid </summary>
            public const double E = 0.0009d;
            /// <summary>volume (m³)</summary>
            public const double V = 6.083e19;
            /// <summary>mean density (kg/m³)</summary>
            public const double d = 5429d;
            /// <summary>mean surface gravity (m/s²)</summary>
            public const double g = 3.70d;
            /// <summary>equatorial surface acceleration (m/s²)</summary>
            public const double g_E = 3.70d;
            /// <summary>polar surface acceleration (m/s²)</summary>
            public const double g_P = 3.71d;
            /// <summary>solar irradiance (W/m²)</summary>
            public const double TSI = 9082.7d;
        }
    }
}
