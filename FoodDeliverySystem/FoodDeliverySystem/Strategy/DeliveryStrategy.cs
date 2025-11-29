using FoodDeliverySystem.Models;
using FoodDeliverySystem.Interfaces;

namespace FoodDeliverySystem.Patterns.Strategy;

public class DeliveryStrategy : IPricingStrategy
{
    public decimal CalculateFinalPrice(decimal basePrice, Order order)
    {
        decimal tax = basePrice * 0.1m;
        decimal fee = 5.0m;
        if (order is SpecialConditionOrder special && special.IsExpress)
            fee += 5.0m;
        return basePrice + tax + fee;
    }
}