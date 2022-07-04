using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _speed;

    private void Update() => Move();

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed,
            _rigidbody.velocity.y, _joystick.Vertical * _speed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
    }
}
