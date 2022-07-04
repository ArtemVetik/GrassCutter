using UnityEngine;
using Cinemachine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CinemachineVirtualCamera _endLEvelCamera;
    [SerializeField] private GameObject _endLEvelPanel;
    [SerializeField] private GameObject _progressSlider;

    private void Awake()
    {
        _progressSlider.gameObject.SetActive(true);
        _endLEvelPanel.gameObject.SetActive(false);
        _endLEvelCamera.gameObject.SetActive(false);
        _playerCamera.gameObject.SetActive(true);
    }

    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())))
        {
            _progressSlider.gameObject.SetActive(false);
            _endLEvelPanel.gameObject.SetActive(true);
            _endLEvelCamera.gameObject.SetActive(true);
            _playerCamera.gameObject.SetActive(false);
        }
    }
}
