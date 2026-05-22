using UnityEngine;

public class DespawnZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IPoolable poolable))
        {
            poolable.ReturnToPool();
        }
    }
}
