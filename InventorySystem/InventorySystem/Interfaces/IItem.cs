using System;

namespace InventorySystem.Interfaces
{
    public interface IItem
    {
        int Id { get; }
        string Name { get; set; }
        string Description { get; set; }
        int Weight { get; set; }
        decimal Value { get; set; }
        IItemState State { get; set; }
        
        void Use();
        IItem Clone();
        string GetInfo();
    }
}