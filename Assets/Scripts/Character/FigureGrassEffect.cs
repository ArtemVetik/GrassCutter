using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FigureGrassEffect : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerIntoFigureGrass _figureGrass;

    private void OnEnable()
    {
        _figureGrass.FigureGrassChanged += Shake;
    }

    private void OnDisable()
    {
        _figureGrass.FigureGrassChanged -= Shake;
    }

    private void Shake()
    {
        _playerMovement.transform.DOShakeScale(0.1f, 0.25f, 1);
        _playerMovement.ChangeSpeed(0.5f, 1);
    }
}
