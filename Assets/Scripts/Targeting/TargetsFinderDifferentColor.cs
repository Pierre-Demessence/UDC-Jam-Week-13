using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class TargetsFinderDifferentColor : TargetsFinder
{
    public override IEnumerable<GameObject> Find(IEnumerable<GameObject> possibleTargets)
    {
        return possibleTargets.Where(target => target.GetComponent<Team>().Color != GetComponent<Team>().Color);
    }
}