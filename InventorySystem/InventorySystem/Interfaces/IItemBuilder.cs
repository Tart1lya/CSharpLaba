using InventorySystem.Interfaces;

namespace InventorySystem.Interfaces
{
    public interface IItemBuilder
    {
        IItemBuilder SetId(int id);
        IItemBuilder SetName(string name);
        IItemBuilder SetDescription(string description);
        IItemBuilder SetWeight(int weight);
        IItemBuilder SetValue(decimal value);
        IItem Build();
    }
}