namespace NetCoreDemo.Models;

public class CartProduct
{
    public Cart Cart { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
}