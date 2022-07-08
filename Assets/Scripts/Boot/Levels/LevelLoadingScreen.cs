using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider _processSlider;

    private Coroutine _loadOperation;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName, Action onLoaded = null)
    {
        if (_loadOperation != null)
            throw new InvalidOperationException("Another scene is already loading");

        _loadOperation = StartCoroutine(LoadSceneOperation(sceneName, onLoaded));
    }

    private IEnumerator LoadSceneOperation(string sceneName, Action onLoaded)
    {
        var operation = SceneManager.LoadSceneAsync(sceneName);

        while (operation.isDone == false)
        {
            yield return null;
            _processSlider.value = operation.progress;
        }

        onLoaded?.Invoke();
    }
}
