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

    private GameObject _target;

    [UsedImplicitly]
    private IEnumerable<FindTarget> GetListOfFindTargets() => GetComponents<FindTarget>();

    private void Update()
    {
        _target = null;
        if (_findTarget.Targets.Any()) _target = _findTarget.Targets?.First();

        if (_target != null) _lookAt.SetTarget(_target.transform.position);
        _move.enabled = _target != null;
    }
}