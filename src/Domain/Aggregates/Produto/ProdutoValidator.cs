using FluentValidation;

namespace Anselme.Contatos.Domain.Aggregates;

public class ProdutoValidator : AbstractValidator<Produto> 
{
    public ProdutoValidator()
    {
        RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("Nome não pode ser nulo ou vazio");
        RuleFor(p => p.Nome).Matches("^[a-zA-Z0-9_]*$").WithMessage("Nome não pode ter caracteres especiais");
        RuleFor(p => p.Nome).Length(0,255).WithMessage("Nome não pode ter mais do que 255 caracteres");
        RuleFor(p => p.Preco).LessThan(0).WithMessage("O preço não pode ser menor do que zero");
        RuleFor(p =>p.DataDeRegistro).GreaterThanOrEqualTo(new DateTime(2000,1,1)).WithMessage("A data de registro do produto não pode ser inferior a 01/01/2000");
    }
}