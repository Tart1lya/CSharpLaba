namespace InventorySystem.Interfaces
{
    public interface IEquipable
    {
        bool IsEquipped { get; set; }
        void Equip();
        void Unequip();
    }
}