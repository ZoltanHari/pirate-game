using Godot;
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public partial class GameManager : Node
{
    private int score = 0;

    public void AddPoint()
    {
        score++;
        GD.Print(score);    
    }
}
