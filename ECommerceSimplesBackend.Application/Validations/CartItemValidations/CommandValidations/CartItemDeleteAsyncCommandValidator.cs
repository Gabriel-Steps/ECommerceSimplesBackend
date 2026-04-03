using ECommerceSimplesBackend.Application.Commands.CartItemCommands.CartItemDeleteAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.CartItemValidations.CommandValidations
{
    public class CartItemDeleteAsyncCommandValidator
        : AbstractValidator<CartItemDeleteAsyncCommand>
    {
        public CartItemDeleteAsyncCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id do item do carrinho inválido.");
        }
    }
}
