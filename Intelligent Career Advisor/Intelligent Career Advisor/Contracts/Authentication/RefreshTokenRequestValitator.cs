
namespace Intelligent_Career_Advisor.Contracts.Authentication;

public class RefreshTokenRequestValitator: AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValitator()
    {
        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("Token is required");
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("Refresh token is required");
    }
}
