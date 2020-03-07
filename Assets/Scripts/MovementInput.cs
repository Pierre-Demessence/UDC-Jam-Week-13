using UnityEngine;

public class MovementInput : Movement
{
    public override Vector2 Velocity()
    {
        var movX = Input.GetAxis("Horizontal") * Speed;
        var movY = Input.GetAxis("Vertical") * Speed;
        return new Vector2(movX, movY);
    }
}