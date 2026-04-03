using ECommerceSimplesBackend.Application.Commands.CartCommands.CreateCartAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.CartValidations.CommandValidations
{
    public class CreateCartAsyncCommandValidator
        : AbstractValidator<CreateCartAsyncCommand>
    {
        public CreateCartAsyncCommandValidator()
        {
            RuleFor(x => x.userId)
                .GreaterThan(0).WithMessage("Id do usuário inválido.");
        }
    }
}
