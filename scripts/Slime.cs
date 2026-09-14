using Godot;
using System;

public partial class Slime : Node2D
{
    public const float Speed = 60;
    private int _direction = 1;

    [Export] private RayCast2D _rayCastLeft;
    [Export] private RayCast2D _rayCastRight;

    private AnimatedSprite2D _animatedSprite;

 public override void _Ready()
    {
        _rayCastLeft = GetNode<RayCast2D>("RayCast2DLeft");
        _rayCastRight = GetNode<RayCast2D>("RayCast2DRight");
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {

        if (_direction == 1 && _rayCastRight.IsColliding())
        {
            _direction = -1; 
            _animatedSprite.FlipH = true;
        }
        else if (_direction == -1 && _rayCastLeft.IsColliding())
        {
            _direction = 1;
            _animatedSprite.FlipH = false;
        }   

        Position += new Vector2(_direction * Speed * (float)delta, 0);
    }
}