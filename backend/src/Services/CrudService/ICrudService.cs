namespace NetCoreDemo.Services;

public interface ICrudService<TModel, TDto>
{
    Task<TModel?> CreateAsync(TDto request);
    Task<TModel?> GetByIdAsync(int id);
    Task<TModel?> UpdateAsync(int id, TDto request);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<TModel>> GetAllAsync(int page, int itemsperpage);
}