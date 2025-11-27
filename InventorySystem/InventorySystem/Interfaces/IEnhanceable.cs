namespace InventorySystem.Interfaces
{
    public interface IEnhanceable
    {
        int EnhancementLevel { get; set; }
        void Enhance();
        void ApplyEnhancement(IItem enhancementItem);
    }
}