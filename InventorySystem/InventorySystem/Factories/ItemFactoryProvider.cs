using InventorySystem.Interfaces;

namespace InventorySystem.Factories
{
    public class ItemFactoryProvider
    {
        public static IItemFactory GetFactory(string itemType)
        {
            return itemType.ToLower() switch
            {
                "weapon" => new WeaponFactory(),
                "armor" => new ArmorFactory(),
                _ => new WeaponFactory() // по умолчанию оружие
            };
        }
    }
}