using SOAPlus.Builtin.DotNetTypes;
using UnityEngine;

namespace SOAPlus.Builtin.Samples.Sample_01
{
    public class DebugListener : MonoBehaviour
    {
        public void DebugInt() => Debug.Log("DebugInt");

        public void DebugInt(int value) => Debug.Log($"DebugInt {value}");

        public void DebugInt(IntReference value) => Debug.Log($"DebugInt {value.Value}");
    }
}
