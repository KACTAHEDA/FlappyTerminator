using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;

    public void StartGame()
    {
        _sceneLoader.LoadGame();
    }

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
}
