namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;

public class ImageRepo : CrudRepo<Image, ImageDTO>, IImageRepo
{
  public ImageRepo(AppDbContext dbContext) : base(dbContext)
  {
  }
}