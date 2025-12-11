using InventorySystem.Items;

namespace InventorySystem.Factories
{
    public class WeaponFactory : ItemFactoryBase
    {
        public override IItem CreateItem(string name, int weight, int damage)
        {
            return new Weapon(name, weight, damage);
        }
    }

    public class ArmorFactory : ItemFactoryBase
    {
        public override IItem CreateItem(string name, int weight, int defense)
        {
            return new Armor(name, weight, defense);
        }
    }

    public class PotionFactory : ItemFactoryBase
    {
        public override IItem CreateItem(string name, int weight, int healthRestore)
        {
            return new Potion(name, weight, healthRestore);
        }
    }

    public class QuestItemFactory : ItemFactoryBase
    {
        public override IItem CreateItem(string name, int weight, int isImportantAsInt)
        {
            bool isImportant = isImportantAsInt > 0;
            return new QuestItem(name, weight, isImportant);
        }
    }
}