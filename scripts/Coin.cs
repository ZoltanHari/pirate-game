using Godot;
using System;
using static Godot.GD;

public partial class Coin : Area2D
{
    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        {
            Print("+1 Coin");
            QueueFree();
        }
    }
}