using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    private bool _isMoving;
    [InlineEditor] [SerializeField] private List<Movement> _movements;
    [SerializeField] private MoveEnd _onMoveEnd;
    [SerializeField] private MoveStart _onMoveStart;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void SetVelocity(Vector2 velocity)
    {
        _rigidbody2D.velocity = velocity;
        if (!_isMoving && _rigidbody2D.velocity != Vector2.zero)
        {
            _isMoving = true;
            _onMoveStart.Invoke();
        }
        else if (_isMoving && _rigidbody2D.velocity == Vector2.zero)
        {
            _isMoving = false;
            _onMoveEnd.Invoke();
        }
    }

    private void Update()
    {
        SetVelocity(_movements.FindAll(movement => movement.enabled).Aggregate(new Vector2(), (result, movement) => result + movement.Velocity()));
    }

    private void OnDisable()
    {
        SetVelocity(Vector2.zero);
    }
}

[Serializable]
internal class MoveStart : UnityEvent
{
}

[Serializable]
internal class MoveEnd : UnityEvent
{
}