using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOfset;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if(_player != null)
        {
        var position = transform.position;
        position.x = _player.transform.position.x + _xOfset;
        transform.position = position;
        }
    }
}
