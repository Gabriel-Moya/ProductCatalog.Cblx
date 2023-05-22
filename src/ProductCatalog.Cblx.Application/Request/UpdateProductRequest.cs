using ProductCatalog.Cblx.Application.Validator;
using ProductCatalog.Cblx.Domain.Enums;

namespace ProductCatalog.Cblx.Application.Request;

public class UpdateProductRequest
{
    private readonly UpdateProductRequestValidator _validator;

    public UpdateProductRequest()
    {
        _validator = new UpdateProductRequestValidator();
    }

    public UpdateProductRequest(
        Guid id,
        string name,
        string description,
        decimal price,
        int quantity,
        EProductType productType)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        ProductType = productType;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public EProductType ProductType { get; set; }

    public bool IsValid => _validator.Validate(this).IsValid;
}
