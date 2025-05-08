namespace Intelligent_Career_Advisor.Abstractions;

public record Error(string Code, string Description, int? StatusCodes)
{
    public static readonly Error None = new(string.Empty, string.Empty, null);
}
