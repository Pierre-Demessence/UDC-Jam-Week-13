using UnityEngine;

public class MovementForward : Movement
{
    public override Vector2 Velocity() => transform.right * Speed;
}