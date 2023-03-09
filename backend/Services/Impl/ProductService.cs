namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ProductService : CrudService<Product, ProductDTO>, IProductService
{
  public ProductService(AppDbContext dbContext) : base(dbContext)
  {
  }

  public override async Task<ICollection<Product>> GetAllAsync(ICrudFilter? filter)
  {
      var productFilter = (ProductFilterDTO?)filter;
      var query = _dbContext.Products.Where(c => true);

      if (productFilter?.Name is not null)
      {
          query = query.Where(c => c.Name == productFilter.Name);
      }
      if (productFilter?.Keyword is not null && !string.IsNullOrEmpty(productFilter?.Keyword))
      {
          query = query.Where(c => c.Name.Contains(productFilter!.Keyword));
      }
      return await query.OrderByDescending(c => c.CreatedAt).ToListAsync();  
  }
}