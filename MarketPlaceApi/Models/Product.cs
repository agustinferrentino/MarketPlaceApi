namespace MarketPlaceApi.Entities;

public class Product
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
}
