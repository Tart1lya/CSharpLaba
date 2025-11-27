using InventorySystem.Interfaces;

namespace InventorySystem.Factories
{
    public abstract class AbstractItemFactory : IItemFactory
    {
        public abstract IItem CreateItem(string name, string description, int weight, decimal value);
    }
}