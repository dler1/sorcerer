using System;

namespace Game.Scripts.Behaviour
{
    public enum DamageType
    {
        Fire
    }

    public class Damage
    {
        public DamageType Type { get; set; }
        public int Amount { get; set; }

        public static Damage Create(DamageType type, int amount)
        {
            return new()
            {
                Type = type,
                Amount = amount
            };
        }

        public static Damage Fire(int amount) => Create(DamageType.Fire, amount);
    }
}