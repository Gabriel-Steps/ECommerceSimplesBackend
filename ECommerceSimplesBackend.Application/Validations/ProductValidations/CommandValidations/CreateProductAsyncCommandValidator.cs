using ECommerceSimplesBackend.Application.Commands.ProductCommands.CreateProductAsync;
using FluentValidation;

namespace ECommerceSimplesBackend.Application.Validations.ProductValidations.CommandValidations
{
    // CreateProductAsyncCommandValidator.cs
    public class CreateProductAsyncCommandValidator
        : AbstractValidator<CreateProductAsyncCommand>
    {
        public CreateProductAsyncCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome do produto é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(100).WithMessage("Nome não pode ultrapassar 100 caracteres.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Preço do produto deve ser maior que zero.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Descrição do produto é obrigatória.")
                .MinimumLength(10).WithMessage("Descrição deve ter no mínimo 10 caracteres.")
                .MaximumLength(500).WithMessage("Descrição não pode ultrapassar 500 caracteres.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("URL da imagem é obrigatória.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("URL da imagem inválida.");
        }
    }
}
