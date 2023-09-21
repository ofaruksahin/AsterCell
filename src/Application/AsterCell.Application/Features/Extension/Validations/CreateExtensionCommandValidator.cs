using AsterCell.Application.Features.Extension.Commands;
using FluentValidation;

namespace AsterCell.Application.Features.Extension.Validations
{
    public class CreateExtensionCommandValidator : AbstractValidator<CreateExtensionCommand>
    {
        public CreateExtensionCommandValidator()
        {
            RuleFor(f => f.Exten).NotEmpty().WithMessage("Dahili numara boş olamaz");
            RuleFor(f => f.Exten).MaximumLength(100).WithMessage("Dahili numara 100 karakterden uzun olamaz");
            RuleFor(f => f.Title).NotEmpty().WithMessage("Başlık boş olamaz");
            RuleFor(f => f.Title).MaximumLength(50).WithMessage("Başlık 100 karakterden uzun olamaz");
            RuleFor(f => f.Description).MaximumLength(100).WithMessage("Açıklama 100 karakterden uzun olamaz");
        }
    }
}
