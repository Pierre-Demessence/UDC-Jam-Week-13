using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Targeting
{
    internal class TargetComparatorFirstSameColor : TargetComparator
    {
        public override GameObject Find(IReadOnlyCollection<GameObject> targets) =>
            targets.Count == 0 ? null : targets.FirstOrDefault(t => t.GetComponent<Team>().Color == this.GetComponent<Team>().Color);
    }
}