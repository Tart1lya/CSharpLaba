using InventorySystem;
using InventorySystem.Builders;
using InventorySystem.Factories;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using InventorySystem.States;
using Xunit;

namespace InventorySystem.Tests
{
    public class InventorySystemTests
    {
        [Fact]
        public void Weapon_CanBeCreatedAndUsed()
        {
            // Arrange
            var weapon = new Weapon(1, "Sword", "Sharp sword", 5, 100, 25);
            
            // Act
            weapon.Use();
            
            // Assert
            Assert.Equal("Sword", weapon.Name);
            Assert.Equal(25, weapon.Damage);
        }
        
        [Fact]
        public void Armor_CanBeCreatedAndEquipped()
        {
            // Arrange
            var armor = new Armor(1, "Chain Mail", "Protective armor", 10, 150, 15);
            
            // Act
            armor.Equip();
            
            // Assert
            Assert.True(armor.IsEquipped);
            Assert.Equal(15, armor.Defense);
        }
        
        [Fact]
        public void Potion_CanBeUsedAndDecrementsUses()
        {
            // Arrange
            var potion = new Potion(1, "Health Potion", "Restores health", 1, 50, 20, "health", 3);
            var initialUses = potion.UsesRemaining;
            
            // Act
            potion.Use();
            
            // Assert
            Assert.Equal(initialUses - 1, potion.UsesRemaining);
        }
        
        [Fact]
        public void Inventory_AddsAndRemovesItems()
        {
            // Arrange
            var inventory = new Inventory(100);
            var weapon = new Weapon(1, "Sword", "Sharp sword", 5, 100, 25);
            
            // Act
            var addItemResult = inventory.AddItem(weapon);
            var removeItemResult = inventory.RemoveItem(1);
            
            // Assert
            Assert.True(addItemResult);
            Assert.True(removeItemResult);
            Assert.Empty(inventory.GetAllItems());
        }
        
        [Fact]
        public void Inventory_RespectsWeightLimit()
        {
            // Arrange
            var inventory = new Inventory(10); // Лимит 10 единиц веса
            var heavyItem = new Weapon(1, "Heavy Sword", "Very heavy", 15, 100, 25);
            
            // Act
            var result = inventory.AddItem(heavyItem);
            
            // Assert
            Assert.False(result);
            Assert.Empty(inventory.GetAllItems());
        }
        
        [Fact]
        public void Player_CanUseHealthPotion()
        {
            // Arrange
            var player = new Player("Hero", 100, 50);
            player.Health = 50; // Установим здоровье на 50
            var potion = new Potion(1, "Health Potion", "Restores health", 1, 50, 30, "health", 1);
            
            // Act
            player.AddItemToInventory(potion);
            player.UseItem(1);
            
            // Assert
            Assert.Equal(80, player.Health); // 50 + 30 = 80
        }
        
        [Fact]
        public void ItemState_ChangesWhenEnhanced()
        {
            // Arrange
            var weapon = new Weapon(1, "Sword", "Sharp sword", 5, 100, 25);
            var initialState = weapon.State.GetStateName();
            
            // Act
            weapon.Enhance();
            
            // Assert
            Assert.NotEqual(initialState, weapon.State.GetStateName());
            Assert.Equal("Enhanced", weapon.State.GetStateName());
        }
        
        [Fact]
        public void ItemBuilder_CreatesWeaponWithCorrectProperties()
        {
            // Arrange & Act
            var director = new ItemDirector();
            var weapon = (Weapon)director.ConstructBasicWeapon(1, "Test Sword", 30);
            
            // Assert
            Assert.Equal("Test Sword", weapon.Name);
            Assert.Equal(30, weapon.Damage);
            Assert.Equal(5, weapon.Weight); // по умолчанию
        }
        
        [Fact]
        public void ItemFactory_CreatesCorrectItemType()
        {
            // Arrange
            var factory = ItemFactoryProvider.GetFactory("weapon");
            
            // Act
            var item = factory.CreateItem("Test Weapon", "A test weapon", 5, 100);
            
            // Assert
            Assert.IsType<Weapon>(item);
            Assert.Equal("Test Weapon", item.Name);
        }
        
        [Fact]
        public void Player_CanEquipAndUnequipItem()
        {
            // Arrange
            var player = new Player("Hero");
            var weapon = new Weapon(1, "Sword", "Sharp sword", 5, 100, 25);
            player.AddItemToInventory(weapon);
            
            // Act
            player.EquipItem(1);
            var equippedCount = player.Equipment.Count;
            
            player.UnequipItem(1);
            var unequippedCount = player.Equipment.Count;
            
            // Assert
            Assert.Equal(1, equippedCount);
            Assert.Equal(0, unequippedCount);
        }
        
        [Fact]
        public void Item_CanBeEnhanced()
        {
            // Arrange
            var weapon = new Weapon(1, "Sword", "Sharp sword", 5, 100, 25);
            var initialDamage = weapon.Damage;
            var initialEnhancementLevel = weapon.EnhancementLevel;
            
            // Act
            weapon.Enhance();
            
            // Assert
            Assert.Equal(initialDamage + 5, weapon.Damage);
            Assert.Equal(initialEnhancementLevel + 1, weapon.EnhancementLevel);
        }
        
        [Fact]
        public void Item_CanBeCloned()
        {
            // Arrange
            var originalWeapon = new Weapon(1, "Sword", "Sharp sword", 5, 100, 25);
            
            // Act
            var clonedItem = originalWeapon.Clone();
            
            // Assert
            Assert.NotEqual(originalWeapon.Id, clonedItem.Id);
            Assert.Equal(originalWeapon.Name, clonedItem.Name);
            Assert.Equal(originalWeapon.Damage, ((Weapon)clonedItem).Damage);
        }
    }
}