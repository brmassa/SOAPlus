using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Builtin.DotNetTypes
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "SOAPlus/Builtin/IntVariable")]
    public class IntVariable : BaseVariable<int>
    {
        public IntVariable() : base(0) { }
    }
}
