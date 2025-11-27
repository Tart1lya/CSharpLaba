using InventorySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem
{
    public class Inventory
    {
        private List<IItem> _items;
        private int _maxCapacity;
        private int _currentWeight;
        
        public Inventory(int maxCapacity = 100)
        {
            _items = new List<IItem>();
            _maxCapacity = maxCapacity;
            _currentWeight = 0;
        }
        
        public bool AddItem(IItem item)
        {
            if (_currentWeight + item.Weight > _maxCapacity)
            {
                Console.WriteLine("Inventory is full! Cannot add item.");
                return false;
            }
            
            _items.Add(item);
            _currentWeight += item.Weight;
            Console.WriteLine($"Added {item.Name} to inventory. Current weight: {_currentWeight}/{_maxCapacity}");
            return true;
        }
        
        public bool RemoveItem(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                _items.Remove(item);
                _currentWeight -= item.Weight;
                Console.WriteLine($"Removed {item.Name} from inventory. Current weight: {_currentWeight}/{_maxCapacity}");
                return true;
            }
            return false;
        }
        
        public bool UseItem(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.Use();
                return true;
            }
            return false;
        }
        
        public bool EquipItem(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item is IEquipable equipableItem)
            {
                equipableItem.Equip();
                return true;
            }
            return false;
        }
        
        public bool UnequipItem(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item is IEquipable equipableItem)
            {
                equipableItem.Unequip();
                return true;
            }
            return false;
        }
        
        public bool EnhanceItem(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item is IEnhanceable enhanceableItem)
            {
                enhanceableItem.Enhance();
                return true;
            }
            return false;
        }
        
        public List<IItem> GetAllItems()
        {
            return new List<IItem>(_items);
        }
        
        public List<IItem> GetItemsByType<T>() where T : class, IItem
        {
            var result = new List<IItem>();
            foreach (var item in _items)
            {
                if (item is T specificType)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        
        public IItem? GetItemById(int itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId);
        }
        
        public int GetCurrentWeight()
        {
            return _currentWeight;
        }
        
        public int GetMaxCapacity()
        {
            return _maxCapacity;
        }
        
        public int GetItemCount()
        {
            return _items.Count;
        }
        
        public void DisplayInventory()
        {
            Console.WriteLine("\n=== INVENTORY ===");
            Console.WriteLine($"Current Weight: {_currentWeight}/{_maxCapacity}");
            Console.WriteLine($"Items Count: {_items.Count}");
            
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.GetInfo()}");
            }
            Console.WriteLine("=================\n");
        }
    }
}