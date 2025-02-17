using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Builtin.UnityTypes
{
    [CreateAssetMenu(fileName = "Vector3IntVariable", menuName = "SOAPlus/Builtin/Vector3IntVariable")]
    public class Vector3IntVariable : BaseVariable<Vector3Int>
    {
        public Vector3IntVariable() : base(Vector3Int.zero) { }
    }
}