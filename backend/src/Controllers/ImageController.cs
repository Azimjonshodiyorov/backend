namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;

public class ImageController : CrudController<Image, ImageDTO>
{
  public ImageController(ICrudService<Image, ImageDTO> service) : base(service)
  {
  }
}