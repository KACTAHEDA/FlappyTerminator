using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour , IDamageble
{
    [SerializeField] private int _maxHealth = 1;

    private int _curentHealth;

    public event Action HealthChanged;
    public event Action Died;

    public int Health => _curentHealth;

    private void OnEnable()
    {
        _curentHealth = _maxHealth;
        HealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _curentHealth -= damage;
        HealthChanged?.Invoke();

        if (_curentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
