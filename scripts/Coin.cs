using Godot;
using System;
using static Godot.GD;

public partial class Coin : Area2D
{
    private GameManager _gameManager;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
        _gameManager = GetNode<GameManager>("%GameManager");
    }

    private void OnBodyEntered(Node2D body)
    {
        {
            _gameManager.AddPoint();
            QueueFree();
        }
    }
}