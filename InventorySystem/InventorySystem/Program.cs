using InventorySystem;
using InventorySystem.Builders;
using InventorySystem.Factories;
using InventorySystem.Interfaces;
using InventorySystem.Models;

namespace InventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Inventory System Demo ===\n");

            // Создаем игрока
            var player = new Player("Hero");
            
            // Создаем директора для построения предметов
            var director = new ItemDirector();
            
            // Создаем предметы через строителя
            var sword = director.ConstructBasicWeapon(1, "Steel Sword", 25);
            var armor = director.ConstructBasicArmor(2, "Chain Mail", 15);
            var healthPotion = new Potion(3, "Health Potion", "Restores health", 1, 50, 30, "health", 3);
            var questItem = new QuestItem(4, "Ancient Key", "Opens the secret door", 2, 0, "Secret Door Quest", true);
            
            // Добавляем предметы в инвентарь
            player.AddItemToInventory(sword);
            player.AddItemToInventory(armor);
            player.AddItemToInventory(healthPotion);
            player.AddItemToInventory(questItem);
            
            // Показываем инвентарь
            player.Inventory.DisplayInventory();
            
            // Используем предметы
            Console.WriteLine("Using health potion...");
            player.UseItem(3);
            
            // Экипируем оружие
            Console.WriteLine("Equipping sword...");
            player.EquipItem(1);
            
            // Показываем статистику игрока
            player.DisplayStats();
            
            // Показываем инвентарь снова
            player.Inventory.DisplayInventory();
            
            Console.WriteLine("Demo completed!");
        }
    }
}