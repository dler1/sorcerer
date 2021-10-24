using Godot;
using System;
using System.Collections.Generic;
using System.Net;
using Game.Scripts.Behaviour;
using Game.Scripts.Extensions;
using Game.Scripts.Helpers;

public class EnemyCreator : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private PackedScene slime;

    private int enemies = 0;
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

        if (enemies < 1)
        {
            var newEnemy = slime.Instance<Slime>();
            AddChild(newEnemy);
            newEnemy.Position =GeneratePosition();
            waiter = 1;
            enemies++;
            newEnemy.OnDie += EnemyDie;
        }
    }

    private Vector2 GeneratePosition()
    {
        var room = GetTree().Root.FindChildByType<Room>();
        var player = GetTree().Root.FindChildByType<Player>();
        while (true)
        {
            var index = Randomizer.UpTo(room.Spawns.Count);
            var position = room.Spawns[index];

            var distance = position.DistanceTo(player.Position);
            if (distance > 2)
            {
                return position;
            }
        }
    }

    private void EnemyDie(IDamagable damagable)
    {
        var node = (Node2D)damagable;
        damagable.OnDie -= EnemyDie;
        node.QueueFree();
        enemies--;

    }
}