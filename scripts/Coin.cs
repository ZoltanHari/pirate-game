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
        if (body is CharacterBody2D player)
        {
            Print($"Player has picked up {Name}");
            QueueFree();
        }
    }
}