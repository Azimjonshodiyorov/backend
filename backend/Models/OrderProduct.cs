namespace NetCoreDemo.Models;

public class OrderProduct
{
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
}