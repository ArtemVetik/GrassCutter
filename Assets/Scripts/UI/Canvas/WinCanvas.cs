using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : CanvasWindow
{
    [SerializeField] private Button _nextLevel;

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(OnNextLevelButtonClicked);
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(OnNextLevelButtonClicked);
    }

    private void OnNextLevelButtonClicked()
    {
        Singleton<LevelLoader>.Instance.LoadNextLevel();
    }
}
