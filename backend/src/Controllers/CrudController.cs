namespace NetCoreDemo.Controllers;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
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
        return Ok(item);
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TModel?>> Get(int id)
    {
        return Ok(await _service.GetAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TModel?>> Update(int id, TDto request)
    {
        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteAsync(id));
    }

    [AllowAnonymous]
    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TModel>>> GetAll(int page, int itemsperpage)
    {
        return Ok(await _service.GetAllAsync(page, itemsperpage));
    }
}

