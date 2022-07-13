using UnityEngine;
using System.Collections.Generic;

public class LevelAnalytics : MonoBehaviour
{
    [SerializeField] private EndLevelTrigger _endLevelTrigger;
    [SerializeField] private LoseCanvas _loseCanvas;

    private Analytics _analytics;
    private int _levelNumber;
    private float _startTime;

    private void Awake()
    {
        _analytics = Singleton<Analytics>.Instance;
        _levelNumber = Singleton<LevelLoader>.Instance.LevelIndex + 1;
    }

    private void OnEnable()
    {
        _endLevelTrigger.Won += OnLevelCompleted;
        _endLevelTrigger.Lost += OnLevelFailed;
        _loseCanvas.Restarted += OnReloading;
    }

    private void OnDisable()
    {
        _endLevelTrigger.Won -= OnLevelCompleted;
        _endLevelTrigger.Lost -= OnLevelFailed;
        _loseCanvas.Restarted -= OnReloading;
    }

    private void Start()
    {
        _analytics.FireEvent("main_menu");
        OnTutorCompleted();
    }

    private void OnTutorCompleted()
    {
        var parameters = new Dictionary<string, object>() { { "level", _levelNumber }, };
        _analytics.FireEvent("level_start", parameters);

        _startTime = Time.realtimeSinceStartup;
    }

    private void OnLevelFailed()
    {
        var timeSpent = Time.realtimeSinceStartup - _startTime;
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
            { "time_spent", (int)timeSpent },
        };

        _analytics.FireEvent("fail", parameters);
    }

    private void OnLevelCompleted()
    {
        var timeSpent = Time.realtimeSinceStartup - _startTime;
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
            { "time_spent", (int)timeSpent },
        };

        _analytics.FireEvent("level_complete", parameters);
    }

    private void OnReloading()
    {
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
        };

        _analytics.FireEvent("restart", parameters);
    }
}
