using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using akbike86.Math;

namespace akbike86.Geometry
{

    public partial class Ellipses
    {
        [Serializable]
        public struct Elliptic : ISerializable, IEquatable<Elliptic>, 
            IComparable, IComparable<Elliptic>
        {
            #region private_fields
            /// <summary>
            /// length of semi-major axis
            /// </summary>
            [JsonInclude]
            [JsonPropertyName("a")]
            private readonly double _a = 1;
            /// <summary>
            /// length of semi-minor axis
            /// </summary>
            [JsonInclude]
            [JsonPropertyName("b")]
            private readonly double _b = 1;
            /// <summary>
            /// linear eccentricity, distance between center and foci
            /// </summary>
            [JsonIgnore]
            [NonSerialized]
            private readonly double _c = 0;
            /// <summary>
            /// eccentricity, ratio of linear eccentricity (center to foci) to semi-major axis
            /// </summary>
            [JsonIgnore]
            [NonSerialized]
            private readonly double _e = 0;
            /// <summary>
            /// length of semi-latus rectum, distance from foci to ellipse parallel to semi-minor axis
            /// </summary>
            [JsonIgnore]
            [NonSerialized]
            private readonly double _l = 1;
            #endregion

            #region public_props
            /// <summary>
            /// length of semi-major axis
            /// </summary>
            [JsonIgnore]
            public double a => _a;
            /// <summary>
            /// length of semi-major axis
            /// </summary>
            [JsonIgnore]
            public double SemiMajorAxis => _a;

            /// <summary>
            /// length of semi-minor axis
            /// </summary>
            [JsonIgnore]
            public double b => _b;
            /// <summary>
            /// length of semi-minor axis
            /// </summary>
            [JsonIgnore]
            public double SemiMinorAxis => _b;

            /// <summary>
            /// linear eccentricity, distance between center and foci
            /// </summary>
            [JsonIgnore]
            public double c => _c;
            /// <summary>
            /// linear eccentricity, distance between center and foci
            /// </summary>
            [JsonIgnore]
            public double LinearEccentricity => _c;

            /// <summary>
            /// eccentricity, ratio of linear eccentricity (center to foci) to semi-major axis
            /// </summary>
            [JsonIgnore]
            public double e => _e;
            /// <summary>
            /// eccentricity, ratio of linear eccentricity (center to foci) to semi-major axis
            /// </summary>
            [JsonIgnore]
            public double Eccentricity => _e;

            /// <summary>
            /// length of semi-latus rectum, distance from foci to ellipse parallel to semi-minor axis
            /// </summary>
            [JsonIgnore]
            public double l => _l;
            /// <summary>
            /// length of semi-latus rectum, distance from foci to ellipse parallel to semi-minor axis
            /// </summary>
            [JsonIgnore]
            public double SemiLatusRectum => _l;
            #endregion

            //public Elliptic() { throw new NotImplementedException(); }
            private Elliptic(double a_, double b_) {
                if (b_ > a_) throw new ArgumentOutOfRangeException("b", $"Elliptic object cannot have semi-minor axis (b={b_}) greater than semi-major axis (a={a_}).");
                _a = a_;
                _b = b_;
                _c = Functions.C.CFromAB(a, b); // System.Math.Sqrt(a * a - b * b);
                _e = Functions.E.EFromAC(a, _c); // c / a;
                _l = Functions.L.LFromAB(a, b); // b * b / a; 
                
            }

            #region serialization
            /// <summary>
            /// serialization constructor, read "a" and "b" values from serialization info to call base constructor
            /// </summary>
            /// <param name="info">SerializationInfo object</param>
            /// <param name="context">StreamingContext object</param>
            private Elliptic(SerializationInfo info, StreamingContext context) :
                this(info.GetDouble("a"),info.GetDouble("b")) { }
            /// <summary>
            /// Implement serialization, only need to store "a" and b" fields to define elliptic
            /// </summary>
            /// <param name="info">SerializationInfo object</param>
            /// <param name="context">StreamingContext object</param>
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("a", _a);
                info.AddValue("b", _b);
            }
            #endregion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int GetHashCode() => HashCode.Combine(_a, _b);
            public override bool Equals(object? obj) => obj is Elliptic && Equals((Elliptic)obj);
            public bool Equals(Elliptic other) => _a.Equals(other._a) && _b.Equals(other._b);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Elliptic left, Elliptic right) => left.Equals(right);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Elliptic left, Elliptic right) => !left.Equals(right);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CompareTo(object? obj) => obj is Elliptic ? CompareTo((Elliptic)obj) : 1;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CompareTo(Elliptic other)
            {
                int r = _a.CompareTo(other._a);
                if (r==0) r = _b.CompareTo(other._b); 
                return r;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator <(Elliptic left, Elliptic right) => left.CompareTo(right) < 0;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator <=(Elliptic left, Elliptic right) => left.CompareTo(right) <= 0;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator >(Elliptic left, Elliptic right) => left.CompareTo(right) > 0;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator >=(Elliptic left, Elliptic right) => left.CompareTo(right) >= 0;
        }

    }
    internal class EllipseInt
    {
        #region constants
        private const byte scaleEpoch = 127;
        private const byte defaultScale = scaleEpoch - 3; // default scale is thousandths
        #endregion

        #region ellipse_internals
        // default values are unit circle
        private uint a = 1;
        private uint b = 1;
        private uint c = 0;
        private byte scale = defaultScale;
        private uint e = 0;
        #endregion

        private int Scale {
            get => scale - scaleEpoch;
            set {
                if (value < (0 - scaleEpoch) || scale > (byte.MaxValue - scaleEpoch))
                { throw new ArgumentOutOfRangeException(nameof(Scale), $"Value ({value}) for scale of ellipse must be between {0 - scaleEpoch} and {byte.MaxValue - scaleEpoch}"); }
                int delta = value - scale;
                
                scale = unchecked((byte)(value + scaleEpoch));
            }
        }

        private EllipseInt(uint major, uint minor, byte s)
        {
            if (minor > major) { throw new ArgumentOutOfRangeException(nameof(minor),$"Ellipse cannot be defined with minor axis ({minor}) greater than the major axis ({major})."); }
            a = major; b = minor; scale = s;
            c = System.Math.Sqrt((ulong)a * a - (ulong)b * b).ToUInt();
        }

    }
}
