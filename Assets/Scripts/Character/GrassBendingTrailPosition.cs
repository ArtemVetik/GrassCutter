using UnityEngine;

public class GrassBendingTrailPosition : MonoBehaviour
{
    [SerializeField] private Transform _instancedIndirectGrass;

    private void Update()
    {
        var position = transform.position;
        position.y = _instancedIndirectGrass.position.y;
        transform.position = position;
    }
}
