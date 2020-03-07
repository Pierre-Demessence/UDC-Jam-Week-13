using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class FindTarget : MonoBehaviour
{
    [SerializeField] private bool _keepLookingForTargets = true;
    [SerializeField] private NewTargetAcquired _onNewTargetAcquired;
    [SerializeField] private TargetAcquired _onTargetAcquired;
    private GameObject _target;
    [SerializeField] [InlineEditor] private TargetComparator _targetComparator;
    [SerializeField] [InlineEditor] private TargetsFinder _targetsFinder;

    private GameObject Target
    {
        get => _target;
        set
        {
            if (_target == value) return;
            _target = value;
            _onNewTargetAcquired.Invoke(value);
            if (!_keepLookingForTargets) enabled = false;
        }
    }

    private void Update()
    {
        Target = _targetComparator.Find(_targetsFinder.Find());
        _onTargetAcquired.Invoke(Target);
    }
}

[Serializable]
internal class TargetAcquired : UnityEvent<GameObject>
{
}

[Serializable]
internal class NewTargetAcquired : UnityEvent<GameObject>
{
}