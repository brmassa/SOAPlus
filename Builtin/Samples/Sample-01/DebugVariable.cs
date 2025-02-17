using SOAPlus.Builtin.DotNetTypes;
using UnityEngine;
using UnityEngine.Serialization;

namespace SOAPlus.Builtin.Samples.Sample_01
{
    public class DebugVariable : MonoBehaviour
    {
        [FormerlySerializedAs("_intVariable")]
        [SerializeField]
        private IntVariable intVariable;

        #region MonoBehaviour

        private void OnValidate()
        {
            if (intVariable != null)
            {
                intVariable.Value = intVariable.Value;
            }
        }

        #endregion MonoBehaviour

        [ContextMenu("Add 10")]
        private void Add10() => intVariable.Value += 10;

        [ContextMenu("Remove 10")]
        private void Remove10() => intVariable.Value -= 10;
    }
}
