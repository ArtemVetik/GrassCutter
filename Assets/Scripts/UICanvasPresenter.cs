using UnityEngine;

public class UICanvasPresenter : MonoBehaviour
{
    [SerializeField] private EndLevelTrigger _endTrigger;
    [SerializeField] private CameraBlend _cameraBlend;
    [SerializeField] private WinCanvas _winCanvas;
    [SerializeField] private LoseCanvas _loseCanvas;
    [SerializeField] private GameCanvas _gameCanvas;

    private void OnEnable()
    {
        _endTrigger.Won += OnWin;
        _endTrigger.Lost += OnLose;
    }

    private void OnDisable()
    {
        _endTrigger.Won -= OnWin;
        _endTrigger.Lost -= OnLose;
    }

    private void OnWin()
    {
        _gameCanvas.Hide();
        _winCanvas.Show();
        _cameraBlend.ShowPicture();
    }

    private void OnLose()
    {
        _gameCanvas.Hide();
        _loseCanvas.Show();
        _cameraBlend.ShowPicture();
    }
}
