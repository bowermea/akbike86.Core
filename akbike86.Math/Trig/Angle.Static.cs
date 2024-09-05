using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math.Trig
{
    public readonly partial struct Angle
    {
        /// <summary>
        /// Reduce and normalize an angle between the the valid <paramref name="max"/> and <paramref name="min"/> value.<br/>
        /// Assumes all values are finite, the max and min are ± values of a full turn from zero. <br/>
        /// Floating point calculations can be imprecise at lower decimal places and should be 
        /// rounded to the valid precision of the angular measurement. 
        /// </summary>
        /// <param name="angle">angle value to reduce</param>
        /// <param name="max">The positive value of a full turn for the angle measurement</param>
        /// <param name="min">The negative value of a full turn for the angle measurement</param>
        /// <returns>The anglular value reduced to within a positive turn</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double Reduce(double angle, double max, double min)
        {
            if (angle == 0d || angle == max || angle == min) { return 0d; }
            else if (angle > max) { return angle % max; }
            else if (angle > 0d) { return angle; }
            else if (angle > min) { return max + angle; }
            else { return max - (System.Math.Abs(angle) % max); }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Reduce(double angle, AngleMeasure type)
        {
            // short circuit for 0/no angle
            if (angle == 0d) { return angle; }
            // ensure we have a valid finite angle
            else if (Double.IsFinite(angle))
            {
                switch (type)
                {
                    case AngleMeasure.turn:
                        return Reduce(angle, 1d, -1d).Round(TurnDigits);
                    case AngleMeasure.rad:
                        return Reduce(angle, RadTurn, RadTurnNeg).Round(RadDigits);
                    case AngleMeasure.mrad:
                        return Reduce(angle, MRadTurn, MRadTurnNeg).Round(MRadDigits);
                    case AngleMeasure.pi:
                        return Reduce(angle, PiTurn, PiTurnNeg).Round(PIDigits);
                    case AngleMeasure.deg:
                        return Reduce(angle, DegTurn, DegTurnNeg).Round(13);
                    case AngleMeasure.arcminute:
                        return Reduce(angle, DegMinTurn, DegMinTurnNeg).Round(11);
                    case AngleMeasure.arcsecond:
                        return Reduce(angle, DegSecTurn, DegSecTurnNeg).Round(9);
                    case AngleMeasure.grad:
                        return Reduce(angle, GradTurn, GradTurnNeg).Round(13);
                    case AngleMeasure.centminute:
                        return Reduce(angle, GradMinTurn, GradMinTurnNeg).Round(11);
                    case AngleMeasure.centsecond:
                        return Reduce(angle, GradSecTurn, GradSecTurnNeg).Round(9);
                    case AngleMeasure.sextant:
                        return Reduce(angle, SextantTurn, SextantTurnNeg).Round(15);
                }
                throw new ArgumentOutOfRangeException(nameof(type), type, $"Cannot reduce angle for invalid angle type.");
            }
            // cannot reduce NaN and positive or negative infinity to a proper angle, simply return NaN
            else { return double.NaN; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReduceDegrees(double degrees)
        {
            // ensure we have a valid finite angle
            if (Double.IsFinite(degrees))
            {
                // since degrees range to hundreds, 13 decimals places can be reliably calculated
                return Reduce(degrees, 360d, -360d).Round(13);
                // return Reduce(degrees, M.DegreeCircle, M.DegreeCircleNeg).Round(13);
            }
            // cannot reduce NaN and positive or negative infinity to a proper angle, simply return NaN
            else { return double.NaN; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReduceRadians(double radians) => Reduce(radians, AngleMeasure.radian);
        /*{
            // ensure we have a valid finite angle
            if (Double.IsFinite(radians))
            {
                // since radians only valid from 0 to ~6.28, 15 decimals places can be reliably calculated
                return Reduce(radians, double.Pi*2d, double.Pi*-2d).Round(15);
                // return Reduce(radians, M.RadianCircle, M.RadianCircleNeg).Round(15);
            }
            // cannot reduce NaN and positive or negative infinity to a proper angle, simply return NaN
            else { return double.NaN; }
        }*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReduceGradians(double gradians) => Reduce(gradians, AngleMeasure.gradian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReduceTurns(double turns) => Reduce(turns, AngleMeasure.turn);



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DegreesToRadians(double degrees) => ReduceDegrees(degrees) * DegToRad;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RadiansToDegress(double radians) => ReduceRadians(radians) * RadToDeg;


        public static Angle Gradian(double angle)
        {
            throw new NotImplementedException();
        }
        public static double Convert(double angle, AngleMeasure source, AngleMeasure target)
        {
            if (0d == angle || source == target) { return angle; }
            else if (double.IsFinite(angle)) {
                switch (source)
                {
                    case AngleMeasure.turn:
                        switch (target)
                        {
                            case AngleMeasure.turn: return angle;
                            case AngleMeasure.rad: return angle * Pi2;
                            case AngleMeasure.mrad: return angle * MRadTurn;
                            case AngleMeasure.pi: return angle * PiTurn;
                            case AngleMeasure.deg: return angle * DegTurn;
                            case AngleMeasure.arcminute: return angle * DegMinTurn;
                            case AngleMeasure.arcsecond: return angle * DegSecTurn;
                            case AngleMeasure.milliarcsecond: return angle * DegMasTurn;
                            case AngleMeasure.grad: return angle * GradTurn;
                            case AngleMeasure.centminute: return angle * GradMinTurn;
                            case AngleMeasure.centsecond: return angle * GradSecTurn;
                            case AngleMeasure.sextant: return angle * SextantTurn;
                            default: throw new ArgumentOutOfRangeException(nameof(target), target, $"Cannot convert to angle measure to unknown type {target}.");
                        }
                    case AngleMeasure.rad:
                        switch (target)
                        {
                            case AngleMeasure.turn: return angle * Pi2Inv;
                            case AngleMeasure.rad: return angle;
                            case AngleMeasure.mrad: return angle * 1000d;
                            case AngleMeasure.pi: return angle * double.Pi;
                            case AngleMeasure.deg: return angle * RadToDeg;
                            case AngleMeasure.arcminute: return angle * RadToDegMin;
                            case AngleMeasure.arcsecond: return angle * RadToDegSec;
                            case AngleMeasure.milliarcsecond: return angle * RadToDegMas;
                            case AngleMeasure.grad: return angle * RadToGrad;
                            case AngleMeasure.centminute: return angle * RadToGradMin;
                            case AngleMeasure.centsecond: return angle * RadToGradSec;
                            case AngleMeasure.sextant: return angle * RadToSextant;
                            default: throw new ArgumentOutOfRangeException(nameof(target), target, $"Cannot convert to angle measure to unknown type {target}.");
                        }
                    case AngleMeasure.mrad:
                        break;
                    case AngleMeasure.pi:
                        switch (target)
                        {
                            case AngleMeasure.turn: return angle * ;
                            case AngleMeasure.rad: return angle * ;
                            case AngleMeasure.mrad: return angle * ;
                            case AngleMeasure.pi: return angle * ;
                            case AngleMeasure.deg: return angle * ;
                            case AngleMeasure.arcminute: return angle * ;
                            case AngleMeasure.arcsecond: return angle * ;
                            case AngleMeasure.grad: return angle * ;
                            case AngleMeasure.centminute: return angle * ;
                            case AngleMeasure.centsecond: return angle * ;
                            case AngleMeasure.sextant: return angle * ;
                            default: throw new ArgumentOutOfRangeException(nameof(target), target, $"Cannot convert to angle measure to unknown type {target}.");
                        }
                        break;
                    case AngleMeasure.deg:
                        switch (target)
                        {
                            case AngleMeasure.turn: return angle * ;
                            case AngleMeasure.rad: return angle * ;
                            case AngleMeasure.mrad: return angle * ;
                            case AngleMeasure.pi: return angle * ;
                            case AngleMeasure.deg: return angle * ;
                            case AngleMeasure.arcminute: return angle * ;
                            case AngleMeasure.arcsecond: return angle * ;
                            case AngleMeasure.grad: return angle * ;
                            case AngleMeasure.centminute: return angle * ;
                            case AngleMeasure.centsecond: return angle * ;
                            case AngleMeasure.sextant: return angle * ;
                            default: throw new ArgumentOutOfRangeException(nameof(target), target, $"Cannot convert to angle measure to unknown type {target}.");
                        }
                        break;
                    case AngleMeasure.arcminute:
                        break;
                    case AngleMeasure.arcsecond:
                        break;
                    case AngleMeasure.grad:
                        break;
                    case AngleMeasure.centminute:
                        break;
                    case AngleMeasure.centsecond:
                        break;
                    case AngleMeasure.sextant:
                        break;
                }
            }
            else { return double.NaN; }
            throw new NotImplementedException();
        }
        public static Angle operator +(Angle left, Angle right)
        {
            throw new NotImplementedException();
        }

        public static Angle operator -(Angle left, Angle right)
        {
            throw new NotImplementedException();
        }

        private const double Pi2           = double.Pi * 2d; // 6.283185307179586476925286766559d
        private const double Pi2Inv        = 1 / Pi2;        // 0.15915494309189533576888376337251d
        private const double DegToRad      = double.Pi / 180.0d;    // 0.01745329251994329576923690768489d
        private const double DegMinToRad   = DegToRad / 60.0d;      // 0.00029088820866572159615394846141477d
        private const double DegSecToRad   = DegMinToRad / 60.0d;   // 4.8481368110953599358991410235795e-6
        private const double DegMasToRad   = DegSecToRad / 1000.0d; // 4.8481368110953599358991410235795e-9
        private const double RadToDeg      = 180d / double.Pi;      // 57.295779513082320876798154814105
        private const double RadToDegMin   = RadToDeg * 60.0d;      // 3437.7467707849392526078892888463
        private const double RadToDegSec   = RadToDegMin * 60.0d;   // 206264.80624709635515647335733078
        private const double RadToDegMas   = RadToDegSec * 1000.0d; // 206264806.24709635515647335733078
        private const double DegToGrad     = 10d / 9d;              // 1.1111111111111111111111111111111d
        private const double DegMinToGrad  = DegToGrad / 60.0d;     // 0.01851851851851851851851851851852d
        private const double DegSecToGrad  = DegMinToGrad / 60.0d;  // 3.0864197530864197530864197530864e-4
        private const double DegMasToGrad  = DegSecToGrad / 1000.0d;// 3.0864197530864197530864197530864e-7
        private const double GradToDeg     = 0.9d;
        private const double GradToDegMin  = GradToDeg * 60.0d;     // 54d
        private const double GradToDegSec  = GradToDegMin * 60.0d;  // 3240d
        private const double GradToDegMas  = GradToDegSec * 1000.0d;// 3240000d
        private const double DegToGradMin    = DegToGrad * 100;           // 111.11111111111111111111111111111d
        private const double DegMinToGradMin = DegToGradMin / 60.0d;      // 1.8518518518518518518518518518519d
        private const double DegSecToGradMin = DegMinToGradMin / 60.0d;   // 0.030864197530864197530864197530864d
        private const double DegMasToGradMin = DegSecToGradMin / 1000.0d; // 0.000030864197530864197530864197530864d
        private const double GradMinToDeg    = GradToDeg / 100d;          // 0.009
        private const double GradMinToDegMin = GradMinToDeg * 60.0d;      // 0.54d
        private const double GradMinToDegSec = GradMinToDegMin * 60.0d;   // 32.4d 
        private const double GradMinToDegMas = GradMinToDegMin * 1000.0d; // 32400d
        private const double DegToGradSec    = DegToGradMin * 100;        // 11111.111111111111111111111111111d
        private const double DegMinToGradSec = DegToGradSec / 60.0d;      // 185.18518518518518518518518518519d
        private const double DegSecToGradSec = DegMinToGradSec / 60.0d;   // 3.0864197530864197530864197530864
        private const double DegMasToGradSec = DegSecToGradSec / 1000.0d; // 0.00308641975308641975308641975309
        private const double GradSecToDeg    = GradMinToDeg / 100d;       // 0.00009d
        private const double GradSecToDegMin = GradSecToDeg * 60.0d;      // 0.0054d
        private const double GradSecToDegSec = GradSecToDegMin * 60.0d;   // 0.324d
        private const double GradSecToDegMas = GradSecToDegMin * 1000.0d; // 324d

        private const double GradToRad     = double.Pi / 200.0d;    // 0.0157079632679489661923132169164d
        private const double GradMinToRad  = GradToRad / 100.0d;    // 0.00015707963267948966192313216916398d
        private const double GradSecToRad  = GradMinToRad / 100.0d; // 0.0000015707963267948966192313216916398d
        private const double RadToGrad     = 200.0d / double.Pi;    // 63.661977236758134307553505349006d
        private const double RadToGradMin  = RadToGrad * 100.0d;    // 6366.1977236758134307553505349006d
        private const double RadToGradSec  = RadToGradMin * 100.0d; // 636619.77236758134307553505349006d

        private const int    TurnDigits    = 15;
        private const double RadTurn       = Pi2;            // 6.283185307179586476925286766559d
        private const double RadTurnNeg    = Pi2 * -1d;      // -6.283185307179586476925286766559d
        private const int    RadDigits     = 15;
        private const double MRadTurn      = Pi2 * 1000d;    // 6283.185307179586476925286766559d
        private const double MRadTurnNeg   = MRadTurn * -1d; // -6283.185307179586476925286766559d
        private const int    MRadDigits    = 12;
        private const double PiTurn        =  2.0d;
        private const double PiTurnNeg     = -2.0d;
        private const int    PIDigits      = 15;
        private const double DegTurn       =  360.0d;
        private const double DegTurnNeg    = -360.0d;
        private const int    DegDigits     = 13;
        private const double DegMinTurn    = DegTurn * 60.0d;     //  21600.0d
        private const double DegMinTurnNeg = DegTurn * -60.0d;    // -21600.0d
        private const int    DegMinDigits  = 11;
        private const double DegSecTurn    = DegMinTurn * 60.0d;  //  1296000.0d
        private const double DegSecTurnNeg = DegMinTurn * -60.0d; // -1296000.0d
        private const int    DegSecDigits = 9;
        private const double GradTurn       =  400.0d;
        private const double GradTurnNeg    = -400.0d;
        private const double GradMinTurn    =  40000.0d;   // Grad *  100.0d
        private const double GradMinTurnNeg = -40000.0d;   // Grad * -100.0d
        private const double GradSecTurn    =  4000000.0d; // GradMin *  100.0d
        private const double GradSecTurnNeg = -4000000.0d; // GradMin * -100.0d
        private const double SextantTurn    =  6.0d;
        private const double SextantTurnNeg = -6.0d;
    }
}
