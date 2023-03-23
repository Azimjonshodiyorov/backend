namespace NetCoreDemo.Models;

public class OrderProduct
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }

    public static explicit operator OrderProduct(Task<List<OrderProduct>> v)
    {
      throw new NotImplementedException();
    }
}