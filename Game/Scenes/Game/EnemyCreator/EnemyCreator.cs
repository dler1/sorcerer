using Godot;
using System;
using System.Collections.Generic;
using Game.Scripts.Extensions;
using Game.Scripts.Helpers;

public class EnemyCreator : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private PackedScene slime;

    private List<Slime> enemies = new();
    private float waiter = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        slime = SceneLoader.Load<Slime>();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (waiter > 0)
        {
            waiter -= delta;
        }

        if (enemies.Count < 1)
        {
            var newEnemy = slime.Instance<Slime>();
            AddChild(newEnemy);
            Position = GetTree().Root.FindChildByType<Player>().Position + new Vector2(32, 64);
            enemies.Add(newEnemy);
            waiter = 1;
        }
    }
}