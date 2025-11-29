using FoodDeliverySystem.Models;

namespace FoodDeliverySystem.Interfaces;

public interface IPricingStrategy
{
    decimal CalculateFinalPrice(decimal basePrice, Order order);
}