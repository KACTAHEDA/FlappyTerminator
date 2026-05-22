using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
        AudioPlayer.Instance.PlayMainMenuClip();
    }

    public void StartGame()
    {
        AudioPlayer.Instance.PlayGameClip();
        SceneLoader.Instance.LoadGame();
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
