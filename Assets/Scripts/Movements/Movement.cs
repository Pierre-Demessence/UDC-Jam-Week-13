using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public abstract Vector2 Velocity();
}