using System.Collections.Generic;
using System.Linq;

namespace FoodDeliverySystem.Models;

public abstract class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public OrderStatus Status { get; set; } = OrderStatus.Preparation;

    public abstract decimal CalculateTotalCost();
    public abstract void ApplySpecialConditions();
}

public class StandardOrder : Order
{
    public override decimal CalculateTotalCost() => Items.Sum(i => i.GetTotalPrice());
    public override void ApplySpecialConditions() { }
}

public class SpecialConditionOrder : Order
{
    public string SpecialNote { get; set; } = string.Empty;
    public bool IsExpress { get; set; }

    public override decimal CalculateTotalCost()
    {
        var total = Items.Sum(i => i.GetTotalPrice());
        if (IsExpress) total += 10.0m;
        return total;
    }

    public override void ApplySpecialConditions()
    {
        Console.WriteLine($"Применены особые условия: {SpecialNote}");
    }
}