using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class LevelAnalytics : MonoBehaviour
{
    [SerializeField] private EndLevelTrigger _endLevelTrigger;
    [SerializeField] private LoseCanvas _loseCanvas;
    [SerializeField] private Tutorial _tutorial;

    private Analytics _analytics;
    private int _levelNumber;
    private float _startTime;

    private void Awake()
    {
        _analytics = Singleton<Analytics>.Instance;
        _levelNumber = Singleton<LevelLoader>.Instance.LevelIndex + 1;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        bool dirty = _endLevelTrigger == null || _loseCanvas == null || _tutorial == null;

        _endLevelTrigger ??= FindObjectOfType<EndLevelTrigger>();
        _loseCanvas ??= FindObjectOfType<LoseCanvas>();
        _tutorial ??= FindObjectOfType<Tutorial>();

        if (dirty)
            EditorUtility.SetDirty(gameObject);
    }
#endif

    private void OnEnable()
    {
        _tutorial.Completed += OnTutorCompleted;
        _endLevelTrigger.Won += OnLevelCompleted;
        _endLevelTrigger.Lost += OnLevelFailed;
        _loseCanvas.Restarted += OnReloading;
    }

    private void OnDisable()
    {
        _tutorial.Completed -= OnTutorCompleted;
        _endLevelTrigger.Won -= OnLevelCompleted;
        _endLevelTrigger.Lost -= OnLevelFailed;
        _loseCanvas.Restarted -= OnReloading;
    }

    private void Start()
    {
        _analytics.FireEvent("main_menu");
    }

    private void OnTutorCompleted()
    {
        var parameters = new Dictionary<string, object>() { { "level", _levelNumber }, };
        _analytics.FireEvent("level_start", parameters);
        _analytics.ForceSendEventBuffer();

        _startTime = Time.realtimeSinceStartup;
    }

    private void OnLevelFailed()
    {
        var timeSpent = Time.realtimeSinceStartup - _startTime;
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
            { "time_spent", (int)timeSpent },
        };

        _analytics.FireEvent("level_fail", parameters);
    }

    private void OnLevelCompleted()
    {
        var timeSpent = Time.realtimeSinceStartup - _startTime;
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
            { "time_spent", (int)timeSpent },
        };

        _analytics.FireEvent("level_complete", parameters);
        _analytics.ForceSendEventBuffer();
    }

    private void OnReloading()
    {
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
        };

        _analytics.FireEvent("level_restart", parameters);
    }
}
