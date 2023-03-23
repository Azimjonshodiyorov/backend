namespace NetCoreDemo.Models;

using System.ComponentModel.DataAnnotations;

public class Order : BaseModel
{
    public string OrderName { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<OrderProduct> ProductLinks {get; set; }
}