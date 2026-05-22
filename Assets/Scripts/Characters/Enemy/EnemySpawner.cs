using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnPoint> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _interval = 3f;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 50;

    private ObjectPool<Enemy> _enemysPool;
    private Coroutine _spawnCoroutine;

    public event Action<Enemy> EnemySpawned;

    private void Awake()
    {
        _enemysPool = CreatePool();
    }

    private void OnEnable()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);

        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        var delay = new WaitForSeconds(_interval);

        while (gameObject.activeInHierarchy)
        {
            yield return delay;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints == null || _spawnPoints.Count == 0)
        {
            return;
        }

        int randonIndex = UnityEngine.Random.Range(0, _spawnPoints.Count);
        EnemySpawnPoint point = _spawnPoints[randonIndex];

        Enemy enemy = _enemysPool.Get();

        enemy.ClearDeadEvent();

        EnemySpawned?.Invoke(enemy);
        enemy.Dead += HandleEnemyDead;

        enemy.transform.position = point.transform.position;
    }

    private ObjectPool<Enemy> CreatePool()
    {
        ObjectPool<Enemy> pool = new ObjectPool<Enemy>(
            CreateEnemy,
            OnTakeEnemy,
            OnReturnEnemy,
            OnDestroyEnemy,
            true,
            _defaultCapacity,
            _maxSize
            );

        return pool;
    }

    private Enemy CreateEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab);
        
        enemy.Despawned += HandleEnemyDead;
        enemy.gameObject.SetActive(false);
        return enemy;
    }

    private void HandleEnemyDead(Enemy enemy)
    {
        _enemysPool.Release(enemy);
    }

    private void OnTakeEnemy(Enemy enemy) => enemy.gameObject.SetActive(true);
    private void OnReturnEnemy(Enemy enemy) => enemy.gameObject.SetActive(false);

    private void OnDestroyEnemy(Enemy enemy) 
    {
        enemy.Dead -= HandleEnemyDead;
        enemy.Despawned -= HandleEnemyDead;
        Destroy(enemy.gameObject);
    }
} 
