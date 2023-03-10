namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;

public class CategoryDTO : BaseDTO<Category>
{
    public string Name { get; set; } = null!;

    public override void UpdateModel(Category model)
    {
        model.Name = Name;
    }
}