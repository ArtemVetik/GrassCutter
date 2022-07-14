using UnityEngine;

public class CuttingGrassEffect : MonoBehaviour
{
    [SerializeField] private PictureEvents _levelEvents;
    [SerializeField] private ParticleSystem _cuttingEffectTemplate;
    [SerializeField] private Transform _effectContainer;
    [SerializeField] private Animator _sawAnimator;

    private void OnEnable()
    {
        _levelEvents.CuttingGrass += OnCuttingGrass;
    }

    private void OnDisable()
    {
        _levelEvents.CuttingGrass -= OnCuttingGrass;
        _sawAnimator.speed = 1;
    }

    private void OnCuttingGrass()
    {
        Instantiate(_cuttingEffectTemplate, _effectContainer);
        _sawAnimator.speed = 2;
    }
}
