using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CinemachineVirtualCamera _endLEvelCamera;
    [SerializeField] private Canvas _winCanvas;
    [SerializeField] private Canvas _loseCanvas;
    [SerializeField] private Slider _progressSlider;

    private void Awake()
    {
        _winCanvas.enabled = false;
        _loseCanvas.enabled = false;
        _progressSlider.gameObject.SetActive(true);
        _endLEvelCamera.gameObject.SetActive(false);
        _playerCamera.gameObject.SetActive(true);
    }

    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())))
        {
            _winCanvas.enabled = true;
            _progressSlider.gameObject.SetActive(false);
            _endLEvelCamera.gameObject.SetActive(true);
            _playerCamera.gameObject.SetActive(false);
        }
    }
}
