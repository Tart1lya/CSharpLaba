using InventorySystem.Interfaces;
using InventorySystem.Strategies;
using InventorySystem.States;

namespace InventorySystem.Models
{
    public class Weapon : Item, IEquipable, IEnhanceable
    {
        public int Damage { get; set; }
        public bool IsEquipped { get; set; }
        public int EnhancementLevel { get; set; }
        public IUseStrategy UseStrategy { get; set; }
        
        public Weapon(int id, string name, string description, int weight, decimal value, int damage) 
            : base(id, name, description, weight, value)
        {
            Damage = damage;
            IsEquipped = false;
            EnhancementLevel = 0;
            UseStrategy = new WeaponUseStrategy();
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
            Damage += 5; // Увеличиваем урон при улучшении
            State.OnEnhance(this);
        }
        
        public void ApplyEnhancement(IItem enhancementItem)
        {
            if (enhancementItem is Weapon enhancementWeapon)
            {
                Damage += enhancementWeapon.Damage;
                EnhancementLevel += enhancementWeapon.EnhancementLevel;
            }
        }
        
        public override string GetInfo()
        {
            return base.GetInfo() + $" | Damage: {Damage} | Enhanced: {EnhancementLevel} | Equipped: {IsEquipped}";
        }
    }
}