using InventorySystem.Interfaces;
using InventorySystem.Models;
using System;

namespace InventorySystem.States
{
    public class BrokenState : IItemState
    {
        public BrokenState(Item item)
        {
            Console.WriteLine($"{item.Name} is broken and cannot be used effectively!");
        }
        
        public void OnEquip(Item item)
        {
            Console.WriteLine($"{item.Name} is broken and cannot be equipped properly!");
        }
        
        public void OnUnequip(Item item)
        {
            Console.WriteLine($"{item.Name} has been unequipped but remains broken.");
        }
        
        public void OnEnhance(Item item)
        {
            Console.WriteLine($"{item.Name} is broken but enhancement might repair it.");
            item.State = new NormalState(item);
        }
        
        public string GetStateName()
        {
            return "Broken";
        }
    }
}