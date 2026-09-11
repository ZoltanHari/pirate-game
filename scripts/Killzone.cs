using Godot;
using System;
using static Godot.GD;

public partial class Killzone : Area2D
{
	[Export] public Timer timer;
	
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		BodyEntered += OnBodyEntered;
		timer.Timeout += OnTimerTimeout;
	}

	private void OnBodyEntered(Node2D body)
	{
		Print("You died");
		Engine.TimeScale = 0.5f;
		var CollisionShape2D = body.GetNode<CollisionShape2D>("CollisionShape2D");
    	CollisionShape2D.QueueFree();
		timer.Start();
	}

	private void OnTimerTimeout()
	{
		Engine.TimeScale = 1;
		GetTree().ReloadCurrentScene();

	}
}
