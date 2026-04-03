using ECommerceSimplesBackend.Application.Commands.CartItemCommands.UpdateCartItemAsync;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSimplesBackend.Application.Validations.CartItemValidations.CommandValidations
{
    public class UpdateCartItemAsyncCommandValidator
        : AbstractValidator<UpdateCartItemAsyncCommand>
    {
        public UpdateCartItemAsyncCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id do item do carrinho inválido.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(100).WithMessage("Quantidade não pode ultrapassar 100 unidades.");
        }
    }
}
