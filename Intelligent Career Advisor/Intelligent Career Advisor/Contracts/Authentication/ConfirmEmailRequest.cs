namespace Intelligent_Career_Advisor.Contracts.Authentication;

public record ConfirmEmailRequest(
    string UserId,
    string Code
);