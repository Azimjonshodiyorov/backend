namespace NetCoreDemo.Models;

public class Cart : BaseModel
{
    public string CartName { get; set; } = null!;
    public string CartStatus { get; set; } = null!;

    public ICollection<CartProduct> ProductLinks {get; set; } = null!;
}