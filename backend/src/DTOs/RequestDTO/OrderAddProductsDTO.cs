namespace NetCoreDemo.DTOs;

using System.ComponentModel.DataAnnotations;
using NetCoreDemo.Models;

public class OrderAddProductsDTO
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }
}