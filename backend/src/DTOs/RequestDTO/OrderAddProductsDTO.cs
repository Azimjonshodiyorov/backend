namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;

public class OrderAddProductsDTO
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}