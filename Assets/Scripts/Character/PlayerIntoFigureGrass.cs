using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerIntoFigureGrass : MonoBehaviour
{
    [SerializeField] private LevelProgress _progress;

    private float _previousProgress;

    public event UnityAction FigureGrassChanged;

    private void OnEnable()
    {
        _progress.Updated += OnUpdateProgress;
    }

    private void OnDisable()
    {
        _progress.Updated -= OnUpdateProgress;
    }

    private void Start()
    {
        _previousProgress = 0f;
    }

    private void OnUpdateProgress()
    {
        if (_progress.LosePercentage > _previousProgress)
        {
            _previousProgress = _progress.LosePercentage;
            FigureGrassChanged?.Invoke();
        }
    }
}
