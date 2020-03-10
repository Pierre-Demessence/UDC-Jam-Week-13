using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class TargetsFinderRaycast : TargetsFinder
{
    [SerializeField] private LayerMask _obstacleLayers;

    public override IEnumerable<GameObject> Find(IEnumerable<GameObject> possibleTargets)
    {
        return possibleTargets.Where(target =>
        {
            var direction = target.transform.position - transform.position;
            var distance = Vector2.Distance(transform.position, target.transform.position);
            return Physics2D.Raycast(transform.position, direction, distance, _obstacleLayers).collider == null;
        });
    }
}