using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : CanvasWindow
{
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Image _snapshot;
    [SerializeField] private Animator _animator;
    [SerializeField] private SnapshotProvider _snapshotProvider;

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(OnNextLevelButtonClicked);
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(OnNextLevelButtonClicked);
    }

    public override void OnShown()
    {
        _animator.SetTrigger("Show");
        StartCoroutine(PlaySnapshotAnimation(2f));
    }

    private IEnumerator PlaySnapshotAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        _snapshot.sprite = _snapshotProvider.MakeSnapshot().ToSprite();
        _animator.SetTrigger("Snapshot");
    }

    private void OnNextLevelButtonClicked()
    {
        Singleton<LevelLoader>.Instance.LoadNextLevel();
    }
}
