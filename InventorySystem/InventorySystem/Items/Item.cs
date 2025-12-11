using InventorySystem.Items;

namespace InventorySystem.Items
{
    public abstract class Item : IItem
    {
        public string Name { get; protected set; }
        public int Weight { get; protected set; }

        public Item(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract string Use();
        public abstract string GetDescription();
    }
}