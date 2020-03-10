using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private float _interpVelocity;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private GameObject _target;
    private Vector3 _targetPos;

    // Use this for initialization
    private void Start()
    {
        _targetPos = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!_target) return;
        var position = transform.position;
        var targetPotision = _target.transform.position;
        var posNoZ = position;
        posNoZ.z = targetPotision.z;

        var targetDirection = targetPotision - posNoZ;

        _interpVelocity = targetDirection.magnitude * 5f;

        _targetPos = position + targetDirection.normalized * (_interpVelocity * Time.deltaTime);

        position = Vector3.Lerp(position, _targetPos + _offset, 0.25f);
        transform.position = position;
    }
}

// Original post with image here  >  http://unity3diy.blogspot.com/2015/02/unity-2d-camera-follow-script.html