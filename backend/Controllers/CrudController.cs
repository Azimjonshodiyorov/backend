namespace NetCoreDemo.Controllers;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;

public class CrudController<TModel, TDto> : ApiControllerBase
    where TModel : BaseModel, new()
    where TDto : BaseDTO<TModel>

{
     protected readonly ICrudService<TModel, TDto> _service;

    public CrudController(ICrudService<TModel, TDto> service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    public async Task<IActionResult> Create(TDto request)
    {
        var item = await _service.CreateAsync(request);
        Console.WriteLine($"first request for products {request}");
        if(item is null)
        {
            return BadRequest("Product not created");
        }
        return Ok(item);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TModel?>> Get(int id)
    {
        var item = await _service.GetAsync(id);
        if (item is null)
        {
            return NotFound("Item not found");
        }
        return item;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TModel?>> Update(int id, TDto request)
    {
        var item = await _service.UpdateAsync(id, request);
        if(item is null)
        {
            return BadRequest("Item not found");
        }
        return item;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (await _service.DeleteAsync(id))
        {
            return Ok(new { Message = "Item deleted successfully" });
        }
        return NotFound("Item not found");
    }

    [HttpGet]
    public async Task<ICollection<TModel>> GetAll()
    {
        return await _service.GetAllAsync();
    }
}

