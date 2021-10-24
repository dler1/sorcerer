using System;

namespace Game.Scripts.Behaviour
{
    public interface IDamagable
    {
        public event Action<IDamagable> OnDie;

        public void Damage();


    }
}