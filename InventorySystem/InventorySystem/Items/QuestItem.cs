namespace InventorySystem.Items
{
    public class QuestItem : Item
    {
        public bool IsImportant { get; private set; }

        public QuestItem(string name, int weight, bool isImportant) : base(name, weight)
        {
            IsImportant = isImportant;
        }

        public override string Use()
        {
            return $"Used quest item '{Name}'. This item is {(IsImportant ? "important" : "not important")} for quests.";
        }

        public override string GetDescription()
        {
            return $"{Name} (Quest Item): {(IsImportant ? "Important" : "Not Important")}, {Weight} kg.";
        }
    }
}