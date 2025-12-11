namespace InventorySystem.Items
{
    public interface IItem
    {
        string Name { get; }
        int Weight { get; }
        string Use();
        string GetDescription();
    }
}