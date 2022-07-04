using UnityEngine;

public class GrassBendingTrailPosition : MonoBehaviour
{
    [SerializeField] private Transform _instancedIndirectGrass;

    private Transform _transform;
    private Vector3 _positionY;
    private Vector3 _positionYGrass;

    private void Awake()
    {
        _transform = GetComponent<Transform>();

        _positionY.y = _transform.position.y;
        _positionYGrass.y = _instancedIndirectGrass.position.y;

        _positionY.y = _positionYGrass.y;
    }
}
