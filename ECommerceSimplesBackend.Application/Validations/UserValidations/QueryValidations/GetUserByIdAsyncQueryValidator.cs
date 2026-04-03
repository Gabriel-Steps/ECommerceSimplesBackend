using ECommerceSimplesBackend.Application.Queries.UserQueries.GetUserByIdAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.UserValidations.QueryValidations
{
    public class GetUserByIdAsyncQueryValidator
        : AbstractValidator<GetUserByIdAsyncQuery>
    {
        public GetUserByIdAsyncQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id do usuário inválido.");
        }
    }
}
