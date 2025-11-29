using System;

namespace FoodDeliverySystem.Models;

public class OrderItem
{
    public MenuItem Item { get; set; }
    public int Quantity { get; set; }

    public OrderItem(MenuItem item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }

    public decimal GetTotalPrice() => Item.Price * Quantity;
}