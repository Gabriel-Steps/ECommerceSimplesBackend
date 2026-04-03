using ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductByNameAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.ProductValidations.QueryValidations
{
    public class GetAllProductByNameAsyncQueryValidator
        : AbstractValidator<GetAllProductByNameAsyncQuery>
    {
        public GetAllProductByNameAsyncQueryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome do produto é obrigatório.")
                .MinimumLength(1).WithMessage("Nome deve ter no mínimo 1 caractere.")
                .MaximumLength(100).WithMessage("Nome não pode ultrapassar 100 caracteres.");
        }
    }
}
