using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Scene
{
    [CreateAssetMenu(fileName = "SceneVariable", menuName = "SOAPlus/Scene/SceneVariable")]
    public class SceneVariable : BaseVariable<UnityEngine.SceneManagement.Scene>
    {
        public SceneVariable(UnityEngine.SceneManagement.Scene initialValue) : base(initialValue)
        {
        }
    }
}
