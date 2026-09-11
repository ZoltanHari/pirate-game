using Godot;
using System;

public partial class Slime : Node2D
{
    public const float Speed = 60;
    private int direction = 1;

    [Export] private RayCast2D _rayCastLeft;
    [Export] private RayCast2D _rayCastRight;

    private AnimatedSprite2D AnimatedSprite2D;

 public override void _Ready()
    {
        _rayCastLeft = GetNode<RayCast2D>("RayCast2DLeft");
        _rayCastRight = GetNode<RayCast2D>("RayCast2DRight");
        AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        AnimatedSprite2D.FlipH = direction < 0;

        if (direction == 1 && _rayCastRight.IsColliding())
        {
            direction = -1; 
        }
        else if (direction == -1 && _rayCastLeft.IsColliding())
        {
            direction = 1;
              
        }

        Position += new Vector2(direction * Speed * (float)delta, 0);
    }
}