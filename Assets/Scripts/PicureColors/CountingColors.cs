using UnityEngine;

public class CountingColors : MonoBehaviour
{
    [SerializeField] BlackWhiteColorsPresenter _colorsPresenter;
    [SerializeField] private EndLevel _endLevel;

    private void Update()
    {
        if ((float)_colorsPresenter.Colors.BlackColors / _colorsPresenter.Colors.StartBlackColors < 0.05f)
        {
            _endLevel.Win();
            Debug.Log("win");
        }
        else if ((float)_colorsPresenter.Colors.WhiteColors / _colorsPresenter.Colors.StartWhiteColors < 0.9f)
        {
            _endLevel.Lose();
            Debug.Log("Lose");
        }
    }
}
