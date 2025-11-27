using InventorySystem.Interfaces;
using InventorySystem.Strategies;

namespace InventorySystem.Models
{
    public class QuestItem : Item
    {
        public string QuestName { get; set; }
        public bool IsImportant { get; set; }
        public IUseStrategy UseStrategy { get; set; }
        
        public QuestItem(int id, string name, string description, int weight, decimal value, 
                        string questName, bool isImportant) 
            : base(id, name, description, weight, value)
        {
            QuestName = questName;
            IsImportant = isImportant;
            UseStrategy = new QuestItemUseStrategy();
        }
        
        public override void Use()
        {
            UseStrategy.Use(this);
        }
        
        public override string GetInfo()
        {
            return base.GetInfo() + $" | Quest: {QuestName} | Important: {IsImportant}";
        }
    }
}