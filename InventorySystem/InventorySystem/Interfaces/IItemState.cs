using InventorySystem.Models;

namespace InventorySystem.Interfaces
{
    public interface IItemState
    {
        void OnEquip(Item item);
        void OnUnequip(Item item);
        void OnEnhance(Item item);
        string GetStateName();
    }
}