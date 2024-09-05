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
        /// Constant values of astronomical observations of <see cref="EARTH">Earth</see>. <br/>
        /// J2000 values from <see href="https://nssdc.gsfc.nasa.gov/planetary/factsheet/earthfact.html">NASA.gov</see>
        /// </summary>
        public static partial class EARTH
        {
            /// <summary>observed semi-major axis of orbit (m)</summary>
            public const double a = 149.5980e9;
            /// <summary>observed semi-major axis of orbit (AU)</summary>
            public const double a_AU = 1.00000011d;
            /// <summary>observed perihelion distance (m)</summary>
            public const double a_min = 147.095e9;
            /// <summary>observed aphelion distance (m)</summary>
            public const double a_max = 152.100e9;
            /// <summary>orbital eccentricity</summary>
            public const double e = 0.01671022d;
            /// <summary>orbital sidereal period (s)</summary>
            public const double T_side = 31.5581497635456e6;
            /// <summary>orbital tropical period (s)</summary>
            public const double T_trop = 31.5569252507328e6;
            /// <summary>orbital sidereal period (earth years)</summary>
            public const double T_yr = d;
            /// <summary>estimated mass (kg)</summary>
            public const double m = 5.9722e24;
            /// <summary>standard gravitational constant</summary>
            public const double GM = 0.3986004418e15;
            /// <summary>orbital inclination (°)</summary>
            public const double i = 0.00005d;
            /// <summary>logitude of ascension (°)</summary>
            public const double L_a = -11.26064d;
            /// <summary>longitude of perihelion (°)</summary>
            public const double L_p = 102.94719d;
            /// <summary>length of day (s)</summary>
            public const double Day = 86400d;
            /// <summary>tilt or obliguity of rotation (°)</summary>
            public const double Tilt = 23.439281d;
            /// <summary>mean radius (m)</summary>
            public const double r = 6.371000e6;
            /// <summary>equatorial radius (m)</summary>
            public const double r_E = 6.3781366e6;
            /// <summary>polar radius (m)</summary>
            public const double r_P = 6.356751e6;
            /// <summary>ellipticity or flattening of the ellipsoid </summary>
            public const double E = 0.0033528197d;
            /// <summary>volume (m³)</summary>
            public const double V = 108.321e19;
            /// <summary>mean density (kg/m³)</summary>
            public const double d = 5513d;
            /// <summary>mean surface gravity (m/s²)</summary>
            public const double g = 9.82d;
            /// <summary>equatorial surface acceleration (m/s²)</summary>
            public const double g_E = 9.78d;
            /// <summary>polar surface acceleration (m/s²)</summary>
            public const double g_P = 9.832d;
            /// <summary>solar irradiance (W/m²)</summary>
            public const double TSI = 1361.0d;
        }
    }
}
