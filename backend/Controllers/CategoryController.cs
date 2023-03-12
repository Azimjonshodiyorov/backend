namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Common;

[Route("Categories")]
public class CategoryController : CrudController<Category, CategoryDTO>
{
    private readonly ICategoryService _categoryService;
  public CategoryController(ICategoryService service) : base(service)
  {
        _categoryService = service;
  }

  [HttpGet]
  public override async Task<ICollection<Category>> GetAll()
  {
        var @params = Request.QueryString.ParseParams<PaginationParams>();
        if(@params is not null)
        {
            return await _categoryService.GetAllAsync(@params);
        }
        return await _categoryService.GetAllAsync(null);
        
  }

  [HttpGet("{id}/products")]
  public async Task<ICollection<Product>> GetProducts(int id)
  {
    return await _categoryService.GetProductsAsync(id);
  }
}