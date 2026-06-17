using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private MusicPlayer _musicPlayer;

    private void Awake()
    {
        _musicPlayer.PlayGameClip();
        Time.timeScale = 1;       
    }

    private void OnEnable()
    {
        _enemySpawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemySpawned -= OnEnemySpawned;
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        enemy.Dead -= OnEnemyDied;
        enemy.Dead += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _scoreCounter.AddScore(enemy.ScorePrice);
        enemy.Dead -= OnEnemyDied;
    }
}
