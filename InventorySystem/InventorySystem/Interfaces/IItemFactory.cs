namespace InventorySystem.Interfaces
{
    public interface IItemFactory
    {
        IItem CreateItem(string name, string description, int weight, decimal value);
    }
}