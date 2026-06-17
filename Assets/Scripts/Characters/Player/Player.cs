using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Mover _mover;
    [SerializeField] private HealthSystem _healthSystem;    

    public event Action Died;
    public event Action Shooted;

    private void Awake()
    {
        _shooter.Init();
    }

    private void OnEnable()
    {
        _playerInput.AttackPressed += _shooter.Shoot;
        _playerInput.JumpPressed += _mover.Jump;
        _healthSystem.Died += OnDieing;
        _shooter.Shooted += OnShooting;
    }

    private void OnDisable()
    {
        _playerInput.AttackPressed -= _shooter.Shoot;
        _playerInput.JumpPressed -= _mover.Jump;
        _healthSystem.Died -= OnDieing;
        _shooter.Shooted -= OnShooting;
    }

    private void OnDieing()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnShooting()
    {
        Shooted?.Invoke();
    }
}
