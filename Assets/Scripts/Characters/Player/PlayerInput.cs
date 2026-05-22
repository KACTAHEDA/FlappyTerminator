using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse1;

    public event Action JumpPressed;
    public event Action AttackPressed;

    private void Update()
    {
        ReadJumpKey();
        ReadAttackKey();
    }

    private void ReadJumpKey()
    {
        if (Input.GetKeyDown(_jumpKey))
            JumpPressed?.Invoke();
    }

    private void ReadAttackKey()
    {
        if (Input.GetKeyDown(_attackKey))
            AttackPressed?.Invoke();
    }
}
