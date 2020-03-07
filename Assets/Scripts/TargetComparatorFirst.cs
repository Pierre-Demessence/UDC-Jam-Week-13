using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class TargetComparatorFirst : TargetComparator
{
    public override GameObject Find(IReadOnlyCollection<GameObject> targets) => targets.Count == 0 ? null : targets.First();
}