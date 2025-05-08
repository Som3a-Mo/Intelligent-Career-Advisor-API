namespace Intelligent_Career_Advisor.Contracts.Authentication;

public record AuthResponse(
    string Id,
    string? Email,
    string FullName,
    string Token,
    int ExpiresIn,
    string RefreshToken,
    DateTime RefreshTokenExpiration

    );
