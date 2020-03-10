using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetsFinderCircle : TargetsFinder
{
    [SerializeField] [Min(0)] private float _radius = 3;

    public override IEnumerable<GameObject> Find(IEnumerable<GameObject> possibleTargets)
    {
        return possibleTargets.Where(target => Vector2.Distance(transform.position, target.transform.position) <= _radius);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}