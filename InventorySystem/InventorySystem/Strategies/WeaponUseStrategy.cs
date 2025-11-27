using InventorySystem.Interfaces;
using InventorySystem.Models;
using System;

namespace InventorySystem.Strategies
{
    public class WeaponUseStrategy : IUseStrategy
    {
        public void Use(IItem item)
        {
            if (item is Weapon weapon)
            {
                Console.WriteLine($"Using weapon: {weapon.Name} with {weapon.Damage} damage!");
                if (weapon.IsEquipped)
                {
                    Console.WriteLine("Weapon is equipped and ready for combat!");
                }
            }
        }
    }
}