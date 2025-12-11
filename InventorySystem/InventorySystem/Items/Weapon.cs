namespace InventorySystem.Items
{
    public class Weapon : Item
    {
        public int Damage { get; private set; }

        public Weapon(string name, int weight, int damage) : base(name, weight)
        {
            Damage = damage;
        }

        public override string Use()
        {
            return $"Used weapon '{Name}'. Deals {Damage} damage!";
        }

        public override string GetDescription()
        {
            return $"{Name} (Weapon): {Damage} damage, {Weight} kg.";
        }
    }
}