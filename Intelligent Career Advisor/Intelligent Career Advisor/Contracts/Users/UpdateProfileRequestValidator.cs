namespace Intelligent_Career_Advisor.Contracts.Users;

public class UpdateProfileRequestValidator : AbstractValidator<UpdateProfileRequest>
{
    public UpdateProfileRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(x => x.ProfilePicture)
        .Must(file => file.ContentType == "image/jpeg" || file.ContentType == "image/png")
        .When(x => x.ProfilePicture is not null)
        .WithMessage("Profile picture must be a JPEG or PNG image.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[0-9]{10,15}$")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
            .WithMessage("Phone number must be a valid format.");
    }
}