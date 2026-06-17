using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private HealthSystem _healthSystem;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void Awake()
    {
        Display();        
    }

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += Display;
        _healthSystem.HealthChanged += Display;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= Display;
        _healthSystem.HealthChanged -= Display;
    }

    private void Display()
    {
        _scoreText.text = $" : {_scoreCounter.CurentScore}";
        _healthText.text = $" : {_healthSystem.Health}";

        Canvas.ForceUpdateCanvases();
    }
}
