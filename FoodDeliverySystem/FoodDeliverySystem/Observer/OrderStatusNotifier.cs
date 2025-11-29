using FoodDeliverySystem.Models;
using FoodDeliverySystem.Interfaces;

namespace FoodDeliverySystem.Patterns.Observer;

public class OrderStatusNotifier : IOrderObserver
{
    public void OnOrderStatusChanged(Order order)
    {
        Console.WriteLine($"Заказ #{order.Id}: {order.Status}");
    }
}