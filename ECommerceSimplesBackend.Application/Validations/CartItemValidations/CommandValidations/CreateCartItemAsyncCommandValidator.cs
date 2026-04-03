using ECommerceSimplesBackend.Application.Commands.CartItemCommands.CreateCartItemAsync;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSimplesBackend.Application.Validations.CartItemValidations.CommandValidations
{
    public class CreateCartItemAsyncCommandValidator
        : AbstractValidator<CreateCartItemAsyncCommand>
    {
        public CreateCartItemAsyncCommandValidator()
        {
            RuleFor(x => x.CartId)
                .GreaterThan(0).WithMessage("Id do carrinho inválido.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Id do produto inválido.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(100).WithMessage("Quantidade não pode ultrapassar 100 unidades.");

            RuleFor(x => x.ProductPrice)
                .GreaterThan(0).WithMessage("Preço do produto deve ser maior que zero.");
        }
    }
}
