using InventorySystem.Interfaces;
using InventorySystem.Models;
using System;

namespace InventorySystem.Strategies
{
    public class PotionUseStrategy : IUseStrategy
    {
        public void Use(IItem item)
        {
            if (item is Potion potion)
            {
                Console.WriteLine($"Using potion: {potion.Name}! Restoring {potion.EffectValue} {potion.EffectType}.");
                Console.WriteLine($"{potion.UsesRemaining} uses remaining.");
            }
        }
    }
}