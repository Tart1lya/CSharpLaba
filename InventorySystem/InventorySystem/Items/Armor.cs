namespace InventorySystem.Items
{
    public class Armor : Item
    {
        public int Defense { get; private set; }

        public Armor(string name, int weight, int defense) : base(name, weight)
        {
            Defense = defense;
        }

        public override string Use()
        {
            return $"Equipped armor '{Name}'. Increases defense by {Defense}.";
        }

        public override string GetDescription()
        {
            return $"{Name} (Armor): {Defense} defense, {Weight} kg.";
        }
    }
}