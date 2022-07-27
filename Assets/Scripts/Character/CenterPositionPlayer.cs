using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CenterPositionPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private EndLevelTrigger _endLevelTrigger;
    [SerializeField] private Transform _center;

    private void OnEnable()
    {
        _endLevelTrigger.Won += GoCenterMap;
    }

    private void OnDisable()
    {
        _endLevelTrigger.Won -= GoCenterMap;
    }

    private void GoCenterMap()
    {
        _player.transform.Translate(_center.position);
    }
}
