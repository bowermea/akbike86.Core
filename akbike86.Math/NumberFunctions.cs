using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math
{
    /// <summary>
    /// Common, specialized or extension methods for numeric data types
    /// </summary>
    public static partial class NumberFunctions
    {
        #region round_methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Round(this decimal value, MidpointRounding mode = MidpointRounding.ToZero) => System.Math.Round(value, mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Round(this decimal value, int digits, MidpointRounding mode = MidpointRounding.ToZero) => System.Math.Round(value, digits, mode);
        #endregion

        #region double_conversion
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this double value) => Convert.ToInt32(value.Round());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToUInt(this double value) => Convert.ToUInt32(value.Round());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ToULong(this double value) => Convert.ToUInt64(value.Round());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToUInt(this double value, int s) => Convert.ToUInt32((System.Math.Pow(10, s) * value).Round());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ToULong(this double value, int s) => Convert.ToUInt64((System.Math.Pow(10, s) * value).Round());
        #endregion

        #region decimal_conversion
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this decimal value) => Convert.ToInt32(value.Round());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToUInt(this decimal value) => Convert.ToUInt32(value.Round());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ToULong(this decimal value) => Convert.ToUInt64(value.Round());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToUInt(this decimal value, int s) => Convert.ToUInt32((Convert.ToDecimal(System.Math.Pow(10.0, s)) * value).Round());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ToULong(this decimal value, int s) => Convert.ToUInt64((Convert.ToDecimal(System.Math.Pow(10.0, s)) * value).Round());
        #endregion

    }
}
