using ProductCatalog.Cblx.Domain.Enums;

namespace ProductCatalog.Cblx.Domain.Entities;

public class Product : BaseEntity
{
    protected Product() { }

    public Product(
        string name,
        string description,
        decimal price,
        int quantity,
        EProductType productType)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        ProductType = productType;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public EProductType ProductType { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
