using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Events;

public class FindTarget : MonoBehaviour
{
    [Tooltip("If false will find one target and never change, even if it's lost.")] [SerializeField]
    private bool _keepLookingForTargets = true;
    [SerializeField] private TargetAcquired _onTargetAcquired;
    [SerializeField] private TargetLost _onTargetLost;
    [SerializeField] private TargetSeen _onTargetSeen;
    private GameObject _target;
    [SerializeField] [InlineEditor] private TargetComparator[] _targetComparators;
    private IEnumerable<GameObject> _targets;
    [SerializeField] [InlineEditor] private TargetsFinder[] _targetsFinders;

    private GameObject Target
    {
        get => _target;
        set
        {
            if (value == null)
            {
                if (_target != null) _onTargetLost.Invoke();
                _target = null;
                return;
            }

            _onTargetSeen.Invoke(Target);
            if (value != _target)
            {
                if (!_keepLookingForTargets) return;
                _target = value;
                _onTargetAcquired.Invoke(value);
            }
        }
    }

    private void Update()
    {
        var possibleTargets = FindObjectsOfType<Transform>().Select(t => t.gameObject);
        _targets = _targetsFinders.Aggregate(possibleTargets, (current, targetsFinder) => targetsFinder.Find(current));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        _targets?.ForEach(target => Gizmos.DrawLine(transform.position, target.transform.position));
    }
}

[Serializable]
internal class TargetAcquired : UnityEvent<GameObject>
{
}

[Serializable]
internal class TargetSeen : UnityEvent<GameObject>
{
}

[Serializable]
internal class TargetLost : UnityEvent
{
}