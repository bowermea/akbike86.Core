using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Math
{
    internal class OrbitalFunctions
    {
        public static double OrbitalPeriod(double distance, double gravitationalParameter)
        {
            if (gravitationalParameter <= 0)
            { throw new ArgumentOutOfRangeException(nameof(gravitationalParameter), $"standard gravitational parameter must be a positive number {gravitationalParameter}"); }
            if (distance <= 0)
            { throw new ArgumentOutOfRangeException(nameof(distance), $"distance must be a positive number {distance}"); }
            return 2 * System.Math.PI * System.Math.Pow(distance, 1.5) / System.Math.Sqrt(gravitationalParameter);
        }
        public static double OrbitalPeriod(double distance, double primaryMass, double secondaryMass = 0)
        {
            return OrbitalPeriod(distance, (primaryMass + secondaryMass) * Constants.G);
        }

        public static double OrbitalDistance(double period, double gravitationalParameter)
        {
            throw new NotImplementedException();
        }
    }
}
