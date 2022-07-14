using System.Collections;
using UnityEngine;

public class RobotEmotions : MonoBehaviour
{
    [SerializeField] private PictureEvents _pictureEvents;
    [SerializeField] private Texture _idle;
    [SerializeField] private Texture _smile;
    [SerializeField] private Texture _angry;
    [SerializeField] private Material _displayMat;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _pictureEvents.CuttingGrass += Smile;
        _pictureEvents.CuttingPicture += Angry;

        ChangeEmotion(_idle, _idle, 0.1f);
    }

    private void OnDisable()
    {
        _pictureEvents.CuttingGrass -= Smile;
        _pictureEvents.CuttingPicture += Angry;
    }

    private void Angry()
    {
        ChangeEmotion(_idle, _angry, 0.5f);
    }

    private void Smile()
    {
        ChangeEmotion(_idle, _smile, 0.5f);
    }

    private void ChangeEmotion(Texture normalTexture, Texture targetTexture, float delay)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(DelayEmotionChange(normalTexture, targetTexture, delay));
    }

    private IEnumerator DelayEmotionChange(Texture normalTexture, Texture targetTexture, float delay)
    {
        _displayMat.mainTexture = targetTexture;
        yield return new WaitForSeconds(delay);
        _displayMat.mainTexture = normalTexture;
    }
}
