using FluentValidation;
using ProductCatalog.Cblx.Application.Request;

namespace ProductCatalog.Cblx.Application.Validator;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("Não é possível atualizar um produto sem ID.");

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("O nome do produto é obrigatório.");

        RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("A descrição do produto é obrigatória.");

        RuleFor(x => x.Price)
                .NotNull()
                .LessThan(0)
                .WithMessage("O preço não pode ser menor que 0.");
    }
}
