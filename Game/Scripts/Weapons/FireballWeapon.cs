using System.Drawing.Printing;
using Game.Scripts.Helpers;
using Godot;

namespace Game.Scripts.Weapons
{
    public class FireballWeapon : IWeapon
    {
        private PackedScene fireball;
        private Viewport root;
        private float cooldown = .5f; 
        private float currentCooldown;

        public void Attack(Player player)
        {
            if (currentCooldown > 0) return;

            currentCooldown = cooldown;

            var instance = fireball.Instance<Fireball>();
            root.AddChild(instance);

            var direction = player.GetLocalMousePosition().Normalized();
            instance.SetDirection(direction);
            instance.Position = player.Position;
        }

        public void Prepare(Player player)
        {
            root = player.GetTree().Root;
            fireball = SceneLoader.Load<Fireball>();
            
        }

        public void Update(Player player, float delta)
        {
            currentCooldown -= delta;
        }
    }
}