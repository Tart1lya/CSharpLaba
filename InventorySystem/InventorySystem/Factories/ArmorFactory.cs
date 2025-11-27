using InventorySystem.Interfaces;
using InventorySystem.Models;

namespace InventorySystem.Factories
{
    public class ArmorFactory : AbstractItemFactory
    {
        private static int _nextId = 2000;
        
        public override IItem CreateItem(string name, string description, int weight, decimal value)
        {
            // По умолчанию создаем броню с базовой защитой
            return new Armor(_nextId++, name, description, weight, value, 5);
        }
        
        public IItem CreateArmor(string name, string description, int weight, decimal value, int defense)
        {
            return new Armor(_nextId++, name, description, weight, value, defense);
        }
    }
}