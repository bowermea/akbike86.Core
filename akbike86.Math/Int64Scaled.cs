using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static akbike86.Geometry.Ellipses;

namespace akbike86.Math
{
    public struct UInt64Scaled : ISerializable
        //, IEquatable<UInt64Scaled>,
        //IComparable, IComparable<UInt64Scaled>
    {
        /// <summary>
        /// internal integer value
        /// </summary>
        private ulong _value;
        /// <summary>
        /// Signed byte indicated the scale of the integer (i.e. the exponent of the base-10 scientific notiation 10 ^ s)
        /// <list type="bullet">
        /// <item> 0: integer value has no scaling (i.e. 123 => 123)</item>
        /// <item> 3: integer scaled to thousands (i.e. 123 => 123,000)</item>
        /// <item>-3: integer scaled to thousandths (i.e. 123 => 0.123)</item>
        /// </list>
        /// </summary>
        private sbyte _scale;
        private ulong factor
        {
            get
            {
                switch (_scale)
                {
                    case 0: return 1UL;
                    case 1: case -1: return 10UL;
                    case 2: case -2: return 100UL;
                    case 3: case -3: return 1000UL;
                    case 4: case -4: return 10000UL;
                    case 5: case -5: return 100000UL;
                    case 6: case -6: return 1000000UL;
                    case 7: case -7: return 10000000UL;
                    case 8: case -8: return 100000000UL;
                    case 9: case -9: return 1000000000UL;
                    case 10:case-10: return 10000000000UL;
                    case 11:case-11: return 100000000000UL;
                    case 12:case-12: return 1000000000000UL;
                    case 13:case-13: return 10000000000000UL;
                    case 14:case-14: return 100000000000000UL;
                    case 15:case-15: return 1000000000000000UL;
                    case 16:case-16: return 10000000000000000UL;
                    case 17:case-17: return 100000000000000000UL;
                    case 18:case-18: return 1000000000000000000UL;
                    case 19:case-19: return 10000000000000000000UL;
                    default: throw new ArgumentOutOfRangeException(nameof(_scale),$"{nameof(UInt64Scaled)} cannot create {nameof(factor)} from scale ({_scale}) outside of int range (+-19), use decimal or double output instead");
                };
            }
        }
        
        private byte _leftPrec { get { return 0; } }
        private int _rightPrec
        {
            get
            {
                // short circuit scenarios
                // value=0
                if (_value == 0) { return 20; }
                // %0
                else if ((_value % 10U) != 0) { return 0; }
                else if ((_value % 1000000000U) == 0)
                { // 9 trailing zeros
                    if ((_value % 100000000000000000U) == 0) { return (_value % 1000000000000000000U) == 0 ? 18 : 17; }
                    else if ((_value % 10000000000000U) == 0)
                    { // 13 trailing zeros
                        if ((_value % 1000000000000000U) == 0) return (_value % 10000000000000000U) == 0 ? 16 : 15;
                        else return (_value % 100000000000000U) == 0 ? 14 : 13;
                    }
                    else
                    {
                        if ((_value % 100000000000U) == 0) return (_value % 1000000000000U) == 0 ? 12 : 11;
                        else return (_value % 10000000000U) == 0 ? 10 : 9;
                    }
                }
                else if ((_value % 100000U) == 0)
                {  // 5 trailing zeros
                    if ((_value % 10000000U) == 0) return (_value % 100000000U) == 0 ? 8 : 7;
                    else return (_value % 1000000U) == 0 ? 6 : 5;
                }
                else
                {
                    if ((_value % 1000U) == 0) return (_value % 10000U) == 0 ? 4 : 3;
                    else return (_value % 100U) == 0 ? 2 : 1;
                }
            }
        }
        private ulong _scaleVal(sbyte s)
        {
            switch (s)
            {
                case 0:  return _value;
                case 1:  return _value * 10UL; case -1:  return _value / 10UL;
                case 2:  return _value * 100UL; case -2:  return _value / 100UL;
                case 3:  return _value * 1000UL; case -3:  return _value / 1000UL;
                case 4:  return _value * 10000UL; case -4:  return _value / 10000UL;
                case 5:  return _value * 100000UL; case -5:  return _value / 100000UL;
                case 6:  return _value * 1000000UL; case -6:  return _value / 1000000UL;
                case 7:  return _value * 10000000UL; case -7:  return _value / 10000000UL;
                case 8:  return _value * 100000000UL; case -8:  return _value / 100000000UL;
                case 9:  return _value * 1000000000UL; case -9:  return _value / 1000000000UL;
                case 10: return _value * 10000000000UL; case -10: return _value / 10000000000UL;
                case 11: return _value * 100000000000UL; case -11: return _value / 100000000000UL;
                case 12: return _value * 1000000000000UL; case -12: return _value / 1000000000000UL;
                case 13: return _value * 10000000000000UL; case -13: return _value / 10000000000000UL;
                case 14: return _value * 100000000000000UL; case -14: return _value / 100000000000000UL;
                case 15: return _value * 1000000000000000UL; case -15: return _value / 1000000000000000UL;
                case 16: return _value * 10000000000000000UL; case -16: return _value / 10000000000000000UL;
                case 17: return _value * 100000000000000000UL; case -17: return _value / 100000000000000000UL;
                case 18: return _value * 1000000000000000000UL; case -18: return _value / 1000000000000000000UL;
                case 19: return _value * 10000000000000000000UL; case -19: return _value / 10000000000000000000UL;
                default: return 0;
            };
        }

        public ulong Raw => _value;
        public ulong ULong => _scale < 0 ? _value / factor : _value * factor;
        public double Double => _value * System.Math.Pow(10, _scale);

        private UInt64Scaled(ulong v, sbyte s) { _value = v; _scale = s; }

        public UInt64Scaled Shift(sbyte s, bool absolute = false)
        {
            if (absolute)
            {
                if (s > -19 && s < 19) {
                    return new UInt64Scaled(_scaleVal((sbyte)(_scale + s)) , s);
                }else return new UInt64Scaled(0,s);
            } else if (((_scale + s) > sbyte.MaxValue) || ((_scale + s) < sbyte.MinValue)) {
                throw new ArgumentOutOfRangeException(nameof(_scale), $"{nameof(UInt64Scaled)} {nameof(Shift)} function scale factor ({s}) exceeded limits of signed byte.");
            } else if (s > 19) { return new UInt64Scaled(0, (sbyte)(_scale + s)); }
            return new UInt64Scaled();
        }


        #region serialization
        /// <summary>
        /// serialization constructor, read "v" and "s" values from serialization info to call base constructor
        /// </summary>
        /// <param name="info">SerializationInfo object</param>
        /// <param name="context">StreamingContext object</param>
        private UInt64Scaled(SerializationInfo info, StreamingContext context) :
            this(info.GetUInt64("v"), info.GetSByte("s"))
        { }
        /// <summary>
        /// Implement serialization, only need to store "v" and "s" fields to define UInt64Scaled
        /// </summary>
        /// <param name="info">SerializationInfo object</param>
        /// <param name="context">StreamingContext object</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("v", _value);
            info.AddValue("s", _scale);
        }
        #endregion

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(UInt64Scaled left, UInt64Scaled right) => left.Equals(right);

        public static bool operator !=(UInt64Scaled left, UInt64Scaled right) => !left.Equals(right);

        /*
        public static bool operator <(UInt64Scaled left, UInt64Scaled right) => left.CompareTo(right) < 0;
        public static bool operator <=(UInt64Scaled left, UInt64Scaled right) => left.CompareTo(right) <= 0;
        public static bool operator >(UInt64Scaled left, UInt64Scaled right) => left.CompareTo(right) > 0;
        public static bool operator >=(UInt64Scaled left, UInt64Scaled right) => left.CompareTo(right) >= 0;
        */
    }
}
