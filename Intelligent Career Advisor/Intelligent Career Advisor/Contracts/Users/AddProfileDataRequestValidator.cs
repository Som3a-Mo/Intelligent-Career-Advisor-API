namespace Intelligent_Career_Advisor.Contracts.Users;

public class AddProfileDataRequestValidator: AbstractValidator<AddProfileDataRequest>
{
    public AddProfileDataRequestValidator()
    {
        RuleFor(x => x.ProfilePicture)
            .Must(file => file.ContentType == "image/jpeg" || file.ContentType == "image/png")
            .When(x => x.ProfilePicture != null)
            .WithMessage("Profile picture must be a JPEG or PNG image.");


        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("City is required.");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+?[0-9]{10,15}$")
            .WithMessage("Phone number must be a valid format.");

        RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage("Country is required.");
        RuleFor(x => x.Degree)
            .NotEmpty()
            .WithMessage("Degree is required.");
        RuleFor(x => x.University)
            .NotEmpty()
            .WithMessage("University is required.");
        RuleFor(x => x.GraduationYear)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Years of experience must be a non-negative number.");
        RuleFor(x => x.JobTitle)
            .NotEmpty()
            .WithMessage("Job title is required.");
        RuleFor(x => x.Company)
            .NotEmpty()
            .WithMessage("Company name is required.");
        RuleFor(x => x.SalaryExpectations)
            .GreaterThan(0)
            .When(x => x.SalaryExpectations.HasValue)
            .WithMessage("Salary expectations must be a positive number.");
    }
}
