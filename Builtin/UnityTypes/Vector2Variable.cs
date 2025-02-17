using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Builtin.UnityTypes
{
    [CreateAssetMenu(fileName = "Vector2Variable", menuName = "SOAPlus/Builtin/Vector2Variable")]
    public class Vector2Variable : BaseVariable<Vector2>
    {
        public Vector2Variable() : base(Vector2.zero) { }
    }
}