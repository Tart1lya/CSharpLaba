using InventorySystem.Items;
using InventorySystem.Inventory; 

namespace InventorySystem.States
{
    public interface IInventoryState
    {
        string HandleAction(PlayerInventory inventory, IItem item);
    }

    public class NormalInventoryState : IInventoryState
    {
        public string HandleAction(PlayerInventory inventory, IItem item)
        {
            inventory.AddItem(item);
            return $"Added {item.Name} to inventory.";
        }
    }

    public class FullInventoryState : IInventoryState
    {
        public string HandleAction(PlayerInventory inventory, IItem item)
        {
            return $"Cannot add {item.Name}. Inventory is full!";
        }
    }
}