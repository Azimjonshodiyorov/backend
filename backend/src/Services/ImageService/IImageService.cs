namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Repositories;
using NetCoreDemo.Db;

public interface IImageService : ICrudService<Image, ImageDTO>
{
    
}