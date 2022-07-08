using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PictureEvents : MonoBehaviour
{
    [SerializeField] private LevelProgress _progress;
    [SerializeField] private Material _lawnMoverMaterial;

    private float _previousLoseProgress;
    private float _previousWinProgress;
    private Color _normarColor;
    private Color _targetColor;

    public event UnityAction CuttingPicture;
    public event UnityAction CuttingGrass;

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
        _previousLoseProgress = 0f;
        _previousWinProgress = 0f;

        _normarColor = new Color(1, 1, 1);
        _targetColor = new Color(0.3396226f, 0.3396226f, 0.3396226f);
    }

    private void OnUpdateProgress()
    {
        if (_progress.LosePercentage > _previousLoseProgress)
        {
            _previousLoseProgress = _progress.LosePercentage;
            ChangeColor(_targetColor, 3);
            CuttingPicture?.Invoke();
        }
        if (_progress.WinPercentage > _previousWinProgress)
        {
            _previousWinProgress = _progress.WinPercentage;
            ChangeColor(_normarColor, 1);
            CuttingGrass?.Invoke();
        }
    }

    private void ChangeColor(Color targetColor, float duration)
    {
        _lawnMoverMaterial.DOColor(targetColor, duration);
    }
}
