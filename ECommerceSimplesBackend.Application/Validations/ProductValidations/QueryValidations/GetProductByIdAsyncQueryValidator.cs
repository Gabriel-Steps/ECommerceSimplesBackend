using ECommerceSimplesBackend.Application.Queries.ProductQueries.GetProductByIdAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.ProductValidations.QueryValidations
{
    public class GetProductByIdAsyncQueryValidator
        : AbstractValidator<GetProductByIdAsyncQuery>
    {
        public GetProductByIdAsyncQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id do produto inválido.");
        }
    }
}
