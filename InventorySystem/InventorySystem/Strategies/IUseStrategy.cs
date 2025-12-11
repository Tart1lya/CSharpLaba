using InventorySystem.Items;

namespace InventorySystem.Strategies
{
    public interface IUseStrategy
    {
        string Execute(IItem item);
    }

    public class DefaultUseStrategy : IUseStrategy
    {
        public string Execute(IItem item)
        {
            return item.Use();
        }
    }

    public class EquipUseStrategy : IUseStrategy
    {
        public string Execute(IItem item)
        {
            if (item is Armor armor)
            {
                return $"Equipping armor: {armor.Name}";
            }
            else if (item is Weapon weapon)
            {
                return $"Equipping weapon: {weapon.Name}";
            }
            else
            {
                return item.Use();
            }
        }
    }
}