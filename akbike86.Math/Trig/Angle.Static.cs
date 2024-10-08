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
                        return Reduce(angle, Rad.Turn, Rad.TurnNeg).Round(Rad.Digits);
                    case AngleMeasure.mrad:
                        return Reduce(angle, MRad.Turn, MRad.TurnNeg).Round(MRad.Digits);
                    case AngleMeasure.pi:
                        return Reduce(angle, PI.Turn, PI.TurnNeg).Round(PI.Digits);
                    case AngleMeasure.deg:
                        return Reduce(angle, Deg.Turn, Deg.TurnNeg).Round(Deg.Digits);
                    case AngleMeasure.arcminute:
                        return Reduce(angle, DegMin.Turn, DegMin.TurnNeg).Round(DegMin.Digits);
                    case AngleMeasure.arcsecond:
                        return Reduce(angle, DegSec.Turn, DegSec.TurnNeg).Round(DegSec.Digits);
                    case AngleMeasure.milliarcsecond:
                        return Reduce(angle, DegMas.Turn, DegMas.TurnNeg).Round(DegMas.Digits);
                    case AngleMeasure.grad:
                        return Reduce(angle, Grad.Turn, Grad.TurnNeg).Round(Grad.Digits);
                    case AngleMeasure.centminute:
                        return Reduce(angle, GradMin.Turn, GradMin.TurnNeg).Round(GradMin.Digits);
                    case AngleMeasure.centsecond:
                        return Reduce(angle, GradSec.Turn, GradSec.TurnNeg).Round(GradSec.Digits);
                    case AngleMeasure.sextant:
                        return Reduce(angle, SextantTurn, SextantTurnNeg).Round(TurnDigits);
                }
                throw new ArgumentOutOfRangeException(nameof(type), type, $"Cannot reduce angle for invalid angle type.");
            }
            // cannot reduce NaN and positive or negative infinity to a proper angle, simply return NaN
            else { return double.NaN; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReduceDegrees(double degrees) => Reduce(degrees, AngleMeasure.degree);
        /*{
            // ensure we have a valid finite angle
            if (Double.IsFinite(degrees))
            {
                // since degrees range to hundreds, 13 decimals places can be reliably calculated
                return Reduce(degrees, 360d, -360d).Round(13);
                // return Reduce(degrees, M.DegreeCircle, M.DegreeCircleNeg).Round(13);
            }
            // cannot reduce NaN and positive or negative infinity to a proper angle, simply return NaN
            else { return double.NaN; }
        }*/

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
                            case AngleMeasure.rad: return angle * RadTurn;
                            case AngleMeasure.mrad: return angle * MRadTurn;
                            case AngleMeasure.pi: return angle * PiTurn;
                            case AngleMeasure.deg: return angle * DegTurn;
                            case AngleMeasure.arcmin: return angle * DegMinTurn;
                            case AngleMeasure.arcsec: return angle * DegSecTurn;
                            case AngleMeasure.mas: return angle * DegMasTurn;
                            case AngleMeasure.grad: return angle * GradTurn;
                            case AngleMeasure.centmin: return angle * GradMinTurn;
                            case AngleMeasure.centsec: return angle * GradSecTurn;
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
                            case AngleMeasure.arcmin: return angle * RadToDegMin;
                            case AngleMeasure.arcsec: return angle * RadToDegSec;
                            case AngleMeasure.mas: return angle * RadToDegMas;
                            case AngleMeasure.grad: return angle * RadToGrad;
                            case AngleMeasure.centmin: return angle * RadToGradMin;
                            case AngleMeasure.centsec: return angle * RadToGradSec;
                            case AngleMeasure.sextant: return angle * RadToSextant;
                            default: throw new ArgumentOutOfRangeException(nameof(target), target, $"Cannot convert to angle measure to unknown type {target}.");
                        }
                    case AngleMeasure.mrad:
                        switch (target)
                        {
                            case AngleMeasure.turn: return angle * MRadTurn;
                            case AngleMeasure.rad: return angle * ;
                            case AngleMeasure.mrad: return angle * ;
                            case AngleMeasure.pi: return angle * ;
                            case AngleMeasure.deg: return angle * ;
                            case AngleMeasure.arcmin: return angle * ;
                            case AngleMeasure.arcsec: return angle * ;
                            case AngleMeasure.mas: return angle * ;
                            case AngleMeasure.grad: return angle * ;
                            case AngleMeasure.centmin: return angle * ;
                            case AngleMeasure.centsec: return angle * ;
                            case AngleMeasure.sextant: return angle * ;
                            default: throw new ArgumentOutOfRangeException(nameof(target), target, $"Cannot convert to angle measure to unknown type {target}.");
                        }
                    case AngleMeasure.pi:
                        switch (target)
                        {
                            case AngleMeasure.turn: return angle * ;
                            case AngleMeasure.rad: return angle * ;
                            case AngleMeasure.mrad: return angle * ;
                            case AngleMeasure.pi: return angle * ;
                            case AngleMeasure.deg: return angle * ;
                            case AngleMeasure.arcmin: return angle * ;
                            case AngleMeasure.arcsec: return angle * ;
                            case AngleMeasure.mas: return angle * ;
                            case AngleMeasure.grad: return angle * ;
                            case AngleMeasure.centmin: return angle * ;
                            case AngleMeasure.centsec: return angle * ;
                            case AngleMeasure.sextant: return angle * ;
                            default: throw new ArgumentOutOfRangeException(nameof(target), target, $"Cannot convert to angle measure to unknown type {target}.");
                        }
                    case AngleMeasure.deg:
                        switch (target)
                        {
                            case AngleMeasure.turn: return angle * ;
                            case AngleMeasure.rad: return angle * ;
                            case AngleMeasure.mrad: return angle * ;
                            case AngleMeasure.pi: return angle * ;
                            case AngleMeasure.deg: return angle * ;
                            case AngleMeasure.arcmin: return angle * ;
                            case AngleMeasure.arcsec: return angle * ;
                            case AngleMeasure.mas: return angle * ;
                            case AngleMeasure.grad: return angle * ;
                            case AngleMeasure.centmin: return angle * ;
                            case AngleMeasure.centsec: return angle * ;
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

        internal static class Rad
        {
            /// <summary>Factor of <see cref="AngleMeasure.rad"/> in a full turn/revolution <code>2π = 6.283185307179586476925286766559</code></summary>
            internal const double Turn      = Pi2;
            /// <summary>The negative value of <see cref="Turn"/><code>-2π = -6.283185307179586476925286766559</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1 / 2π = 0.15915494309189533576888376337251</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.rad"/></summary>
            internal const int    Digits    = 15; 

            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.mrad"/><code>1000</code></summary>
            internal const double ToMrad    = MRad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.pi"/><code>2/2π = 1/π = 0.31830988618379067153776752674503</code></summary>
            internal const double ToPI      = PI.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.deg"/><code>360/2π = 180/π = 57.295779513082320876798154814105</code></summary>
            internal const double ToDeg     = Deg.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.degmin"/><code>180/π * 60 = 3437.7467707849392526078892888463</code></summary>
            internal const double ToDegMin  = DegMin.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.degsec"/><code>180/π * 60 * 60 = 206264.80624709635515647335733078</code></summary>
            internal const double ToDegSec  = DegSec.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.degmas"/><code>180/π * 60 * 60 * 1000 = 206264806.24709635515647335733078</code></summary>
            internal const double ToDegMas  = DegMas.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.grad"/><code>400/2π = 200/π = 63.661977236758134307553505349006</code></summary>
            internal const double ToGrad    = Grad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.centmin"/><code>200/π * 100 = 6366.1977236758134307553505349006</code></summary>
            internal const double ToGradMin = GradMin.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.centsec"/><code>200/π * 100 * 100 = 636619.77236758134307553505349006</code></summary>
            internal const double ToGradSec = GradSec.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.rad"/> to <see cref="AngleMeasure.sextant"/><code>6/2π = 3/π = 0.95492965855137201461330258023509</code></summary>
            internal const double ToSextant = SextantTurn / Turn;
        }
        internal static class MRad
        {
            /// <summary>Factor of <see cref="AngleMeasure.mrad"/> in a full turn/revolution <code>2000π = 6283.185307179586476925286766559</code></summary>
            internal const double Turn      = Pi2 * 1000d;
            /// <summary>The negative value of <see cref="Turn"/><code>-2000π = -6283.185307179586476925286766559</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1 / 2000π = 0.00015915494309189533576888376337251</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.mrad"/></summary>
            internal const int    Digits    = 12;

            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.rad"/><code>0.001</code></summary>
            internal const double ToRad     = 0.001d;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.pi"/><code>1/1000π = 0.00031830988618379067153776752674503</code></summary>
            internal const double ToPI      = ToRad / double.Pi;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.deg"/><code>180/1000π = 0.05729577951308232087679815481411</code></summary>
            internal const double ToDeg     = 0.18d / double.Pi;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.degmin"/><code>180/1000π * 60 = 3.4377467707849392526078892888463</code></summary>
            internal const double ToDegMin  = ToDeg * 60.0d;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.degsec"/><code>180/1000π * 60 * 60 = 206.26480624709635515647335733078</code></summary>
            internal const double ToDegSec  = ToDegMin * 60.0d;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.degmas"/><code>180/π * 60 * 60 = 206264.80624709635515647335733078</code></summary>
            internal const double ToDegMas  = ToDegSec * 1000.0d;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.grad"/><code>200/1000π = 1/5π = 0.063661977236758134307553505349006</code></summary>
            internal const double ToGrad    = 0.2d / double.Pi;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.centmin"/><code>200/1000π * 100 = 20/π = 6.3661977236758134307553505349006</code></summary>
            internal const double ToGradMin = ToGrad * 100.0d;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.centsec"/><code>200/1000π * 100 * 100 = 2000/π = 636.61977236758134307553505349006</code></summary>
            internal const double ToGradSec = ToGradMin * 100.0d;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.mrad"/> to <see cref="AngleMeasure.sextant"/><code>3/1000π = 0.00095492965855137201461330258023509</code></summary>
            internal const double ToSextant = 0.003 / double.Pi;
        }
        internal static class PI
        {
            /// <summary>Factor of <see cref="AngleMeasure.pi"/> in a full turn/revolution <code>2</code></summary>
            internal const double Turn      = 2.0d;
            /// <summary>The negative value of <see cref="Turn"/><code>-2</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1/2 = 0.5</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.pi"/></summary>
            internal const int    Digits    = 15;

            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.rad"/><code>#TODO = </code></summary>
            internal const double ToRad     = Rad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.mrad"/><code>#TODO = </code></summary>
            internal const double ToMrad    = MRad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.pi"/><code>#TODO = </code></summary>
            internal const double ToPI      = PI.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.deg"/><code>#TODO = </code></summary>
            internal const double ToDeg     = Deg.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.degmin"/><code>#TODO = </code></summary>
            internal const double ToDegMin  = DegMin.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.degsec"/><code>#TODO = </code></summary>
            internal const double ToDegSec  = DegSec.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.degmas"/><code>#TODO = </code></summary>
            internal const double ToDegMas  = DegMas.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.grad"/><code>#TODO = </code></summary>
            internal const double ToGrad    = Grad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.centmin"/><code>#TODO = </code></summary>
            internal const double ToGradMin = GradMin.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.centsec"/><code>#TODO = </code></summary>
            internal const double ToGradSec = GradSec.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure."/> to <see cref="AngleMeasure.sextant"/><code>#TODO = </code></summary>
            internal const double ToSextant = SextantTurn / Turn;

        }
        internal static class Deg
        {
            /// <summary>Factor of <see cref="AngleMeasure.deg"/> in a full turn/revolution <code>360</code></summary>
            internal const double Turn      = 360.0d;
            /// <summary>The negative value of <see cref="Turn"/><code>-360</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1 / 360 = 0.00277777777777777777777777777778</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.deg"/></summary>
            internal const int    Digits    = 13;

            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.rad"/><code>2π/360 = π/180 = 0.017453292519943295769236907684886</code></summary>
            internal const double ToRad     = Rad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.mrad"/><code>2π/360 * 1000 = 50π/9 = 17.453292519943295769236907684886</code></summary>
            internal const double ToMrad    = MRad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.pi"/><code>2/360 = 1/180 = 0.00555555555555555555555555555556</code></summary>
            internal const double ToPI      = PI.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.degmin"/><code>60</code></summary>
            internal const double ToDegMin  = DegMin.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.degsec"/><code>60 * 60 = 3600</code></summary>
            internal const double ToDegSec  = DegSec.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.degmas"/><code>60 * 60 * 1000 = 3600000</code></summary>
            internal const double ToDegMas  = DegMas.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.grad"/><code>400/360 = 10/9 = 1.1111111111111111111111111111111</code></summary>
            internal const double ToGrad    = Grad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.centmin"/><code>10/9 * 100 = 111.11111111111111111111111111111</code></summary>
            internal const double ToGradMin = GradMin.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.centsec"/><code>10/9 * 100 * 100 = 11111.111111111111111111111111111</code></summary>
            internal const double ToGradSec = GradSec.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.deg"/> to <see cref="AngleMeasure.sextant"/><code>6/360 = 1/60 = 0.01666666666666666666666666666667</code></summary>
            internal const double ToSextant = SextantTurn / Turn;
        }
        internal static class DegMin
        {
            /// <summary>Factor of <see cref="AngleMeasure.min"/> in a full turn/revolution <code><see cref="Deg.Turn"/> * 60 = 21600</code></summary>
            internal const double Turn      = Deg.Turn * 60.0d;
            /// <summary>The negative value of <see cref="Turn"/><code>-<see cref="Deg.Turn"/> * 60 = -21600</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1/21600 = 4.6296296296296296296296296296296e-5</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.min"/></summary>
            internal const int    Digits    = 11;

            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.rad"/><code>2π/(360 * 60) = π/10800 = 0.00029088820866572159615394846141477</code></summary>
            internal const double ToRad = Rad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.mrad"/><code>(2π * 1000)/(360 * 60) = 5π/54 = 0.29088820866572159615394846141477</code></summary>
            internal const double ToMrad = MRad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.pi"/><code>2/(360 * 60) = 1/10800 = 9.2592592592592592592592592592593e-5</code></summary>
            internal const double ToPI = PI.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.deg"/><code>1/60 = 0.01666666666666666666666666666667</code></summary>
            internal const double ToDeg = Deg.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.degsec"/><code>60</code></summary>
            internal const double ToDegSec = DegSec.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.degmas"/><code>60 * 1000 = 60000</code></summary>
            internal const double ToDegMas = DegMas.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.grad"/><code>10/9 * 1/60 = 1/54 = 0.018518518518518518518518518518519</code></summary>
            internal const double ToGrad = Grad.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.centmin"/><code>1/54 * 100 = 50/27 = 1.8518518518518518518518518518519</code></summary>
            internal const double ToGradMin = GradMin.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.centsec"/><code>1/54 * 100 * 100 = 5000/27 = 185.18518518518518518518518518519</code></summary>
            internal const double ToGradSec = GradSec.Turn / Turn;
            /// <summary>Factor (multiplicative) to convert <see cref="AngleMeasure.min"/> to <see cref="AngleMeasure.sextant"/><code>6 /(360 * 60) = 1/3600 = 2.7777777777777777777777777777778e-4</code></summary>
            internal const double ToSextant = SextantTurn / Turn;
        }
        internal static class DegSec
        {
            /// <summary>Factor of <see cref="AngleMeasure.sec"/> in a full turn/revolution <code><see cref="DegMin.Turn"/> * 60 = 1296000</code></summary>
            internal const double Turn      = DegMin.Turn * 60.0d;
            /// <summary>The negative value of <see cref="Turn"/><code>-<see cref="DegMin.Turn"/> * 60 = -1296000</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1 / 1296000 = 7.716049382716049382716049382716e-7</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.sec"/></summary>
            internal const int    Digits    = 9;


            private const double DegSecToRad   = DegMinToRad / 60.0d;   // 4.8481368110953599358991410235795e-6
        private const double DegSecToGrad  = DegMinToGrad / 60.0d;  // 3.0864197530864197530864197530864e-4
        private const double DegSecToGradMin = DegMinToGradMin / 60.0d;   // 0.030864197530864197530864197530864d
        private const double DegSecToGradSec = DegMinToGradSec / 60.0d;   // 3.0864197530864197530864197530864
        }
        internal static class DegMas
        {
            /// <summary>Factor of <see cref="AngleMeasure.mas"/> in a full turn/revolution <code><see cref="DegSec.Turn"/> * 1000 = 1296000000</code></summary>
            internal const double Turn      = DegSec.Turn * 1000.0d;
            /// <summary>The negative value of <see cref="Turn"/><code>-<see cref="DegSec.Turn"/> * 1000 = -1296000000</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1 / 1296000000 = 7.716049382716049382716049382716e-10</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.mas"/></summary>
            internal const int    Digits    = 6;

        private const double DegMasToRad   = DegSecToRad / 1000.0d; // 4.8481368110953599358991410235795e-9
        private const double DegMasToGrad  = DegSecToGrad / 1000.0d;// 3.0864197530864197530864197530864e-7
        private const double DegMasToGradMin = DegSecToGradMin / 1000.0d; // 0.000030864197530864197530864197530864d
        private const double DegMasToGradSec = DegSecToGradSec / 1000.0d; // 0.00308641975308641975308641975309
        }
        internal static class Grad
        {
            /// <summary>Factor of <see cref="AngleMeasure.grad"/> in a full turn/revolution <code>400</code></summary>
            internal const double Turn      = 400.0d;
            /// <summary>The negative value of <see cref="Turn"/><code>-400</code></summary>
            internal const double TurnNeg   = -Turn;    // -400.0d
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1 / 400 = 0.0025</code></summary>
            internal const double TurnInv   = 1d / Turn;     //  0.0025d
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.grad"/></summary>
            internal const int    Digits    = 13;

            internal const double ToRad     = double.Pi / 200.0d;    // 0.0157079632679489661923132169164d
            internal const double ToDeg     = 0.9d;
            internal const double ToDegMin  = ToDeg * 60.0d;     // 54d
            internal const double ToDegSec  = ToDegMin * 60.0d;  // 3240d
            internal const double ToDegMas  = ToDegSec * 1000.0d;// 3240000d
        }
        internal static class GradMin
        {
            /// <summary>Factor of <see cref="AngleMeasure.centmin"/> in a full turn/revolution <code><see cref="Grad.Turn"/> * 100 = 40000</code></summary>
            internal const double Turn      = Grad.Turn * 100.0d;
            /// <summary>The negative value of <see cref="Turn"/><code>-<see cref="Grad.Turn"/> * 100 = -40000</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1 / 40000 = 0.000025</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.centmin"/></summary>
            internal const int Digits       = 11;

            internal const double ToRad  = Grad.ToRad / 100.0d;    // 0.00015707963267948966192313216916398d
            internal const double ToDeg     = Grad.ToDeg / 100d;          // 0.009
            internal const double ToDegMin  = ToDeg * 60.0d;      // 0.54d
            internal const double ToDegSec  = ToDegMin * 60.0d;   // 32.4d 
            internal const double ToDegMas  = ToDegMin * 1000.0d; // 32400d
        }
        internal static class GradSec
        {
            /// <summary>Factor of <see cref="AngleMeasure.centsec"/> in a full turn/revolution <code><see cref="GradMin.Turn"/> * 100 = 4000000</code></summary>
            internal const double Turn      = GradMin.Turn * 100.0d;
            /// <summary>The negative value of <see cref="Turn"/><code>-<see cref="GradMin.Turn"/> * 100 = -4000000</code></summary>
            internal const double TurnNeg   = -Turn;
            /// <summary>The reciprocal value of <see cref="Turn"/><code>1 / 4000000 = 0.00000025</code></summary>
            internal const double TurnInv   = 1d / Turn;
            /// <summary>Number of significant decimal digits for a <see cref="double"/>-precision measurement of <see cref="AngleMeasure.centsec"/></summary>
            internal const int Digits       = 9;

            internal const double ToRad  = GradMin.ToRad / 100.0d; // 0.0000015707963267948966192313216916398d
            internal const double ToDeg     = GradMin.ToDeg / 100d;       // 0.00009d
            internal const double ToDegMin  = ToDeg * 60.0d;      // 0.0054d
            internal const double ToDegSec  = ToDegMin * 60.0d;   // 0.324d
            internal const double ToDegMas  = ToDegMin * 1000.0d; // 324d
        }

        internal const int    TurnDigits    = 15;
        internal const double SextantTurn   =  6.0d;
        internal const double SextantTurnNeg= -6.0d;
    }
}
