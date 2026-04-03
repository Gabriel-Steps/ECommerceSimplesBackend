using ECommerceSimplesBackend.Application.Queries.CartQueries.GetCartByUserIdAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.CartValidations.QueryValidations
{
    public class GetCartByUserIdAsyncQueryValidator
        : AbstractValidator<GetCartByUserIdAsyncQuery>
    {
        public GetCartByUserIdAsyncQueryValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Id do usuário inválido.");
        }
    }
}
