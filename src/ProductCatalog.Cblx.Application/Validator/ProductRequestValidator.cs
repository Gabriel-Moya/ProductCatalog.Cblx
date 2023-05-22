using FluentValidation;
using ProductCatalog.Cblx.Application.Request;

namespace ProductCatalog.Cblx.Application.Validator;

public class ProductRequestValidator : AbstractValidator<ProductRequest>
{
    public ProductRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome do produto é obrigatório.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("A descrição do produto é obrigatório.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("O preço não pode ser menor que 0.");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ProductRequest>.CreateWithOptions((ProductRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
