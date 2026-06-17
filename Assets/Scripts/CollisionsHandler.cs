using UnityEngine;

public class CollisionsHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out IDamageDealer damageDealer) && collision.TryGetComponent(out IDamageable damageble))
        {
            damageDealer.DealDamage(damageble);
        }
    }
}
