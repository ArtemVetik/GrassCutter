using UnityEngine;
using TMPro;

public class PlayerAccuracyCalculation : MonoBehaviour
{
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private EndLevelTrigger _endLevelTrigger;
    [SerializeField] private TMP_Text _percentText;

    private string _accuracyPercent;

    private void OnEnable()
    {
        _endLevelTrigger.Won += CheckPercentAccuracy;
    }

    private void OnDisable()
    {
        _endLevelTrigger.Won -= CheckPercentAccuracy;
    }

    private void CheckPercentAccuracy()
    {
        _accuracyPercent = (1f - _levelProgress.LosePercentage).ToString("000.00") + "% Accuracy";

        _percentText.text = _accuracyPercent;
    }
}
