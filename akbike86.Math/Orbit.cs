using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math
{
    internal class Orbit
    {
        private readonly UInt64 _gm;
        private readonly UInt64 _a;
        private readonly double _a2;
        private readonly double _b;
        private readonly double _c;
        private readonly double _e;
        private readonly double _l;
        private readonly double _I;
        private readonly double _La;
        private readonly double _Lp;
        public double GM => _gm;

        public Orbit(UInt64 a, double e, UInt64 GM, double I, double La, double Lp)
        {
            _a = a;
            _a2 = System.Math.Pow(_a, 2D);
            _e = e;
            _gm = GM;
            _I = I;
            _La = La;
            _Lp = Lp;
            akbike86.Math.Constants.OrbitalData.
        }
    }
}
