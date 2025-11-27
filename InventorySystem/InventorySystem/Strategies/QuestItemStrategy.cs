using InventorySystem.Interfaces;
using InventorySystem.Models;
using System;

namespace InventorySystem.Strategies
{
    public class QuestItemUseStrategy : IUseStrategy
    {
        public void Use(IItem item)
        {
            if (item is QuestItem questItem)
            {
                Console.WriteLine($"Using quest item: {questItem.Name}");
                Console.WriteLine($"Related to quest: {questItem.QuestName}");
                if (questItem.IsImportant)
                {
                    Console.WriteLine("This is an important quest item!");
                }
            }
        }
    }
}