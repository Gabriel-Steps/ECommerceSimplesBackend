using ECommerceSimplesBackend.Application.Commands.OrderCommands.CreateOrderAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.OrderValidations.CommandValidations
{
    public class CreateOrderAsyncCommandValidator
        : AbstractValidator<CreateOrderAsyncCommand>
    {
        public CreateOrderAsyncCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Id do usuário inválido.");

            RuleFor(x => x.Total)
                .GreaterThan(0).WithMessage("Total do pedido deve ser maior que zero.");
        }
    }
}
