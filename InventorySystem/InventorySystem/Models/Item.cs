using InventorySystem.Interfaces;
using InventorySystem.States;
using System;

namespace InventorySystem.Models
{
    public abstract class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Weight { get; set; }
        public decimal Value { get; set; }
        public IItemState State { get; set; }
        
        protected Item(int id, string name, string description, int weight, decimal value)
        {
            Id = id;
            Name = name;
            Description = description;
            Weight = weight;
            Value = value;
            State = new NormalState(this);
        }
        
        public abstract void Use();
        
        public virtual IItem Clone()
        {
            var clonedItem = (Item)this.MemberwiseClone();
            clonedItem.Id = GenerateNewId();
            return clonedItem;
        }
        
        private int GenerateNewId()
        {
            return new Random().Next(1000, 9999);
        }
        
        public virtual string GetInfo()
        {
            return $"{Name} - {Description} | Weight: {Weight} | Value: {Value}";
        }
    }
}