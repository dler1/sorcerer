using Godot;
using System;
using Game.Scripts.Behaviour;
using Game.Scripts.Extensions;

public class EnchantedHuman : KinematicBody2D, IDamagable
{
    private Player player;
    private int health = 2;
    private float speed = 50;

    public override void _Ready()
    {
        player = GetTree().Root.FindChildByType<Player>();
    }

    public override void _Process(float delta)
    {
        var distance = GlobalPosition.DistanceTo(player.GlobalPosition);
        if (distance < 30)
        {
            return;
        }

        var direction = GlobalPosition.DirectionTo(player.GlobalPosition);
        MoveAndSlide(speed * direction);
    }

    public event Action<IDamagable> OnDie;

    public void DealDamage(Damage damage)
    {
        var totalAmount = damage.Type == DamageType.Fire
            ? damage.Amount
            : damage.Amount / 2;

        health -= totalAmount;

        if (health <= 0)
        {
            OnDie?.Invoke(this);
        }
    }
}