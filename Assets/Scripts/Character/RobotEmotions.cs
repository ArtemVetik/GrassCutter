using System.Collections;
using UnityEngine;

public class RobotEmotions : MonoBehaviour
{
    [SerializeField] private PictureEvents _pictureEvents;
    [SerializeField] private Texture _idle;
    [SerializeField] private Texture _smile;
    [SerializeField] private Texture _angry;
    [SerializeField] private Material _displayMat;

    private Coroutine _angryCoroutine;
    private Coroutine _smileCoroutine;

    private void OnEnable()
    {
        _pictureEvents.CuttingGrass += Smile;
        _pictureEvents.CuttingPicture += Angry;

        ChangeEmotion(_idle, _idle, 0.1f);
    }

    private void OnDisable()
    {
        _pictureEvents.CuttingGrass -= Smile;
        _pictureEvents.CuttingPicture -= Angry;
    }

    private void Angry()
    {
        if (_angryCoroutine != null)
            StopCoroutine(_angryCoroutine);
        if (_smileCoroutine != null)
            StopCoroutine(_smileCoroutine);

        _angryCoroutine = ChangeEmotion(_idle, _angry, 0.2f);
    }

    private void Smile()
    {
        if (_angryCoroutine != null)
            return;
        if (_smileCoroutine != null)
            StopCoroutine(_smileCoroutine);

        _smileCoroutine = ChangeEmotion(_idle, _smile, 0.2f);
    }

    private Coroutine ChangeEmotion(Texture normalTexture, Texture targetTexture, float delay)
    {
        return StartCoroutine(DelayEmotionChange(normalTexture, targetTexture, delay));
    }

    private IEnumerator DelayEmotionChange(Texture normalTexture, Texture targetTexture, float delay)
    {
        _displayMat.mainTexture = targetTexture;
        yield return new WaitForSeconds(delay);
        _displayMat.mainTexture = normalTexture;
    }
}
