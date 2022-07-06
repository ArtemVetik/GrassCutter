using UnityEngine;
using DG.Tweening;

public class CuttingPictureEffect : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _model;
    [SerializeField] private PictureEvents _figureGrass;

    private void OnEnable()
    {
        _figureGrass.CuttingPicture += OnCutPicture;
    }

    private void OnDisable()
    {
        _figureGrass.CuttingPicture -= OnCutPicture;
    }

    private void OnCutPicture()
    {
        var duration = 0.05f;
        _model.DOShakeScale(duration, 0.25f, 10);
        _playerMovement.ChangeSpeed(0.5f, duration);
    }
}
