using Godot;
using System;
using Game.Scripts.Behaviour;
using Game.Scripts.Consts;
using Game.Scripts.Extensions;

public class Slime : KinematicBody2D, IDamagable
{
    private Player player;
    private float speed = 40;
    private int health = 1;
    public event Action<IDamagable> OnDie;

    public void DealDamage(Damage damage)
    {
        health -= damage.Amount;
        if (health <= 0) OnDie?.Invoke(this);
    }

    public override void _Ready()
    {
        SetMeta(MetaTraits.Damagable, true);
        player = GetTree().Root.FindChildByType<Player>();
    }

    public override void _PhysicsProcess(float delta)
    {
        var direction = GlobalPosition.DirectionTo(player.GlobalPosition);
        MoveAndSlide(speed * direction);
    }
}