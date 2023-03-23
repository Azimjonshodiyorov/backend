namespace NetCoreDemo.Models;

public class Product : BaseModel
{
    public string Name { get; set; } = null!;
    public double Price {get; set; }
    public  string Description { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }
    public Image Images { get; set; } = null!;
    public int? ImageId { get; set; }
    public ICollection<OrderProduct> OrderLinks {get; set; }
}