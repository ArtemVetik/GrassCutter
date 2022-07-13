using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;

    private void Awake()
    {
        _tutorial.SetActive(true);
    }

    private void Update()
    {
        CheckOffTutorial();
    }

    private void CheckOffTutorial()
    {
        if (Input.GetMouseButtonDown(0))
            _tutorial.SetActive(false);
    }
}
