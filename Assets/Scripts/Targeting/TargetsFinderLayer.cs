using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class TargetsFinderLayer : TargetsFinder
{
    [SerializeField] private LayerMask _allowedLayers;

    public override IEnumerable<GameObject> Find(IEnumerable<GameObject> possibleTargets)
    {
        return possibleTargets.Where(target => _allowedLayers == (_allowedLayers | (1 << target.layer)));
    }
}