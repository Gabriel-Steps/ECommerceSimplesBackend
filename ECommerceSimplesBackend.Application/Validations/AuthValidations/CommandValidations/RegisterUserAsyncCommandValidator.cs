using ECommerceSimplesBackend.Application.Commands.AuthCommands.RegisterUserAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.AuthValidations.CommandValidations
{
    public class RegisterUserAsyncCommandValidator
        : AbstractValidator<RegisterUserAsyncCommand>
    {
        public RegisterUserAsyncCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(100).WithMessage("Nome não pode ultrapassar 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres.")
                .MaximumLength(64).WithMessage("Senha não pode ultrapassar 64 caracteres.")
                .Matches("[A-Z]").WithMessage("Senha deve conter ao menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("Senha deve conter ao menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("Senha deve conter ao menos um número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Senha deve conter ao menos um caractere especial.");
        }
    }
}
