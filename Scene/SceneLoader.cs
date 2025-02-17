using UnityEngine.SceneManagement;

namespace SOAPlus.Scene
{
    public static class SceneLoader
    {
        public static void LoadScene(SceneVariable scene, LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadScene(scene.Value.name, mode);

        public static void UnloadScene(SceneVariable scene) => SceneManager.UnloadSceneAsync(scene.Value);
    }
}
