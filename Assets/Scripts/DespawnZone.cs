using UnityEngine;

public class DespawnZone : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            _enemySpawner.HandleEnemyDespawn(enemy);
        }
    }
}
