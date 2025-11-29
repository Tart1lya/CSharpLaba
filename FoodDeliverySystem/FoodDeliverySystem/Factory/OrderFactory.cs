using FoodDeliverySystem.Models;
using System.Collections.Generic;

namespace FoodDeliverySystem.Patterns.Factory;

public static class OrderFactory
{
    private static int _nextId = 1;

    public static Order Create(string type, List<OrderItem> items, string? note = null)
    {
        Order order = type.ToLower() switch
        {
            "standard" => new StandardOrder(),
            "special" => new SpecialConditionOrder { SpecialNote = note ?? "Обычный", IsExpress = note?.Contains("express") == true },
            _ => throw new ArgumentException("Неизвестный тип")
        };

        order.Id = _nextId++;
        order.Items.AddRange(items);
        return order;
    }
}