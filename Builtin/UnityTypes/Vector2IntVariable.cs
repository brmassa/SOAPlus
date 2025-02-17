using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Builtin.UnityTypes
{
    [CreateAssetMenu(fileName = "Vector2IntVariable", menuName = "SOAPlus/Builtin/Vector2IntVariable")]
    public class Vector2IntVariable : BaseVariable<Vector2Int>
    {
        public Vector2IntVariable() : base(Vector2Int.zero) { }
    }
}