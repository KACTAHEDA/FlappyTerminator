using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour , IDamageable
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
        if (damage < 0)
            return;

        _curentHealth -= damage;
        _curentHealth = Mathf.Clamp(_curentHealth, 0, _maxHealth);

        HealthChanged?.Invoke();

        if (_curentHealth == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
