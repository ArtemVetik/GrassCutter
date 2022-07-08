using UnityEngine;
using DG.Tweening;

public class CuttingPictureEffect : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _model;
    [SerializeField] private PictureEvents _puctureEvents;
    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private Transform _smokeEffectContainer;
    [SerializeField] private Material _playerMaterial;
    [SerializeField] private Color _targetColor;

    private Color _startColor;

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
        _startColor = new Color(1, 1, 1);

        _playerMaterial.color = _startColor;
    }

    private void OnCutPicture()
    {
        var duration = 0.05f;
        _model.DOShakeScale(duration, 0.25f, 10);
        ChangeColor(_targetColor, 2, _startColor, 2);
        _playerMovement.ChangeSpeed(0.5f, duration);
        Instantiate(_smokeEffect, _smokeEffectContainer);
    }

    private void ChangeColor(Color targetColor, float durationToTarget, Color normalColor, float durationToNormal)
    {
        _playerMaterial.DOColor(targetColor, durationToTarget).
            OnComplete(() => _playerMaterial.DOColor(normalColor, durationToNormal));
    }
}
