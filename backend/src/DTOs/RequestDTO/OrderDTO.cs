using NetCoreDemo.Models;

namespace NetCoreDemo.DTOs;

public class OrderDTO : BaseDTO<Order>
{
  public int UserId { get; set; }
  public string OrderName { get; set; } = null!;
  public override void UpdateModel(Order model)
  {
        model.UserId = UserId;
        model.OrderName = OrderName;
  }
}