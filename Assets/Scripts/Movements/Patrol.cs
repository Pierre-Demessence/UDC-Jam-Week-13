using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    private Vector2 _startPoint;
    [SerializeField] public Vector2 destinationPoint;
    private bool _goingToDestination;

    private Vector2 _currentDestinationPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        _startPoint = (Vector2)transform.position;
        _currentDestinationPoint = destinationPoint;
        agent.SetDestination((Vector3)destinationPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance > 1) return;
        _currentDestinationPoint =  _currentDestinationPoint == destinationPoint ? _startPoint : destinationPoint;
        agent.SetDestination((Vector3)_currentDestinationPoint);
    }
}
