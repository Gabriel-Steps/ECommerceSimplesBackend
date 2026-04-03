using ECommerceSimplesBackend.Application.Commands.ProductCommands.DeleteProductAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.ProductValidations.CommandValidations
{
    public class DeleteProductAsyncCommandValidator
        : AbstractValidator<DeleteProductAsyncCommand>
    {
        public DeleteProductAsyncCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id do produto inválido.");
        }
    }
}
