using InventorySystem.Items;

namespace InventorySystem.Builders
{
    public class ItemBuilder
    {
        private string _name;
        private int _weight;
        private int _damageOrDefenseOrHealth;
        private bool _isImportant;
        private ItemType _type;

        public enum ItemType
        {
            Weapon,
            Armor,
            Potion,
            QuestItem
        }

        public ItemBuilder SetType(ItemType type)
        {
            _type = type;
            return this;
        }

        public ItemBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ItemBuilder SetWeight(int weight)
        {
            _weight = weight;
            return this;
        }

        public ItemBuilder SetValue(int value)
        {
            _damageOrDefenseOrHealth = value;
            return this;
        }

        public ItemBuilder SetIsImportant(bool isImportant)
        {
            _isImportant = isImportant;
            return this;
        }

        public IItem Build()
        {
            switch (_type)
            {
                case ItemType.Weapon:
                    return new Weapon(_name, _weight, _damageOrDefenseOrHealth);
                case ItemType.Armor:
                    return new Armor(_name, _weight, _damageOrDefenseOrHealth);
                case ItemType.Potion:
                    return new Potion(_name, _weight, _damageOrDefenseOrHealth);
                case ItemType.QuestItem:
                    return new QuestItem(_name, _weight, _isImportant);
                default:
                    throw new InvalidOperationException("Unknown item type.");
            }
        }
    }
}