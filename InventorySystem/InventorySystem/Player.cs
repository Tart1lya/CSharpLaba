using InventorySystem.Interfaces;
using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public Inventory Inventory { get; private set; } = new Inventory();
        public List<IItem> Equipment { get; private set; } = new List<IItem>();
        
        public Player(string name, int maxHealth = 100, int maxMana = 50)
        {
            Name = name;
            Level = 1;
            MaxHealth = maxHealth;
            Health = maxHealth;
            MaxMana = maxMana;
            Mana = maxMana;
            Inventory = new Inventory(200);
            Equipment = new List<IItem>();
        }
        
        public void AddItemToInventory(IItem item)
        {
            Inventory.AddItem(item);
        }
        
        public void UseItem(int itemId)
        {
            var item = Inventory.GetItemById(itemId);
            if (item != null)
            {
                if (item is Potion potion)
                {
                    ApplyPotionEffect(potion);
                    if (potion.UsesRemaining <= 0)
                    {
                        Inventory.RemoveItem(itemId);
                    }
                }
                else
                {
                    item.Use();
                }
            }
        }
        
        public void EquipItem(int itemId)
        {
            var item = Inventory.GetItemById(itemId);
            if (item is IEquipable equipableItem && item is IItem gameItem)
            {
                UnequipPreviousItemOfType(gameItem.GetType());
                
                equipableItem.Equip();
                Equipment.Add(gameItem);
                Inventory.RemoveItem(itemId);
                
                Console.WriteLine($"{Name} equipped {gameItem.Name}!");
            }
        }
        
        public void UnequipItem(int itemId)
        {
            var item = Equipment.FirstOrDefault(i => i.Id == itemId);
            if (item is IEquipable equipableItem && item is IItem gameItem)
            {
                equipableItem.Unequip();
                Equipment.Remove(gameItem);
                Inventory.AddItem(gameItem);
                
                Console.WriteLine($"{Name} unequipped {gameItem.Name}!");
            }
        }
        
        private void UnequipPreviousItemOfType(Type itemType)
        {
            var itemsToRemove = new List<IItem>();
            
            foreach (var equippedItem in Equipment)
            {
                if (equippedItem.GetType() == itemType && equippedItem is IEquipable equipable)
                {
                    equipable.Unequip();
                    itemsToRemove.Add(equippedItem);
                    Inventory.AddItem(equippedItem);
                }
            }
            
            foreach (var item in itemsToRemove)
            {
                Equipment.Remove(item);
            }
        }
        
        private void ApplyPotionEffect(Potion potion)
        {
            switch (potion.EffectType.ToLower())
            {
                case "health":
                    Health = Math.Min(MaxHealth, Health + potion.EffectValue);
                    Console.WriteLine($"{Name} restored {potion.EffectValue} health! Current health: {Health}/{MaxHealth}");
                    break;
                case "mana":
                    Mana = Math.Min(MaxMana, Mana + potion.EffectValue);
                    Console.WriteLine($"{Name} restored {potion.EffectValue} mana! Current mana: {Mana}/{MaxMana}");
                    break;
                default:
                    Console.WriteLine($"{Name} used {potion.Name} but effect is unknown!");
                    break;
            }
        }
        
        public void DisplayStats()
        {
            Console.WriteLine($"\n=== PLAYER STATS: {Name} ===");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            Console.WriteLine($"Mana: {Mana}/{MaxMana}");
            Console.WriteLine($"Equipment Count: {Equipment.Count}");
            
            foreach (var item in Equipment)
            {
                Console.WriteLine($"- {item.Name} (Equipped)");
            }
            Console.WriteLine("============================\n");
        }
    }
}