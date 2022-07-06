using UnityEngine;
using UnityEngine.Events;

public class PictureEvents : MonoBehaviour
{
    [SerializeField] private LevelProgress _progress;

    private float _previousLoseProgress;

    public event UnityAction CuttingPicture;

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
    }

    private void OnUpdateProgress()
    {
        if (_progress.LosePercentage > _previousLoseProgress)
        {
            _previousLoseProgress = _progress.LosePercentage;
            CuttingPicture?.Invoke();
        }
    }
}
