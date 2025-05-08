namespace Intelligent_Career_Advisor.Helpers.AuthenticationHelpers;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(ApplicationUser user);
    string? ValidateToken(string token);
}
