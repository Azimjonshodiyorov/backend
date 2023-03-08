namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;

public class ProductDTO : BaseDTO<Product>
{
    public string Name { get; set; } = null!;
    public double Price {get; set; }
    public  string Description { get; set; } = null!;

    public override void UpdateModel(Product model)
    {
        model.Name = Name;
        model.Price = Price;
        model.Description = Description;
    }
}