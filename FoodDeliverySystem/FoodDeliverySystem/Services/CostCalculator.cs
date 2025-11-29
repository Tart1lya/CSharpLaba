using FoodDeliverySystem.Models;
using FoodDeliverySystem.Interfaces;

namespace FoodDeliverySystem.Services;

public class CostCalculator : ICostCalculator
{
    public decimal Calculate(Order order, IPricingStrategy strategy)
    {
        var baseCost = order.CalculateTotalCost();
        return strategy.CalculateFinalPrice(baseCost, order);
    }
}