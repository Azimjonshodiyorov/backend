using System.ComponentModel.DataAnnotations;
using NetCoreDemo.Models;

namespace NetCoreDemo.DTOs;

public class OrderDTO : BaseDTO<Order>
{
  [Required]
  public int UserId { get; set; }

  [Required]
  public string OrderName { get; set; } = null!;
  
  public override void UpdateModel(Order model)
  {
        model.UserId = UserId;
        model.OrderName = OrderName;
  }
}