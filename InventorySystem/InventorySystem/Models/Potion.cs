using InventorySystem.Interfaces;
using InventorySystem.Strategies;

namespace InventorySystem.Models
{
    public class Potion : Item, IUsable
    {
        public int EffectValue { get; set; }
        public string EffectType { get; set; }
        public int UsesRemaining { get; set; }
        public IUseStrategy UseStrategy { get; set; }
        
        public Potion(int id, string name, string description, int weight, decimal value, 
                     int effectValue, string effectType, int usesRemaining) 
            : base(id, name, description, weight, value)
        {
            EffectValue = effectValue;
            EffectType = effectType;
            UsesRemaining = usesRemaining;
            UseStrategy = new PotionUseStrategy();
        }
        
        public override void Use()
        {
            if (UsesRemaining > 0)
            {
                UseStrategy.Use(this);
                UsesRemaining--;
            }
        }
        
        public override string GetInfo()
        {
            return base.GetInfo() + $" | Effect: {EffectValue} {EffectType} | Uses: {UsesRemaining}";
        }
    }
}