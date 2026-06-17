using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private MusicPlayer _musicPlayer;
    [SerializeField] private SceneLoader _sceneLoader;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
       gameObject.SetActive(false);
        _player.Died += ShowGameOverUI;
    }

    private void OnDisable()
    {
        _player.Died -= ShowGameOverUI;
    }

    private void ShowGameOverUI()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        _scoreText.text = $"{_scoreCounter.CurentScore}";
        _musicPlayer.PlayGameOverClip();
    }

    public void ReturnToMainMenu()
    {
        _sceneLoader.LoadMainMenu();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        _sceneLoader.LoadGame();
    }
}
