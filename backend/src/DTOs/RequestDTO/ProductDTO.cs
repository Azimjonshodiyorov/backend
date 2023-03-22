namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;

public class ProductDTO : BaseDTO<Product>
{
    public string Name { get; set; } = null!;
    public double Price {get; set; }
    public  string Description { get; set; } = null!;
    public int CategoryId { get; set; }
    public ImageDTO Images { get; set; } = null!;

  public override void UpdateModel(Product model)
    {
        model.Name = Name;
        model.Price = Price;
        model.Description = Description;
        model.CategoryId = CategoryId;
        var images = new Image();
        Images.UpdateModel(images);
        model.Images = images;
    }
}



















// namespace NetCoreDemo.DTOs;

// using NetCoreDemo.Models;

// public class ProductDto : BaseDTO<Product>
// {
//     public string Name { get; set; } = null!;
//     public double Price { get; set; }
//     public string? Description { get; set; }
//     public int CategoryId { get; set; }
//     public ImageDTO? Images { get; set; }

//     public override void UpdateModel(Product model)
//     {
//         model.Name = Name;
//         model.Price = Price;
//         model.Description = Description;
//         model.CategoryId = CategoryId;
//         var images = new Image();
//         Images.UpdateModel(images);
//         model.Images = images;
//     }
// }

//   public class ProductReadDto : ProductDto { }

//   public class ProductCreateDto : ProductDto { }

//   public class ProductUpdateDto : ProductDto { }





















