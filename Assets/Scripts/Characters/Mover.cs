using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void FixedUpdate()
    {
        HandleRotation();
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, _jumpForce);
        transform.rotation = _maxRotation;
    }

    private void HandleRotation()
    {
        float angle = Mathf.Lerp(
            _maxRotationZ,
            _minRotationZ,
            Mathf.InverseLerp(_jumpForce, -_jumpForce, _rigidbody.velocity.y)
            );

        angle = Mathf.MoveTowards(angle, _minRotationZ, _maxRotationZ);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            _rotationSpeed * Time.deltaTime);
    }
}
