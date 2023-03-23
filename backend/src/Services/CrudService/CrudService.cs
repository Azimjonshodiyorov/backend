namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using NetCoreDemo.Repositories;
using NetCoreDemo.Helpers;

public class CrudService<TModel, TDto> : ICrudService<TModel, TDto>
    where TModel : BaseModel, new()
    where TDto : BaseDTO<TModel>
{
    protected readonly AppDbContext _dbContext;

    public CrudService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        protected readonly ICrudRepo<TModel, TDto> _repo;

    public CrudService(AppDbContext dbContext, ICrudRepo<TModel, TDto> repo)
    {
        _dbContext = dbContext;
        _repo = repo;
    }

    public async virtual Task<TModel?> CreateAsync(TDto request)
    {
        var result =  await _repo.CreateAsync(request);

        if(result is null)
        {
            throw ServiceException.BadRequest("Item cannot create");
        }
        return result;
    }

    public async virtual Task<TModel?> GetAsync(int id)
    {
        var entity = await _repo.GetAsync(id);
        if (entity is null)
        {
            throw ServiceException.NotFound("No item in this id");
        }
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if(await _repo.DeleteAsync(id))
        {
            return true;
        }
        throw ServiceException.BadRequest();
    }

    public virtual async Task<IEnumerable<TModel>> GetAllAsync(int page, int itemsperpage)
    {
        var entity = await _repo.GetAllAsync(page, itemsperpage);
        if(entity is null)
        {
            throw ServiceException.NotFound("Products not found");
        }
        return entity;
    }
    
    public async Task<TModel?> UpdateAsync(int id, TDto update)
    {
        var entity = await _repo.GetAsync(id);
        if(entity is null)
        {
            throw ServiceException.BadRequest("Item cannot update");
        }
        var result = await _repo.UpdateAsync(id, update);
        return result;
    }
}