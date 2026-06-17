using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour , IDamageDealer
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _shootInterval = 2f;
    [SerializeField] private int _scorePrice = 1;
    [SerializeField] private int _collisionDamage = 1;
    [SerializeField] private HealthSystem _healthSystem;

    private Shooter _shooter;
    private Rigidbody2D _rigidbody;
    private Coroutine _shootCoroutine;
    private bool _isAlive;

    public int ScorePrice => _scorePrice;

    public event Action<Enemy> Dead;
    public event Action<Enemy> Shooted;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _shooter = GetComponent<Shooter>();

        _shooter.Init();
    }

    private void OnEnable()
    {
        _isAlive = true;
        _rigidbody.velocity = Vector2.left * _speed;
        _healthSystem.Died += OnDieing;

        StartShooting();
    }

    private void OnDisable()
    {
        _healthSystem.Died -= OnDieing;
    }

    public void DealDamage(IDamageable target)
    {
        target.TakeDamage(_collisionDamage);
    }

    private IEnumerator ShootCoroutine()
    {
        WaitForSeconds interval = new WaitForSeconds(_shootInterval);

        while (gameObject.activeInHierarchy)
        {
            yield return interval;

            if (_isAlive == true && _shooter != null)
            {
                _shooter.Shoot();
                Shooted?.Invoke(this);
            }          
        }
    }

    private void StartShooting()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
        }

        _shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    private void OnDieing()
    {
        _isAlive = false;

        if(_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }

        Dead?.Invoke(this);
    }
}
