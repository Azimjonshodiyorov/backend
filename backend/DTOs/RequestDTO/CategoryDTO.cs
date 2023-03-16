namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;

public class CategoryDTO : BaseDTO<Category>
{
    public string Name { get; set; } = null!;
    public ImageDTO Images { get; set; } = null!;

    public override void UpdateModel(Category model)
    {
        model.Name = Name;
        var images = new Image();
        Images.UpdateModel(images);
        model.Images = images;
    }
}



















// namespace NetCoreDemo.DTOs;

// using NetCoreDemo.Models;

// public class CategoryDTO : BaseDTO<Category>
// {
//     public string Name { get; set; } = null!;
//     public ImageDTO Images { get; set; } = null!;

//     public override void UpdateModel(Category model)
//     {
//         model.Name = Name;
//         var images = new Image();
//         Images.UpdateModel(images);
//         model.Images = images;
//     }
// }

//   public class CategoryReadDto : CategoryDTO { }

//   public class CategoryCreateDto : CategoryDTO { }

//   public class CategoryUpdateDto : CategoryDTO { }
















