namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using NetCoreDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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

    public async Task<TModel?> CreateAsync(TDto request)
    {
        var result =  await _repo.CreateAsync(request);
        if(result is null)
        {
            throw new Exception("Cannot create item");
        }
        return result;
    }

    public async virtual Task<TModel?> GetAsync(int id)
    {
        var entity = await _repo.GetAsync(id);
        if (entity is null)
        {
            throw new Exception("Item not found");
        }
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if(await _repo.DeleteAsync(id))
        {
            return true;
        }
        return false;
    }

    public virtual async Task<IEnumerable<TModel>> GetAllAsync(PaginationParams @params)
    {
        var entity = await _repo.GetAllAsync(@params);
        if(entity is null)
        {
            throw new Exception("Not found!");
        }
        return entity;
    }
    
    public async Task<TModel?> UpdateAsync(int id, TDto update)
    {
        var entity = await _repo.GetAsync(id);
        if(entity is null)
        {
            throw new Exception();
        }
        var result = await _repo.UpdateAsync(id, update);
        return result;
    }
}