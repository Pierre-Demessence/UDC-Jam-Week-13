using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [InlineEditor] [SerializeField] private List<Movement> _movements;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = _movements.FindAll(movement => movement).Aggregate(new Vector2(), (result, movement) => result + movement.Velocity());
    }
}