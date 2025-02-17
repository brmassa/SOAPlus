using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Builtin.UnityTypes
{
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "SOAPlus/Builtin/Vector3Variable")]
    public class Vector3Variable : BaseVariable<Vector3>
    {
        public Vector3Variable() : base(Vector3.zero) { }
    }
}