using UnityEngine;
using UnityEngine.UI;

public class ProgressSliders : MonoBehaviour
{
    [SerializeField] private LevelProgress _progress;
    [SerializeField] private EndLevelTrigger _endTrigger;
    [SerializeField] private Slider _winSlider;

    private void OnEnable()
    {
        _progress.Updated += OnProgressUpdate;
    }

    private void OnDisable()
    {
        _progress.Updated -= OnProgressUpdate;
    }

    private void Start()
    {
        _winSlider.maxValue = _endTrigger.WinPercentage;
        _winSlider.value = 0;
    }

    private void OnProgressUpdate()
    {
        _winSlider.value = _progress.WinPercentage;
    }
}
