using ECommerceSimplesBackend.Application.Commands.OrderCommands.DeleteOrderAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.OrderValidations.CommandValidations
{
    public class DeleteOrderAsyncCommandValidator
        : AbstractValidator<DeleteOrderAsyncCommand>
    {
        public DeleteOrderAsyncCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id do pedido inválido.");
        }
    }
}
