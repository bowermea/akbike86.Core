using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math
{
    public static partial class NumberFunctions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [TargetedPatchingOptOut("Performance critical to inline well defined static methods")]
        public static double Round(this double value, MidpointRounding mode = MidpointRounding.AwayFromZero) => System.Math.Round(value, mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [TargetedPatchingOptOut("Performance critical to inline well defined static methods")]
        public static double Round(this double value, int digits, MidpointRounding mode = MidpointRounding.AwayFromZero) => System.Math.Round(value, digits, mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [TargetedPatchingOptOut("Performance critical to inline well defined static methods")]
        public static long Bits(this double value) => BitConverter.DoubleToInt64Bits(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [TargetedPatchingOptOut("Performance critical to inline well defined static methods")]
        public static ulong UBits(this double value) => BitConverter.DoubleToUInt64Bits(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static double Truncate(this double value) => System.Math.Truncate(value);

        public static int Magnitude(this double value)
        {
            if (value.Equals(0.0)) { return 0; }
            double magnitude = System.Math.Log10(System.Math.Abs(value));
            var truncated = (int)System.Math.Truncate(magnitude);
            return magnitude < 0d && truncated != magnitude ? truncated - 1 : truncated;
        }
        public static double ScaleUnitMagnitude(this double value)
        {
            if (value.Equals(0.0)) { return value; }
            int magnitude = Magnitude(value);
            return value * System.Math.Pow(10, -magnitude);
        }
    }
}
