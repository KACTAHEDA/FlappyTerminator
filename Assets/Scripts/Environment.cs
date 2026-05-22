using UnityEngine;

public class Environment : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int _collisionDamage = 1;

    public void DealDamage(IDamageble target)
    {
        target.TakeDamage(_collisionDamage);
    }
}
