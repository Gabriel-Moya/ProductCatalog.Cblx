using ProductCatalog.Cblx.Application.Validator;
using ProductCatalog.Cblx.Domain.Enums;

namespace ProductCatalog.Cblx.Application.Request;

public class ProductRequest
{
    private readonly ProductRequestValidator _validator;

    public ProductRequest()
    {
        _validator = new ProductRequestValidator();
    }

    public ProductRequest(
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
    }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public EProductType ProductType { get; set; }

    public bool IsValid => _validator.Validate(this).IsValid;
}
