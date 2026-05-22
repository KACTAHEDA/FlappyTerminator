using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
       gameObject.SetActive(false);
        _player.GameOver += ShowGameOverUI;
    }

    private void OnDisable()
    {
        _player.GameOver -= ShowGameOverUI;
    }

    private void ShowGameOverUI()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        _scoreText.text = $"{_scoreCounter.CurentScore}";
        AudioPlayer.Instance.PlayGameOverClip();
    }

    public void Restart()
    {
        Time.timeScale = 1;
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
