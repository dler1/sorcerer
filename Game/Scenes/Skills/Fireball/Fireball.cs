using Godot;
using Game.Scripts.Behaviour;

public class Fireball : KinematicBody2D
{
    [Export] private float speed = 1;
    private Vector2 velocity;

    public override void _Ready()
    {
    }

    public void SetDirection(Vector2 direction)
    {
        velocity = speed * direction;
        LookAt(direction);
    }

    public override void _PhysicsProcess(float delta)
    {
        var collision = MoveAndCollide(velocity * delta);
        if (collision?.Collider is IDamagable target)
        {
            target.DealDamage(Damage.Fire(1));
        }

        if (collision?.Collider != null)
        {
            QueueFree();
        }
    }
}