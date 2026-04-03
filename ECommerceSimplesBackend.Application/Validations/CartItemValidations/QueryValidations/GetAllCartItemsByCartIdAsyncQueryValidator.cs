using ECommerceSimplesBackend.Application.Queries.CartItemQueries.GetAllCartItemsByCartIdAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.CartItemValidations.QueryValidations
{
    public class GetAllCartItemsByCartIdAsyncQueryValidator
        : AbstractValidator<GetAllCartItemsByCartIdAsyncQuery>
    {
        public GetAllCartItemsByCartIdAsyncQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id do carrinho inválido.");
        }
    }
}
