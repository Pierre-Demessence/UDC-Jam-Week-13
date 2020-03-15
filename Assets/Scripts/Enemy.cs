using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(FindTarget))]
[RequireComponent(typeof(LookAt))]
public class Enemy : MonoBehaviour
{
    [SerializeField] [Required] private NavMeshAgent _agent;
    private int _currentPatrolPointIndex;
    [ValueDropdown(nameof(GetListOfFindTargets), AppendNextDrawer = true)] [SerializeField] [Required]
    private FindTarget _findTarget;
    [SerializeField] [Required] private LookAt _lookAt;
    [SerializeField] [Required] private Move _move;
    [SerializeField] [Required] private GameObject[] _patrolPoints;
    [SerializeField] private float _targetDistanceOffset = 1f;

    public GameObject Target { get; private set; }

    private IEnumerable<FindTarget> GetListOfFindTargets() => GetComponents<FindTarget>();

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.updatePosition = true;
        var transformPosition = transform.position;
        transformPosition.z = 0;
        transform.position = transformPosition;
    }

    private void Update()
    {
        Target = null;
        if (_findTarget.Targets != null && _findTarget.Targets.Any()) Target = _findTarget.Targets?.First();

        if (Target != null)
        {
            _lookAt.SetTarget(Target.transform.position);
            _agent.destination = Target.transform.position;
        }
        else if (_patrolPoints.Length > 0)
        {
            var currentPatrolPointTarget = _patrolPoints[_currentPatrolPointIndex];
            _agent.destination = currentPatrolPointTarget.transform.position;
            _lookAt.SetTarget(_agent.steeringTarget);

            if (Vector2.Distance(transform.position, _agent.destination) < _targetDistanceOffset)
            {
                _currentPatrolPointIndex++;
                if (_currentPatrolPointIndex >= _patrolPoints.Length) _currentPatrolPointIndex = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}