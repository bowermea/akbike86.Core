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
        /// Constant values of astronomical observations of <see cref="VENUS">Venus</see>. <br/>
        /// J2000 values from <see href="https://nssdc.gsfc.nasa.gov/planetary/factsheet/venusfact.html">NASA.gov</see>
        /// </summary>
        public static partial class VENUS
        {
            /// <summary>observed semi-major axis of orbit (m)</summary>
            public const double a = 108.210e9;
            /// <summary>observed semi-major axis of orbit (AU)</summary>
            public const double a_AU = 0.72333199d;
            /// <summary>observed perihelion distance (m)</summary>
            public const double a_min = 107.480e9;
            /// <summary>observed aphelion distance (m)</summary>
            public const double a_max = 108.941e9;
            /// <summary>orbital eccentricity</summary>
            public const double e = 0.00677323d;
            /// <summary>orbital sidereal period (s)</summary>
            public const double T_side = 19.4141664e6;
            /// <summary>orbital tropical period (s)</summary>
            public const double T_trop = 19.413648e6;
            /// <summary>orbital sidereal period (earth years)</summary>
            public const double T_yr = 0.615d;
            /// <summary>estimated mass (kg)</summary>
            public const double m = 4.8673e24;
            /// <summary>standard gravitational constant</summary>
            public const double GM = 3.24859e14;
            /// <summary>orbital inclination (°)</summary>
            public const double i = 3.39471d;
            /// <summary>logitude of ascension (°)</summary>
            public const double L_a = 76.68069d;
            /// <summary>longitude of perihelion (°)</summary>
            public const double L_p = 131.53298d;
            /// <summary>length of day (s)</summary>
            public const double Day = 10087200d;
            /// <summary>tilt or obliguity of rotation (°)</summary>
            public const double Tilt = 177.36d;
            /// <summary>mean radius (m)</summary>
            public const double r = 6.0518e6;
            /// <summary>equatorial radius (m)</summary>
            public const double r_E = 6.0518e6;
            /// <summary>polar radius (m)</summary>
            public const double r_P = 6.0518e6;
            /// <summary>ellipticity or flattening of the ellipsoid </summary>
            public const double E = 0.0d;
            /// <summary>volume (m³)</summary>
            public const double V = 9.2843e20;
            /// <summary>mean density (kg/m³)</summary>
            public const double d = 5243d;
            /// <summary>mean surface gravity (m/s²)</summary>
            public const double g = 8.87d;
            /// <summary>equatorial surface acceleration (m/s²)</summary>
            public const double g_E = 8.87d;
            /// <summary>polar surface acceleration (m/s²)</summary>
            public const double g_P = 8.87d;
            /// <summary>solar irradiance (W/m²)</summary>
            public const double TSI = 2601.3d;
        }
    }
}
