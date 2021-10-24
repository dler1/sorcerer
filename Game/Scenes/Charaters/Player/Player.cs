using Godot;
using System;
using Game.Scripts.Consts;
using Game.Scripts.Helpers;
using Game.Scripts.Weapons;

public class Player : KinematicBody2D
{
	[Export] private float speed = 2;
	private Vector2 velocity;


	private IWeapon weapon;

	public override void _Ready()
	{
		weapon = new FireballWeapon();
		weapon.Prepare(this);
	}

	public override void _PhysicsProcess(float delta)
	{
		weapon.Update(this, delta);
		
		var x = InputChecker.GetAxis(InputActions.Right, InputActions.Left);
		var y = InputChecker.GetAxis(InputActions.Down, InputActions.Up);

		velocity = new Vector2(x, y).Normalized();

		MoveAndSlide(velocity * speed);

		if (Input.IsActionPressed(InputActions.Attack))
		{
			weapon.Attack(this);
		}
	}
}
