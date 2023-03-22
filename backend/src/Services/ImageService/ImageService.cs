namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Repositories;
using NetCoreDemo.Helpers;

public class ImageService : CrudService<Image, ImageDTO>, IImageService
{
    protected readonly IImageRepo _repo;
    public ImageService(AppDbContext dbContext, IImageRepo repo) : base(dbContext, repo)
    {
        _repo = repo;
    }
}