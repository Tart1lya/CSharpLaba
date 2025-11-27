using InventorySystem.Interfaces;
using InventorySystem.Models;
using System;

namespace InventorySystem.States
{
    public class EnhancedState : IItemState
    {
        public EnhancedState(Item item)
        {
            Console.WriteLine($"{item.Name} is now in Enhanced state!");
        }
        
        public void OnEquip(Item item)
        {
            Console.WriteLine($"{item.Name} has been equipped in enhanced state. Bonus effects active!");
        }
        
        public void OnUnequip(Item item)
        {
            Console.WriteLine($"{item.Name} has been unequipped from enhanced state.");
        }
        
        public void OnEnhance(Item item)
        {
            Console.WriteLine($"{item.Name} is already enhanced, but can be further enhanced.");
        }
        
        public string GetStateName()
        {
            return "Enhanced";
        }
    }
}