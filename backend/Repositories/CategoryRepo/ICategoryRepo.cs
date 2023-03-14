namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface ICategoryRepo : ICrudRepo<Category, CategoryDTO>
{

}