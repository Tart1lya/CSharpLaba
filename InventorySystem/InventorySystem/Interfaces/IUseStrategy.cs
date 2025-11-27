using InventorySystem.Interfaces;

namespace InventorySystem.Interfaces
{
    public interface IUseStrategy
    {
        void Use(IItem item);
    }
}