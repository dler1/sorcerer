using Godot;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
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
	}

	public override void _PhysicsProcess(float delta)
	{
		var collision = MoveAndCollide(velocity * delta);
		if (collision?.Collider is Node2D nd && nd.HasMeta(MetaTraits.Damagable))
		{
			GD.Print("DMG!");
			nd.QueueFree();
		}

		if (collision?.Collider != null)
		{
			QueueFree();
		}
	}
}
