namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;

public class ImageController : CrudController<Image, ImageDTO>
{
    private readonly IImageService _imageService;
    public ImageController(IImageService service) : base(service)
    {
              _imageService = service;
    }
}