namespace NetCoreDemo.DTOs;

using NetCoreDemo.Models;

public class ProductFilterDTO : ICrudFilter
{
    public string Name { get; set; } = null!;
    public string? Keyword { get; set; }
    public double? Price { get; set; }
    public double? Price_Min { get; set; }
    public double? Price_Max { get; set; }
}