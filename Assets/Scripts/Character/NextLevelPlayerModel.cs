using UnityEngine;

public class NextLevelPlayerModel : MonoBehaviour
{
    [SerializeField] private EndLevelTrigger _endLevelTrigger;
    [SerializeField] private GameObject _modelTamplate;
    [SerializeField] private GameObject _player;

    private void OnEnable()
    {
        _endLevelTrigger.Won += ShowNewModel;
        _modelTamplate.SetActive(false);
        _player.SetActive(true);
    }

    private void OnDisable()
    {
        _endLevelTrigger.Won -= ShowNewModel;
    }

    private void ShowNewModel()
    {
        _modelTamplate.SetActive(true);
        _player.SetActive(false);
    }
}
