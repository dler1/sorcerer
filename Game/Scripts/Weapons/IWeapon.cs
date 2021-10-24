namespace Game.Scripts.Weapons
{
    public interface IWeapon
    {
        void Attack(Player player);
        void Prepare(Player player);
        void Update(Player player, float delta);
    }
}