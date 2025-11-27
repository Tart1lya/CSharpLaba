using InventorySystem.Interfaces;
using InventorySystem.Strategies;
using InventorySystem.States;

namespace InventorySystem.Models
{
    public class Armor : Item, IEquipable, IEnhanceable
    {
        public int Defense { get; set; }
        public bool IsEquipped { get; set; }
        public int EnhancementLevel { get; set; }
        public IUseStrategy UseStrategy { get; set; }
        
        public Armor(int id, string name, string description, int weight, decimal value, int defense) 
            : base(id, name, description, weight, value)
        {
            Defense = defense;
            IsEquipped = false;
            EnhancementLevel = 0;
            UseStrategy = new ArmorUseStrategy();
        }
        
        public override void Use()
        {
            UseStrategy.Use(this);
        }
        
        public void Equip()
        {
            if (!IsEquipped)
            {
                IsEquipped = true;
                State.OnEquip(this);
            }
        }
        
        public void Unequip()
        {
            if (IsEquipped)
            {
                IsEquipped = false;
                State.OnUnequip(this);
            }
        }
        
        public void Enhance()
        {
            EnhancementLevel++;
            Defense += 3; // Увеличиваем защиту при улучшении
            State.OnEnhance(this);
        }
        
        public void ApplyEnhancement(IItem enhancementItem)
        {
            if (enhancementItem is Armor enhancementArmor)
            {
                Defense += enhancementArmor.Defense;
                EnhancementLevel += enhancementArmor.EnhancementLevel;
            }
        }
        
        public override string GetInfo()
        {
            return base.GetInfo() + $" | Defense: {Defense} | Enhanced: {EnhancementLevel} | Equipped: {IsEquipped}";
        }
    }
}