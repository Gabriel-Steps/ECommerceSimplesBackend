using ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductsBetweenPricesAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.ProductValidations.QueryValidations
{
    public class GetAllProductsBetweenPricesAsyncQueryValidator
        : AbstractValidator<GetAllProductsBetweenPricesAsyncQuery>
    {
        public GetAllProductsBetweenPricesAsyncQueryValidator()
        {
            RuleFor(x => x.minPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Preço mínimo não pode ser negativo.");

            RuleFor(x => x.maxprice)
                .GreaterThan(0).WithMessage("Preço máximo deve ser maior que zero.");

            RuleFor(x => x)
                .Must(x => x.maxprice > x.minPrice)
                .WithMessage("Preço máximo deve ser maior que o preço mínimo.");
        }
    }
}
