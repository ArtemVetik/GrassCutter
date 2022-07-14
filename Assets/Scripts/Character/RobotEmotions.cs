using UnityEngine;

public class RobotEmotions : MonoBehaviour
{
    [SerializeField] private PictureEvents _pictureEvents;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material[] _emotionMaterials;

    private Material _displayMat;

    private void OnEnable()
    {
        _displayMat = _renderer.materials[2];

        ChangeEmotion(0);

        _pictureEvents.CuttingGrass += Smile;
        _pictureEvents.CuttingPicture += Angry;
    }

    private void OnDisable()
    {
        _pictureEvents.CuttingGrass -= Smile;
        _pictureEvents.CuttingPicture += Angry;
    }

    private void ChangeEmotion(int emotionNumber)
    {
        for (int i = 0; i < _emotionMaterials.Length; i++)
        {
            _displayMat = _emotionMaterials[emotionNumber];
        }
    }

    private void Smile()
    {
        ChangeEmotion(2);
    }

    private void Angry()
    {
        ChangeEmotion(1);
    }
}
