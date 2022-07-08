using UnityEngine;
using UnityEngine.UI;

public class LoseCanvas : CanvasWindow
{
    [SerializeField] private Button _reloadButton;

    private void OnEnable()
    {
        _reloadButton.onClick.AddListener(OnNextLevelButtonClicked);
    }

    private void OnDisable()
    {
        _reloadButton.onClick.RemoveListener(OnNextLevelButtonClicked);
    }

    private void OnNextLevelButtonClicked()
    {
        Singleton<LevelLoader>.Instance.ReloadCurrentLevel();
    }
}
