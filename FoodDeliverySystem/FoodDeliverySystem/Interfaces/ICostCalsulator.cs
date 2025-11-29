using FoodDeliverySystem.Models;
using FoodDeliverySystem.Interfaces;

namespace FoodDeliverySystem.Services;

public interface ICostCalculator
{
    decimal Calculate(Order order, IPricingStrategy strategy);
}