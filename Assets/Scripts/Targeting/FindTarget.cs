using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    [ValueDropdown("GetListOfTargetsFinders", AppendNextDrawer = true, IsUniqueList = true)] [SerializeField] [InlineEditor]
    private TargetsFinder[] _targetsFinders;
    public IEnumerable<GameObject> Targets { get; private set; }

    [UsedImplicitly]
    private IEnumerable<TargetsFinder> GetListOfTargetsFinders() => GetComponents<TargetsFinder>();

    private void Update()
    {
        var possibleTargets = FindObjectsOfType<Transform>().Select(t => t.gameObject);
        Targets = _targetsFinders.Aggregate(possibleTargets, (current, targetsFinder) => targetsFinder.Find(current));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Targets?.ForEach(target => Gizmos.DrawLine(transform.position, target.transform.position));
    }
}