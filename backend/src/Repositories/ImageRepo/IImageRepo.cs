namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface IImageRepo : ICrudRepo<Image, ImageDTO>
{
}