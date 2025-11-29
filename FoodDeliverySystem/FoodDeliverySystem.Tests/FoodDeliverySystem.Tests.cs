using FoodDeliverySystem.Models;
using FoodDeliverySystem.Patterns.Singleton;
using FoodDeliverySystem.Services;
using FoodDeliverySystem.Patterns.Strategy;
using Xunit;

namespace FoodDeliverySystem.Tests;

public class OrderServiceTests
{
    [Fact]
    public void ShouldCreateOrder()
    {
        var service = OrderService.Instance;
        var menu = MenuService.Instance;
        var orderItems = new List<OrderItem> { new(menu.GetItemByName("Пицца"), 1) };
        var order = service.CreateOrder("standard", orderItems);
        Assert.NotNull(order);
        Assert.Equal(1, order.Id);
    }

    [Fact]
    public void ShouldCalculateTotal()
    {
        var calc = new CostCalculator();
        var menu = MenuService.Instance;
        var order = new StandardOrder
        {
            Items =
            {
                new(menu.GetItemByName("Кофе"), 2),    // 2 * 3 = 6
                new(menu.GetItemByName("Салат"), 1),   // 1 * 7 = 7
            }
        };
        var total = calc.Calculate(order, new DeliveryStrategy());
        // База: 6 + 7 = 13
        // Налог: 1.3
        // Доставка: 5
        // Итого: 13 + 1.3 + 5 = 19.3
        Assert.Equal(19.3m, total);
    }
}