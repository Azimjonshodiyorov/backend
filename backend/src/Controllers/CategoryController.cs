namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


[Route("api/v1/Categories")]
public class CategoryController : CrudController<Category, CategoryDTO>
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService service) : base(service)
    {
          _categoryService = service;
    }

    [AllowAnonymous]
    [HttpGet("{id}/products")]
    public async Task<IEnumerable<Product>> GetProducts(int id)
    {
      return await _categoryService.GetProductsByCategoryAsync(id);
    }
}