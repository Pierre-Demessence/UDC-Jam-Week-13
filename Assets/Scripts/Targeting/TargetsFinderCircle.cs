using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetsFinderCircle : TargetsFinder
{
    private readonly Collider2D[] _availableTargets = new Collider2D[10];
    [SerializeField] private float _radius = 3;
    [SerializeField] private LayerMask _targetLayer;

    public override List<GameObject> Find()
    {
        Array.Clear(_availableTargets, 0, 10);
        Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _availableTargets, _targetLayer);
        return _availableTargets.ToList().FindAll(c => c).ConvertAll(input => input.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    /*
private void OnDrawGizmosSelected()
    {
        float totalFOV = 70.0f;
        float rayRange = 10.0f;
        float halfFOV = totalFOV / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis( -halfFOV, Vector3.up );
        Quaternion rightRayRotation = Quaternion.AngleAxis( halfFOV, Vector3.up );
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay( transform.position, leftRayDirection * rayRange );
        Gizmos.DrawRay( transform.position, rightRayDirection * rayRange );
    }
*/
}