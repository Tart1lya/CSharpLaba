using FoodDeliverySystem.Models;

namespace FoodDeliverySystem.Interfaces;

public interface IOrderObserver
{
    void OnOrderStatusChanged(Order order);
}