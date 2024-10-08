using System.Numerics;

namespace akbike86.tactics.core.stat
{
    public struct StatByte
    {
        private byte minVal;

        public byte MinVal
        {
            get => minVal; protected set
            {
                minVal = value;
            }
        }
    }
}
