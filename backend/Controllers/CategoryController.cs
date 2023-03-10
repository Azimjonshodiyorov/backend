namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Common;

public class CategorieController : CrudController<Category, CategoryDTO>
{
    private readonly ICategoryService _categoryService;
  public CategorieController(ICategoryService service) : base(service)
  {
        _categoryService = service;
  }

  [HttpGet]
  public override async Task<ICollection<Category>> GetAll()
  {
        var @params = Request.QueryString.ParseParams<PaginationParams>();
        return await _categoryService.GetAllAsync(@params);
  }
}