using UnityEngine;

public class ConfettiEffect : MonoBehaviour
{
    [SerializeField] private EndLevelTrigger _trigger;
    [SerializeField] private Transform[] _points;
    [SerializeField] private ParticleSystem[] _confettiTemplates;

    private void OnEnable()
    {
        _trigger.Won += OnLevelWon;
    }

    private void OnDisable()
    {
        _trigger.Won -= OnLevelWon;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OnLevelWon();
    }

    private void OnLevelWon()
    {
        foreach (var point in _points)
        {
            var template = _confettiTemplates[Random.Range(0, _confettiTemplates.Length)];
            var inst = Instantiate(template, point);
            inst.transform.localPosition = Vector3.zero;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        foreach (var point in _points)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(point.position, 1f);
        }
    }
#endif
}
