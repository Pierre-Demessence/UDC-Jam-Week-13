using System.Collections.Generic;
using UnityEngine;

public abstract class TargetsFinder : MonoBehaviour
{
    public abstract IEnumerable<GameObject> Find(IEnumerable<GameObject> possibleTargets);
}