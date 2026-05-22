using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void Awake()
    {
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
        enemy.Dead += OnEnemyDied;
        enemy.Despawned += OnEnemyDespawned;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _scoreCounter.AddScore(enemy.ScorePrice);
        enemy.Dead -= OnEnemyDied;
    }

    private void OnEnemyDespawned(Enemy enemy)
    {
        enemy.Despawned -= OnEnemyDespawned;
        enemy.Dead -= OnEnemyDied;
    }
}
