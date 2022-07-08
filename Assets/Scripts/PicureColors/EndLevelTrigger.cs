using UnityEngine;
using UnityEngine.Events;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private float _maxErrorPercentage = 0.03f;
    [SerializeField] private float _winPercentage = 0.95f;
    [SerializeField] private ParticleSystem _winEffect;

    public event UnityAction Won;
    public event UnityAction Lost;

    public float MaxErrorPercentage => _maxErrorPercentage;
    public float WinPercentage => _winPercentage;

    private void OnEnable()
    {
        _levelProgress.Updated += OnProgressUpdate;
        Won += Disable;
        Lost += Disable;
    }

    private void OnDisable()
    {
        _levelProgress.Updated -= OnProgressUpdate;
        Won -= Disable;
        Lost -= Disable;
    }

    private void OnProgressUpdate()
    {
        if (_levelProgress.LosePercentage >= _maxErrorPercentage)
        {
            Lost?.Invoke();
        }
        else if (_levelProgress.WinPercentage >= _winPercentage)
        {
            _winEffect.Play();
            Won?.Invoke();
        }
    }

    private void Disable()
    {
        enabled = false;
    }
}
