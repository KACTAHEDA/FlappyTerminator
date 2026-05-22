using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D) , typeof(Collider2D))]
public class Bullet : MonoBehaviour, IDamageDealer, IPoolable
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _lifetime = 3f;

    private Rigidbody2D _rigidbody;
    private Coroutine _lifeCoroutine;
    private bool _isReleased;

    public int Damage => _damage;

    public event Action<Bullet> OnBulletFree;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void OnEnable()
    {
        _isReleased = false;

        if(_lifeCoroutine != null)
            StopCoroutine(_lifeCoroutine);

        _lifeCoroutine = StartCoroutine(LifeTimeCoroutine());
    }

    private void OnDisable()
    {
        if(_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);
            _lifeCoroutine = null;
        }
    }

    public void Launch(Vector2 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }

    public void DealDamage(IDamageble target)
    {
        target.TakeDamage(_damage);
        Release();
    }

    public void ReturnToPool()
    {
        Release();
    }

    private IEnumerator LifeTimeCoroutine()
    {
        WaitForSeconds lifetime = new WaitForSeconds(_lifetime);

        yield return lifetime;

        Release();
    }

    private void Release()
    {
        if (_isReleased)
            return;

        _isReleased = true;
        _rigidbody.velocity = Vector2.zero;
        OnBulletFree?.Invoke(this);
    }
}
