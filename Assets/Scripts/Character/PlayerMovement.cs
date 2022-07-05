using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _speed;

    public event UnityAction PositionUpdated;

    private void FixedUpdate() => Move();

    private void Move()
    {
        var rawDirection = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        _rigidbody.velocity = rawDirection * _speed + Vector3.up * _rigidbody.velocity.y;

        if (rawDirection.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            PositionUpdated?.Invoke();
        }
    }
}
