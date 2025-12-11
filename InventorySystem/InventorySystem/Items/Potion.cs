namespace InventorySystem.Items
{
    public class Potion : Item
    {
        public int HealthRestore { get; private set; }

        public Potion(string name, int weight, int healthRestore) : base(name, weight)
        {
            HealthRestore = healthRestore;
        }

        public override string Use()
        {
            return $"Drank potion '{Name}'. Restored {HealthRestore} HP.";
        }

        public override string GetDescription()
        {
            return $"{Name} (Potion): Restores {HealthRestore} HP, {Weight} kg.";
        }
    }
}