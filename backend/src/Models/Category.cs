namespace NetCoreDemo.Models;

using System.ComponentModel.DataAnnotations;

public class Category : BaseModel
{
    public string Name { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = null!;
    public Image Images { get; set; } = null!;
    public int? ImageId { get; set; }
}