using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 3;

    private Vector3? Target { get; set; }

    public void Stop()
    {
        Target = null;
    }

    public void SetTarget(Vector3 target)
    {
        Target = target;
    }

    private void Update()
    {
        if (!Target.HasValue) return;
        var vectorToTarget = Target.Value - transform.position;
        var angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);
    }
}