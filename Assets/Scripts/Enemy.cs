using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(FindTarget))]
[RequireComponent(typeof(LookAt))]
public class Enemy : MonoBehaviour
{
    [ValueDropdown("GetListOfFindTargets", AppendNextDrawer = true)] [SerializeField] [Required]
    private FindTarget _findTarget;
    [SerializeField] [Required] private LookAt _lookAt;
    [SerializeField] [Required] private Move _move;

    public GameObject Target { get; private set; }

    [UsedImplicitly]
    private IEnumerable<FindTarget> GetListOfFindTargets() => GetComponents<FindTarget>();

    private void Update()
    {
        Target = null;
        if (_findTarget.Targets.Any()) Target = _findTarget.Targets?.First();

        if (Target != null) _lookAt.SetTarget(Target.transform.position);
        else _lookAt.Stop();
        _move.enabled = Target != null;
    }
}