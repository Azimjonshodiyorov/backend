namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;
using System.ComponentModel.DataAnnotations;

public class CategoryDTO : BaseDTO<Category>
{
    [Required]
    [MaxLength(25, ErrorMessage = "Name exceeds letters")]
    [MinLength(3, ErrorMessage = "Name requires atleast 3 letter")]
    public string Name { get; set; } = null!;

    [Required]
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
















