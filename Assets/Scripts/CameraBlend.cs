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

    private static class Parameters
    {
        public static readonly string PlayerFollow = nameof(PlayerFollow);
        public static readonly string ShowFullPicture = nameof(ShowFullPicture);
    }
}
