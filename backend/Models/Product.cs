namespace NetCoreDemo.Models;

public class Product : BaseModel
{
    public string Name { get; set; } = null!;
    public double Price {get; set; }
    public  string Description { get; set; } = null!;
}