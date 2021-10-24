using Godot;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Game.Scripts.Behaviour;
using Game.Scripts.Consts;

public class Fireball : KinematicBody2D
{
	[Export] private float speed = 1;
	private Vector2 velocity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void SetDirection(Vector2 direction)
	{
		velocity = speed * direction;
		// var rot = Vector2.Up.AngleTo(direction);
		// Rotate(rot);
		LookAt(direction);
	}

	public override void _PhysicsProcess(float delta)
	{
		var collision = MoveAndCollide(velocity * delta);
		if (collision?.Collider is IDamagable damagable)
		{
			damagable.Damage();
		}

		if (collision?.Collider != null)
		{
			QueueFree();
		}
	}
}
