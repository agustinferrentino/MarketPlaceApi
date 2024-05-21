using System;
using System.Collections.Generic;
using MarketPlaceApi.Entities;

namespace MarketplaceAPI.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Title { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal Price { get; set; }
    public decimal Commission { get; set; }
    public decimal ShippingCost { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public ICollection<ProductCost> ProductCosts { get; set; }
}