using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.tactics.core.stat
{
    public interface IStatBase<T> where T : struct
    {
        static readonly T Min;
        static readonly T Max;

        IStatBonus[] Bonuses { get; protected set; }
    }
}
