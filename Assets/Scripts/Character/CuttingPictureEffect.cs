using UnityEngine;
using DG.Tweening;

public class CuttingPictureEffect : MonoBehaviour
{
    [SerializeField] private PictureEvents _puctureEvents;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _model;
    [SerializeField] private Transform _smokeEffectContainer;
    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _targetColor;

    private Color _startColor;
    private Material _material;

    private void OnEnable()
    {
        _puctureEvents.CuttingPicture += OnCutPicture;
    }

    private void OnDisable()
    {
        _puctureEvents.CuttingPicture -= OnCutPicture;
    }

    private void Start()
    {
        _material = _renderer.material;
        _startColor = _material.color;
        _renderer.material.color = _startColor;
    }

    private void OnCutPicture()
    {
        var duration = 0.05f;

        _model.DOShakeScale(duration, 0.25f, 10);
        _playerMovement.ChangeSpeed(0.5f, duration);

        ChangeColor(_targetColor, 2, _startColor, 1);
        Instantiate(_smokeEffect, _smokeEffectContainer);
    }

    private void ChangeColor(Color targetColor, float durationToTarget, Color normalColor, float durationToNormal)
    {
        _renderer.material.DOColor(targetColor, durationToTarget)
            .OnComplete(() => _renderer.material.DOColor(normalColor, durationToNormal));
    }
}
