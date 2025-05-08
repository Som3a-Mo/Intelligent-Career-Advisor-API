namespace Intelligent_Career_Advisor.Contracts.Authentication;

public record RefreshTokenRequest(
    string Token,
    string RefreshToken
);
