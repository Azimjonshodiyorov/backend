using NetCoreDemo.Models;

namespace NetCoreDemo.DTOs;

public class OrderDTO : BaseDTO<Order>
{
  public string CartName { get; set; } = null!;
  public string CartStatus { get; set; } = null!;
  public override void UpdateModel(Order model)
  {
        model.OrderName = CartName;
        model.OrderStatus = CartStatus;
  }
}