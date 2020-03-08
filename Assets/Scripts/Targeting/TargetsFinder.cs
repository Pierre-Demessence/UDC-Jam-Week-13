using System.Collections.Generic;
using UnityEngine;

public abstract class TargetsFinder : MonoBehaviour
{
    public abstract List<GameObject> Find();
}