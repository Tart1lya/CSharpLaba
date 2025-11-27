using InventorySystem.Interfaces;
using InventorySystem.Models;

namespace InventorySystem.Builders
{
    public class WeaponBuilder : IItemBuilder
    {
        private int _id;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private int _weight;
        private decimal _value;
        private int _damage;
        
        public IItemBuilder SetId(int id)
        {
            _id = id;
            return this;
        }
        
        public IItemBuilder SetName(string name)
        {
            _name = name;
            return this;
        }
        
        public IItemBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public IItemBuilder SetWeight(int weight)
        {
            _weight = weight;
            return this;
        }
        
        public IItemBuilder SetValue(decimal value)
        {
            _value = value;
            return this;
        }
        
        public WeaponBuilder SetDamage(int damage)
        {
            _damage = damage;
            return this;
        }
        
        public IItem Build()
        {
            return new Weapon(_id, _name, _description, _weight, _value, _damage);
        }
    }
}