using UnityEngine;

public class CuttingPictureEffect : MonoBehaviour
{
    [SerializeField] private PictureEvents _puctureEvents;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Renderer _renderer;

    private Color _startColor;
    private Material _material;

    private void OnEnable()
    {
        _puctureEvents.CuttingPicture += OnCutPicture;
    }

    private void OnDisable()
    {
        _puctureEvents.CuttingPicture -= OnCutPicture;
        _material.color = _startColor;
    }

    private void Start()
    {
        _material = _renderer.sharedMaterial;
        _startColor = _material.color;
    }

    private void OnCutPicture()
    {
        var duration = 0.05f;
        _playerMovement.ChangeSpeed(0.2f, duration);
    }
}
