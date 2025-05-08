namespace Intelligent_Career_Advisor.Contracts.Authentication;

public record RegisterRequest(
    string Email,
    string Password,
    string FullName
);