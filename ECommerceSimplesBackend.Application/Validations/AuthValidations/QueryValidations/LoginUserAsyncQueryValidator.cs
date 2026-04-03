using ECommerceSimplesBackend.Application.Queries.AuthQueries.LoginUserAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.AuthValidations.QueryValidations
{
    public class LoginUserAsyncQueryValidator
        : AbstractValidator<LoginUserAsyncQuery>
    {
        public LoginUserAsyncQueryValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres.");
        }
    }
}
