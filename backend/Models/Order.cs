namespace NetCoreDemo.Models;

public class Order : BaseModel
{
    public string OrderName { get; set; } = null!;
    public string OrderStatus { get; set; } = null!;

    public ICollection<OrderProduct> ProductLinks {get; set; } = null!;
}