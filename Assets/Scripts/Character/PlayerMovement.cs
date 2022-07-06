using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _speed = 50;

    private float _speedRate;
    private Coroutine _changeSpeed;

    public event UnityAction PositionUpdated;

    private void Start()
    {
        _speedRate = 1;
    }

    private void FixedUpdate() => Move();

    public void ChangeSpeed(float speedFactor, float duration)
    {
        if (_changeSpeed != null)
            StopCoroutine(_changeSpeed);

        _changeSpeed = StartCoroutine(ChangeSpeedCoroutine(speedFactor, duration));
    }

    private void Move()
    {
        var rawDirection = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        _rigidbody.velocity = rawDirection * _speed * _speedRate + Vector3.up * _rigidbody.velocity.y;

        if (rawDirection.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            PositionUpdated?.Invoke();
        }
    }

    private IEnumerator ChangeSpeedCoroutine(float speedFactor, float duration)
    {
        _speedRate = speedFactor;
        yield return new WaitForSeconds(duration);
        _speedRate = 1;
    }
}
