using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RobotEmotions : MonoBehaviour
{
    [SerializeField] private PictureEvents _pictureEvents;
    [SerializeField] private Texture _idle;
    [SerializeField] private Texture _smile;
    [SerializeField] private Texture _angry;
    [SerializeField] private Material _displayMat;

    private MeshRenderer _renderer;

    private void OnEnable()
    {
        _pictureEvents.CuttingGrass += Smile;
        _pictureEvents.CuttingPicture += Angry;
    }

    private void OnDisable()
    {
        _pictureEvents.CuttingGrass -= Smile;
        _pictureEvents.CuttingPicture += Angry;
    }

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();

        ChangeEmotion(_idle);
    }

    private void Angry()
    {
        ChangeEmotion(_angry);
    }

    private void Smile()
    {
        ChangeEmotion(_smile);
    }

    private void ChangeEmotion(Texture texture)
    {
        _displayMat.mainTexture = texture;
    }
}
