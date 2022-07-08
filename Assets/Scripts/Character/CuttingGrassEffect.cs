using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CuttingGrassEffect : MonoBehaviour
{
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private ParticleSystem _cuttingEffect;

    private float _previousWinProgress;

    public event UnityAction CuttingGrass;

    private void OnEnable()
    {
        _levelProgress.Updated += OnCuttingGrass;
    }

    private void OnDisable()
    {
        _levelProgress.Updated -= OnCuttingGrass;
    }

    private void Start()
    {
        _previousWinProgress = 0f;
    }

    private void OnCuttingGrass()
    {
        if (_levelProgress.WinPercentage > _previousWinProgress)
        {
            _previousWinProgress = _levelProgress.WinPercentage;
            _cuttingEffect.Play();
            CuttingGrass?.Invoke();
        }
    }
}
