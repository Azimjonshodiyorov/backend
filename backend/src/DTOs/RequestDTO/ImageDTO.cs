namespace NetCoreDemo.DTOs;

using System.ComponentModel.DataAnnotations;
using NetCoreDemo.Models;

public class ImageDTO : BaseDTO<Image>
{
    // [Url]
    public string[] Url { get; set; } = null!;

    public override void UpdateModel(Image model)
    {
        model.Url = Url;
    }
}