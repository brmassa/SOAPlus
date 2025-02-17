using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Builtin.DotNetTypes
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "SOAPlus/Builtin/FloatVariable")]
    public class FloatVariable : BaseVariable<float>
    {
        public FloatVariable() : base(0f) { }
    }
}
