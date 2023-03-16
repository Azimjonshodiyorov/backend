using NetCoreDemo.Models;

namespace NetCoreDemo.DTOs;

public class CartDTO : BaseDTO<Cart>
{
  public string CartName { get; set; } = null!;
  public string CartStatus { get; set; } = null!;
  public override void UpdateModel(Cart model)
  {
        model.CartName = CartName;
        model.CartStatus = CartStatus;
  }
}