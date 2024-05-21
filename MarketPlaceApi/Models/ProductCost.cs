namespace MarketPlaceApi.Entities;

public class ProductCost
{
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public decimal IVA { get; set; }
    public decimal Cost { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}