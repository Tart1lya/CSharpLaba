using InventorySystem.Builders;
using InventorySystem.Interfaces;

namespace InventorySystem.Builders
{
    public class ItemDirector
    {
        public IItem ConstructBasicWeapon(int id, string name, int damage)
        {
            var builder = new WeaponBuilder();
            builder.SetId(id)
                   .SetName(name)
                   .SetDescription("A basic weapon")
                   .SetWeight(5)
                   .SetValue(100);
            
            // Используем специфичный метод для оружия
            builder.SetDamage(damage);
            
            return builder.Build();
        }
        
        public IItem ConstructBasicArmor(int id, string name, int defense)
        {
            var builder = new ArmorBuilder();
            builder.SetId(id)
                   .SetName(name)
                   .SetDescription("Basic armor")
                   .SetWeight(10)
                   .SetValue(150);
            
            // Используем специфичный метод для брони
            builder.SetDefense(defense);
            
            return builder.Build();
        }
    }
}