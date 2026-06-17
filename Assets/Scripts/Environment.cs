using UnityEngine;

public class Environment : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int _collisionDamage = 1;

    public void DealDamage(IDamageable target)
    {
        target.TakeDamage(_collisionDamage);
    }
}
