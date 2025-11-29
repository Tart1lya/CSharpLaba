using FoodDeliverySystem.Models;
using System.Collections.Generic;

namespace FoodDeliverySystem.Services;

public class MenuService
{
    private static readonly Lazy<MenuService> _instance = new(() => new MenuService());
    public static MenuService Instance => _instance.Value;

    public List<MenuItem> Menu { get; } = new()
    {
        new() { Name = "Бургер", Price = 10 },
        new() { Name = "Пицца", Price = 15 },
        new() { Name = "Кофе", Price = 3 },
        new() { Name = "Салат", Price = 7 }
    };

    public MenuItem GetItemByName(string name)
    {
        return Menu.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}