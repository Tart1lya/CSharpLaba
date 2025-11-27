using InventorySystem.Interfaces;
using InventorySystem.Models;
using System;

namespace InventorySystem.Strategies
{
    public class ArmorUseStrategy : IUseStrategy
    {
        public void Use(IItem item)
        {
            if (item is Armor armor)
            {
                Console.WriteLine($"Using armor: {armor.Name} with {armor.Defense} defense!");
                if (armor.IsEquipped)
                {
                    Console.WriteLine("Armor is equipped and providing protection!");
                }
            }
        }
    }
}