using FluentValidation;
using SnackyAPI.Models.DTO;

namespace SnackyAPI.Models.Validation
{
    public class SnackCreationValidator : AbstractValidator<CreateSnackDTO>
    {
        public SnackCreationValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.ImagePath)
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.ImagePath))
                .WithMessage("The provided image is not a valid URL");
        }
    }
}
