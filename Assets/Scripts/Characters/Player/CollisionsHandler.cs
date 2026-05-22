using UnityEngine;

public class CollisionsHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageDealer damageDealer) && TryGetComponent(out IDamageble damageble))
        {
            damageDealer.DealDamage(damageble);
        }
    }
}
