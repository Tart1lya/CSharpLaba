using InventorySystem.Builders;
using InventorySystem.Factories;
using InventorySystem.Inventory;
using InventorySystem.Items;

namespace InventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventory = new PlayerInventory();

            // Используем Builder
            var sword = new ItemBuilder()
                .SetType(ItemBuilder.ItemType.Weapon)
                .SetName("Steel Sword")
                .SetWeight(5)
                .SetValue(20)
                .Build();

            var potion = new ItemBuilder()
                .SetType(ItemBuilder.ItemType.Potion)
                .SetName("Health Potion")
                .SetWeight(1)
                .SetValue(50)
                .Build();

            // Используем Factory
            var factory = new WeaponFactory();
            var axe = factory.CreateItem("Battle Axe", 8, 25);

            // Добавляем предметы в инвентарь
            Console.WriteLine(inventory.HandleItem(sword));
            Console.WriteLine(inventory.HandleItem(potion));
            Console.WriteLine(inventory.HandleItem(axe));

            // Выводим содержимое инвентаря
            Console.WriteLine("\nInventory contents:");
            foreach (var item in inventory.GetItems())
            {
                Console.WriteLine(item.GetDescription());
            }
        }
    }
}