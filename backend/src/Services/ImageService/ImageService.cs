namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using NetCoreDemo.Repositories;

public class ImageService : CrudService<Image, ImageDTO>, IImageService
{
    protected readonly IImageRepo _repo;
    public ImageService(AppDbContext dbContext, IImageRepo repo) : base(dbContext, repo)
    {
        _repo = repo;
    }
}