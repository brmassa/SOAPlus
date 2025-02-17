using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Builtin.DotNetTypes
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "SOAPlus/Builtin/BoolVariable")]
    public class BoolVariable : BaseVariable<bool>
    {
        public BoolVariable() : base(false) { }
    }
}
