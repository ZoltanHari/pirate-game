 using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;

	private AnimatedSprite2D _animatedSprite;

public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }


	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		var direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		if (IsOnFloor()) 
		{
			if (direction == Vector2.Zero)
			{
				_animatedSprite.Play("idle");
			}
			else
			{
				_animatedSprite.Play("run");
			}
		}

		else
		{
			_animatedSprite.Play("jump");
		}

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			_animatedSprite.FlipH = direction.X < 0;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();

	}
}
