using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Scene
{
    [CreateAssetMenu(fileName = "SceneEvent", menuName = "SOAPlus/Scene/SceneEvent")]
    public class SceneEvent : BaseEvent<UnityEngine.SceneManagement.Scene> { }
}
