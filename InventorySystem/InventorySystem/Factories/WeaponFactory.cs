using InventorySystem.Interfaces;
using InventorySystem.Models;

namespace InventorySystem.Factories
{
    public class WeaponFactory : AbstractItemFactory
    {
        private static int _nextId = 1000;
        
        public override IItem CreateItem(string name, string description, int weight, decimal value)
        {
            // По умолчанию создаем оружие с базовым уроном
            return new Weapon(_nextId++, name, description, weight, value, 10);
        }
        
        public IItem CreateWeapon(string name, string description, int weight, decimal value, int damage)
        {
            return new Weapon(_nextId++, name, description, weight, value, damage);
        }
    }
}