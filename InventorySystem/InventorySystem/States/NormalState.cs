using InventorySystem.Interfaces;
using InventorySystem.Models;
using System;

namespace InventorySystem.States
{
    public class NormalState : IItemState
    {
        private Item _item;
        
        public NormalState(Item item)
        {
            _item = item;
        }
        
        public void OnEquip(Item item)
        {
            Console.WriteLine($"{item.Name} has been equipped in normal state.");
        }
        
        public void OnUnequip(Item item)
        {
            Console.WriteLine($"{item.Name} has been unequipped from normal state.");
        }
        
        public void OnEnhance(Item item)
        {
            Console.WriteLine($"{item.Name} is now enhanced and changes to Enhanced state.");
            item.State = new EnhancedState(item);
        }
        
        public string GetStateName()
        {
            return "Normal";
        }
    }
}