namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;

public class ImageDTO : BaseDTO<Image>
{
    public string[] Url { get; set; } = null!;

    public override void UpdateModel(Image model)
    {
        model.Url = Url;
    }
}