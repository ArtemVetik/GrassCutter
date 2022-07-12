using UnityEngine;

public class CameraBlend : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayerFollow()
    {
        _animator.SetTrigger(Parameters.PlayerFollow);
    }

    public void ShowPicture()
    {
        _animator.SetTrigger(Parameters.ShowFullPicture);
    }

    public void StartCamera()
    {
        _animator.SetTrigger(Parameters.StartCamera);
    }

    public void DefaultTrigger()
    {
        _animator.SetTrigger(Parameters.Default);
    }

    private static class Parameters
    {
        public static readonly string PlayerFollow = nameof(PlayerFollow);
        public static readonly string ShowFullPicture = nameof(ShowFullPicture);
        public static readonly string StartCamera = nameof(StartCamera);
        public static readonly string Default = nameof(Default);
    }
}
