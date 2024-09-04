using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
//using MathNet.Numerics;
//using M = MathNet.Numerics.Constants;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace akbike86.Math.Trig
{

    public interface IAngle<TSelf> : IEquatable<TSelf>, IComparable<TSelf>
        , IAdditionOperators<TSelf, TSelf, TSelf>
        , ISubtractionOperators<TSelf, TSelf, TSelf>
        , IComparisonOperators<TSelf, TSelf, bool>
        , IEqualityOperators<TSelf, TSelf, bool> 
        //, IConvertible
        where TSelf : IAngle<TSelf>
    {
        public double Turns { get; }
        public double Degrees { get; }
        public double Radians { get; }
        public double Gradians { get; }
        public (ushort deg, double min) DegMin { get; }
        public (ushort deg, byte min, double sec) DegMinSec { get; }
        public (ushort deg, byte min, byte sec, uint nano) DegMinSecNano { get; }
        public TSelf Add(double angle, AngleMeasure type);
        public TSelf Diff(double angle, AngleMeasure type);
        public double AddDegree { set; }
        public double AddRadian { set; }
        public (ushort deg, byte min, byte sec, uint nano) AddDegMinSecNano { set; }

        public double Sin { get; }
        public double Cos { get; }
        public double Tan { get; }
        public double ArcSin { get; }
        public double ArcCos { get; }
        public double ArcTan { get; }

        public abstract static TSelf Degree(double angle);
        public abstract static TSelf Radian(double angle);
        public abstract static TSelf Gradian(double angle);
        public abstract static TSelf Angle(double angle, AngleMeasure type);

        public abstract static double Reduce(double angle, AngleMeasure type);
        public abstract static double Convert(double angle, AngleMeasure source, AngleMeasure target);
    }

    public readonly partial struct Angle : IAngle<Angle>
    //,IAdditionOperators<Angle,Angle,Angle>
    //,IEqualityOperators<Angle,Angle,Angle>
    {
        /// <summary>
        /// the measure of the angle in the base of radians (since all trigonometric functions operate on radians)
        /// </summary>
        private readonly double _angle;

        [JsonIgnore]
        public double Turns
        {
            get => _angle * 0.15915494309189533576888376337251d;
            init { _angle = Reduce(value, AngleMeasure.turn); }
        }
        /// <summary>
        /// Measure of the angle in radians between 0<small>(inclusive)</small> and 2π(exclusive)
        /// </summary>
        [JsonIgnore]
        public double Radians
        {
            get => _angle;
            //set {  _angle = (value % M.Pi2); }
            init { _angle = ReduceRadians(value); }
        }

        [JsonIgnore]
        public double Degrees
        {
            get => _angle * 57.295779513082320876798154814105d;
            //set => _angle = (value % 360) * 0.017453292519943295769236907684886127134428718885417d;
            init { _angle = DegreesToRadians(value); }
        }
        [JsonIgnore]
        public double Gradians
        {
            get => _angle * RadToGrad;
            init { _angle = GradToRad; }
        }

        public double Gradians => throw new NotImplementedException();

        public (ushort deg, double min) DegMin => throw new NotImplementedException();

        public (ushort deg, byte min, double sec) DegMinSec => throw new NotImplementedException();

        public (ushort deg, byte min, byte sec, uint nano) DegMinSecNano => throw new NotImplementedException();

        public double AddDegree { set => throw new NotImplementedException(); }
        public double AddRadian { set => throw new NotImplementedException(); }
        public (ushort deg, byte min, byte sec, uint nano) AddDegMinSecNano { set => throw new NotImplementedException(); }

        public double Sin => throw new NotImplementedException();

        public double Cos => throw new NotImplementedException();

        public double Tan => throw new NotImplementedException();

        public double ArcSin => throw new NotImplementedException();

        public double ArcCos => throw new NotImplementedException();

        public double ArcTan => throw new NotImplementedException();

        #region instantiation
        public Angle() { _angle = double.NaN; }
        public Angle(double angle) : this(angle, false) { }
        public Angle(double angle, bool asDegrees)
        {
            if (!angle.IsFinite()) { throw new ArgumentOutOfRangeException(nameof(angle), angle, "Can only create an angle object with a finite value"); }
            if (asDegrees) { Degrees = angle; }
            else { Radians = angle; }
        }
        public Angle(double angle, AngleMeasure type)
        {
            if (!angle.IsFinite()) { throw new ArgumentOutOfRangeException(nameof(angle), angle, "Can only create an angle object with a finite value"); }
            switch (type)
            {
                case AngleMeasure.rad:
                    break;
                case AngleMeasure.deg:
                    break;
                case AngleMeasure.grad:
                    break;
                case AngleMeasure.pi:
                    break;
                case AngleMeasure.min:
                    break;
                case AngleMeasure.sec:
                    break;
            }
        }
        public static Angle Degree(double degrees) => new Angle(degrees, true);
        public static Angle Radian(double radians) => new Angle(radians);
        public readonly static Angle Zero = new Angle(0);
        public readonly static Angle Right = new Angle(M.PiOver2);
        public readonly static Angle Half = new Angle(M.Pi);
        #endregion

        #region equality
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => _angle.GetHashCode();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals([NotNullWhen(true)] object? obj) => obj != null && obj is Angle && Equals((Angle)obj);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Angle other) => double.IsFinite(_angle) && double.IsFinite(other._angle) && _angle.Equals(other._angle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Angle? other) => other.HasValue && _angle.Equals(other.Value);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public readonly bool Equals(double other) => double.IsFinite(_angle) && double.IsFinite(other) && _angle.Equals(other);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public readonly bool Equals(double? other) => other.HasValue && Equals(other.Value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Angle left, Angle right) => left.Equals(right);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Angle left, Angle right) => !left.Equals(right);
        #endregion

        #region comparison
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly int CompareTo(Angle other) => _angle.CompareTo(other._angle);

        public Angle Add(double angle, AngleMeasure type)
        {
            throw new NotImplementedException();
        }

        public Angle Diff(double angle, AngleMeasure type)
        {
            throw new NotImplementedException();
        }


        static Angle IAngle<Angle>.Angle(double angle, AngleMeasure type)
        {
            throw new NotImplementedException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(Angle left, Angle right) => left.CompareTo(right) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(Angle left, Angle right) => left.CompareTo(right) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(Angle left, Angle right) => left.CompareTo(right) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(Angle left, Angle right) => left.CompareTo(right) >= 0;

        #endregion
    }


    public class AngleInt //AngleRad //: Angle : IAngle, IEquatable<Angle>, IComparable<Angle>
    {
        /// <summary>
        /// 1/14th picoseconds, or 1/9.072E-18 of a radian
        /// </summary>
        private readonly ulong _decatetropicosec; //0=0, 2(π) = 9,223,372,036,854,775,807

        private const ulong nanoDegDiv = 3600000000000;
        private const ulong nanoRadDiv = 648000000000000;
    }
    public class AngleDeg { }
    public class AngleDegMinSecNano { }

}
