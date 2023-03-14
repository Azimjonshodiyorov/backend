namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface ICrudService<TModel, TDto>
{
    Task<TModel?> CreateAsync(TDto request);
    Task<TModel?> GetAsync(int id);
    Task<TModel?> UpdateAsync(int id, TDto request);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<TModel>> GetAllAsync(PaginationParams @params);
}