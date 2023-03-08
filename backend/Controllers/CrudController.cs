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
        if(item is null)
        {
            return BadRequest("Product not created");
        }
        return Ok(item);
    }
}

