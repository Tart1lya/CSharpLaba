using FoodDeliverySystem.Models;

namespace FoodDeliverySystem.Patterns.Decorator;

public class SpecialConditionsDecorator : Order
{
    private readonly Order _order;
    private readonly string _note;

    public SpecialConditionsDecorator(Order order, string note)
    {
        _order = order;
        _note = note;
        Id = order.Id;
        Items = order.Items;
        Status = order.Status;
    }

    public override decimal CalculateTotalCost()
    {
        var cost = _order.CalculateTotalCost();
        if (_note.Contains("express", StringComparison.OrdinalIgnoreCase))
            cost += 10.0m;
        return cost;
    }

    public override void ApplySpecialConditions()
    {
        _order.ApplySpecialConditions();
        Console.WriteLine($"Декоратор: {_note}");
    }
}