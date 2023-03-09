namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;

public class ProductFilterDTO : ICrudFilter
{
    public string Name { get; set; } = null!;
    public string? Keyword { get; set; }
}