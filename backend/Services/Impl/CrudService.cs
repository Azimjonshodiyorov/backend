namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;

public class CrudService<TModel, TDto> : ICrudService<TModel, TDto>
    where TModel : BaseModel, new()
    where TDto : BaseDTO<TModel>
{
    protected readonly AppDbContext _dbContext;
    protected readonly ProductService _productService;

    public CrudService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TModel?> CreateAsync(TDto request)
    {
        var item = new TModel();
        request.UpdateModel(item);
        _dbContext.Add(item);
        await _dbContext.SaveChangesAsync(); 
        return item;
    }

    public async Task<TModel?> GetAsync(int id)
    {
        return await _dbContext.Set<TModel>().AsNoTracking().FindAsync(id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await GetAsync(id);
        if(item is null)
        {
            return false;
        }
        _dbContext.Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public virtual async Task<ICollection<TModel>> GetAllAsync(ICrudFilter? filter)
    {
        return await _dbContext.Set<TModel>().AsNoTracking().ToListAsync();
    }    

    public async Task<TModel?> UpdateAsync(int id, TDto request)
    {
        var item = await GetAsync(id);
        if(item is null)
        {
            return null;
        }
        request.UpdateModel(item);
        await _dbContext.SaveChangesAsync();
        return item; 
    }
}