using FoodDeliverySystem.Models;
using FoodDeliverySystem.Patterns.Factory;
using FoodDeliverySystem.Patterns.Observer;
using FoodDeliverySystem.Interfaces;
using System.Collections.Generic;

namespace FoodDeliverySystem.Patterns.Singleton;

public sealed class OrderService
{
    private static readonly Lazy<OrderService> _instance = new(() => new OrderService());
    private readonly List<Order> _orders = new();
    private readonly List<IOrderObserver> _observers = new();

    public static OrderService Instance => _instance.Value;

    public Order CreateOrder(string type, List<OrderItem> items, string? note = null)
    {
        var order = OrderFactory.Create(type, items, note);
        _orders.Add(order);
        return order;
    }

    public void UpdateStatus(int orderId, OrderStatus status)
    {
        var order = _orders.Find(o => o.Id == orderId);
        if (order != null)
        {
            order.Status = status;
            foreach (var obs in _observers)
                obs.OnOrderStatusChanged(order);
        }
    }

    public void Subscribe(IOrderObserver observer) => _observers.Add(observer);
    public Order GetOrder(int id) => _orders.Find(o => o.Id == id);
}