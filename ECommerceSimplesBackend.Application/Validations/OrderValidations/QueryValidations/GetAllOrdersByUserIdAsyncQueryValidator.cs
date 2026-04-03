using ECommerceSimplesBackend.Application.Queries.OrderQueries.GetAllOrderByUserIDAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.OrderValidations.QueryValidations
{
    public class GetAllOrdersByUserIdAsyncQueryValidator
        : AbstractValidator<GetAllOrdersByUserIdAsyncQuery>
    {
        public GetAllOrdersByUserIdAsyncQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id do usuário inválido.");
        }
    }
}
