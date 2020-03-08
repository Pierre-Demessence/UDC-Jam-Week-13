using System.Collections.Generic;
using UnityEngine;

public abstract class TargetComparator : MonoBehaviour
{
    public abstract GameObject Find(IReadOnlyCollection<GameObject> targets);
}