using Godot;
using System;
using Game.Scripts.Consts;
using Game.Scripts.Extensions;

public class Slime : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private Player player;
    private float speed = 40;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetMeta(MetaTraits.Damagable, true);
        player = GetTree().Root.FindChildByType<Player>();
    }

    public override void _PhysicsProcess(float delta)
    {
        GD.Print(Position);
        GD.Print(player.Position);
        var direction = (Position - player.Position).Normalized();
        MoveAndSlide(speed * direction);
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}