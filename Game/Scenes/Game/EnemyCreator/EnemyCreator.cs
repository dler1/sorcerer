using Godot;
using System;
using System.Collections.Generic;
using System.Net;
using Game.Scripts.Behaviour;
using Game.Scripts.Extensions;
using Game.Scripts.Helpers;

public class EnemyCreator : Node2D
{
    private List<PackedScene> enemiesToSpawn;
    private int enemies = 0;
    private float waiter = 0;

    public override void _Ready()
    {
        enemiesToSpawn = new()
        {
            SceneLoader.Load<Slime>(),
            SceneLoader.Load<EnchantedHuman>()
        };
    }

    public override void _Process(float delta)
    {
        if (waiter > 0)
        {
            waiter -= delta;
        }

        if (enemies < 20)
        {
            var newEnemy = enemiesToSpawn[Randomizer.UpTo(enemiesToSpawn.Count)].Instance<Node2D>();
            AddChild(newEnemy);
            newEnemy.Position = GeneratePosition();
            waiter = .8f;
            enemies++;
            ((IDamagable) newEnemy).OnDie += EnemyDie;
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
        var node = (Node2D) damagable;
        damagable.OnDie -= EnemyDie;
        node.QueueFree();
        enemies--;
    }
}