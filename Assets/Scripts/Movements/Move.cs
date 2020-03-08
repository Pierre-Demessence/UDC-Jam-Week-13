using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [InlineEditor] [SerializeField] private List<Movement> _movements;
    [SerializeField] private MoveEnd _onMoveEnd;
    [SerializeField] private MoveStart _onMoveStart;

    private Rigidbody2D _rigidbody2D;
    private bool isMoving;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = _movements.FindAll(movement => movement.enabled).Aggregate(new Vector2(), (result, movement) => result + movement.Velocity());
        if (!isMoving && _rigidbody2D.velocity != Vector2.zero)
        {
            isMoving = true;
            _onMoveStart.Invoke();
        }
        else if (isMoving && _rigidbody2D.velocity == Vector2.zero)
        {
            isMoving = false;
            _onMoveEnd.Invoke();
        }
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