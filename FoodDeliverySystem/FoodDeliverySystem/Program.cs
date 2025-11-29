using FoodDeliverySystem.Models;
using FoodDeliverySystem.Patterns.Singleton;
using FoodDeliverySystem.Patterns.Observer;
using FoodDeliverySystem.Services;
using FoodDeliverySystem.Patterns.Strategy;

namespace FoodDeliverySystem;

class Program
{
    static void Main()
    {
        var service = OrderService.Instance;
        service.Subscribe(new OrderStatusNotifier());

        var menu = MenuService.Instance;

        var orderItems = new List<OrderItem>
        {
            new(menu.GetItemByName("Кофе"), 2),
            new(menu.GetItemByName("Салат"), 1),
        };

        var order = service.CreateOrder("special", orderItems, "express");

        var calc = new CostCalculator();
        var total = calc.Calculate(order, new DeliveryStrategy());

        Console.WriteLine($"Итого: {total:C}");

        service.UpdateStatus(order.Id, OrderStatus.Delivery);
    }
}