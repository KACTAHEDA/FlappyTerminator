using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    private const string MAIN_MENU = "MainMenu";
    private const string GAME = "Game";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(GAME);
    }
}
