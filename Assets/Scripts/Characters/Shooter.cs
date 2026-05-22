using UnityEngine.Pool;
using UnityEngine;
using System;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 50;

    private ObjectPool<Bullet> _bulletPool;

    public event Action Shooted;

    public void Init()
    {
        if (_bulletPool != null)
            return;

        _bulletPool = new ObjectPool<Bullet>(
          CreateBullet,
          OnTakeBullet,
          OnReturnBullet,
          OnDestrouBuller,
          false,
          _defaultCapacity,
          _maxSize
          );
    }

    public void Shoot()
    {
        Bullet bullet = _bulletPool.Get();       

        bullet.transform.position = _attackPoint.position;
        bullet.transform.rotation = _attackPoint.rotation;

        if(bullet.GetComponent<Collider2D>() == null || GetComponent<Collider2D>() == null)       
            return;

        Physics2D.IgnoreCollision(
            bullet.GetComponent<Collider2D>(),
            GetComponent<Collider2D>()
            );

        Vector2 direction = _attackPoint.right;
        bullet.Launch(direction);
        Shooted?.Invoke();
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab);

        bullet.OnBulletFree += HandleBulletFree;

        bullet.gameObject.SetActive(false);
        return bullet;
    }

    private void HandleBulletFree(Bullet bullet) => _bulletPool.Release(bullet);
    private void OnTakeBullet(Bullet bullet) => bullet.gameObject.SetActive(true);
    private void OnReturnBullet(Bullet bullet) => bullet.gameObject.SetActive(false);
    private void OnDestrouBuller(Bullet bullet) => Destroy(bullet.gameObject);
}
