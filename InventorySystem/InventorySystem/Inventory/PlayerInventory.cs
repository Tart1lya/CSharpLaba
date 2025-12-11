using InventorySystem.Items;
using InventorySystem.States;
using System.Collections.Generic;

namespace InventorySystem.Inventory
{
    public class PlayerInventory
    {
        private List<IItem> _items = new List<IItem>();
        private int _maxSlots = 10; // Простой лимит слотов

        public IInventoryState CurrentState { get; set; } = new NormalInventoryState();

        public void AddItem(IItem item)
        {
            if (_items.Count < _maxSlots)
            {
                _items.Add(item);
            }
        }

        public void SetFullState()
        {
            CurrentState = new FullInventoryState();
        }

        public void SetNormalState()
        {
            CurrentState = new NormalInventoryState();
        }

        public string HandleItem(IItem item)
        {
            return CurrentState.HandleAction(this, item);
        }

        public List<IItem> GetItems()
        {
            return _items;
        }
    }
}