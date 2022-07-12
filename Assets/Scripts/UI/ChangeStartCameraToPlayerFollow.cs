using UnityEngine;

public class ChangeStartCameraToPlayerFollow : MonoBehaviour
{
    [SerializeField] private CameraBlend _cameraBlend;

    private bool _isStartCamera;

    private void Start()
    {
        _isStartCamera = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            if(_isStartCamera == true)
            {
                _isStartCamera = false;
                _cameraBlend.StartCamera();
            }
            else if(_isStartCamera == false)
            {
                _isStartCamera = true;
                _cameraBlend.PlayerFollow();
            }
        }
    }
}
