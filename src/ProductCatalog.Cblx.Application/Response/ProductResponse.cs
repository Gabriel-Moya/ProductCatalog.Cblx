using ProductCatalog.Cblx.Domain.Enums;

namespace ProductCatalog.Cblx.Application.Response;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public EProductType ProductType { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
