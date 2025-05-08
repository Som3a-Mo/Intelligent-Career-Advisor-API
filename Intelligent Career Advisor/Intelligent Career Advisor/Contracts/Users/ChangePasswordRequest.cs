namespace Intelligent_Career_Advisor.Contracts.Users;

public record ChangePasswordRequest(
    string CurrentPassword,
    string NewPassword
);