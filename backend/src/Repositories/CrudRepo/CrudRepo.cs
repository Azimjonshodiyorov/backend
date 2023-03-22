namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class CrudRepo<TModel,TDto> : ICrudRepo<TModel, TDto>
    where TModel : BaseModel, new()
    where TDto : BaseDTO<TModel>
{
    protected readonly AppDbContext _dbContext;
    public CrudRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<TModel?> CreateAsync(TDto request)
    {
        var item = new TModel();
        request.UpdateModel(item);
        _dbContext.Add(item);
        await _dbContext.SaveChangesAsync(); 
        return item;
    }

    public virtual async Task<TModel?> GetAsync(int id)
    {
        return await _dbContext.Set<TModel>().FindAsync(id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await GetAsync(id);
        if(item is null)
        {
            return false;
        }
        _dbContext.Set<TModel>().Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public virtual async Task<ICollection<TModel>> GetAllAsync(int page, int itemsperpage)
    {
        if(page > 0 && itemsperpage > 0)
        {
            return await _dbContext.Set<TModel>().AsNoTracking()
                        .OrderBy(p => p.Id)
                        .Skip((page - 1) * itemsperpage)
                        .Take(itemsperpage)
                        .ToListAsync();
        }
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