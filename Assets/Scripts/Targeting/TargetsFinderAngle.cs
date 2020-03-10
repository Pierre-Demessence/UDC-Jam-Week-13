using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetsFinderAngle : TargetsFinder
{
    [SerializeField] [Range(0, 360)] private float _radius = 45;

    public override IEnumerable<GameObject> Find(IEnumerable<GameObject> possibleTargets)
    {
        return possibleTargets.Where(target => Vector2.Angle(transform.right, target.transform.position - transform.position) <= _radius / 2);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(_radius / 2, transform.forward) * transform.right * 10000);
        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(-(_radius / 2), transform.forward) * transform.right * 10000);
    }
}