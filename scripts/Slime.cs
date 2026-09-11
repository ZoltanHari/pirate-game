using Godot;
using System;

public partial class Slime : Node2D
{
    public const float Speed = 60;
    private int direction = 1;

    [Export] private RayCast2D RayCastLeft;
    [Export] private RayCast2D RayCastRight;

    private AnimatedSprite2D AnimatedSprite;

 public override void _Ready()
    {
        RayCastLeft = GetNode<RayCast2D>("RayCast2DLeft");
        RayCastRight = GetNode<RayCast2D>("RayCast2DRight");
        AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {

        if (direction == 1 && RayCastRight.IsColliding())
        {
            direction = -1; 
            AnimatedSprite.FlipH = true;
        }
        else if (direction == -1 && RayCastLeft.IsColliding())
        {
            direction = 1;
            AnimatedSprite.FlipH = false;
        }   

        Position += new Vector2(direction * Speed * (float)delta, 0);
    }
}