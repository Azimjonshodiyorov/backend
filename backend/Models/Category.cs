namespace NetCoreDemo.Models;

public class Category : BaseModel
{
    public string Name { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = null!;
}