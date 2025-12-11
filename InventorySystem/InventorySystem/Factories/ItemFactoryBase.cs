using InventorySystem.Items;

namespace InventorySystem.Factories
{
    public abstract class ItemFactoryBase
    {
        public abstract IItem CreateItem(string name, int weight, int value);
    }
}