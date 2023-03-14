namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;

public class CategoryRepo : CrudRepo<Category, CategoryDTO>, ICategoryRepo
{
  public CategoryRepo(AppDbContext dbContext) : base(dbContext)
  {
  }
}