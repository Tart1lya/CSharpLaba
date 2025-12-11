using Xunit;
using InventorySystem.Builders;
using InventorySystem.Inventory;
using InventorySystem.Items;

namespace InventorySystem.Tests
{
    public class InventorySystemTests
    {
        [Fact]
        public void AddItem_AddsSuccessfully()
        {
            var inventory = new PlayerInventory();
            var item = new ItemBuilder()
                .SetType(ItemBuilder.ItemType.Weapon)
                .SetName("Test Sword")
                .SetWeight(3)
                .SetValue(10)
                .Build();

            inventory.AddItem(item);

            Assert.Single(inventory.GetItems());
        }

        [Fact]
        public void HandleItem_WhenFull_ReturnsError()
        {
            var inventory = new PlayerInventory();
            inventory.SetFullState();

            var item = new ItemBuilder()
                .SetType(ItemBuilder.ItemType.Potion)
                .SetName("Test Potion")
                .SetWeight(1)
                .SetValue(10)
                .Build();

            var result = inventory.HandleItem(item);

            Assert.Contains("full", result);
        }
    }
}