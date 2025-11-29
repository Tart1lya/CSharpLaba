using FoodDeliverySystem.Models;

namespace FoodDeliverySystem.Interfaces;

public interface IOrderService
{
    Order CreateOrder(string type, List<MenuItem> items, string? note = null);
    void UpdateStatus(int orderId, OrderStatus status);
    Order GetOrder(int orderId);
}