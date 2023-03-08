namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public class CrudService<TModel, TDto> : ICrudService<TModel, TDto>
    where TModel : BaseModel, new()
    where TDto : BaseDTO<TModel>
{
    public async Task<TModel?> CreateAsync(TDto request)
    {
        var item = new TModel();
        request.UpdateModel(item);
        return item;
    }

    public Task<TModel?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<TModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TModel?> UpdateAsync(int id, TDto request)
    {
        throw new NotImplementedException();
    }
}