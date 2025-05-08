namespace Intelligent_Career_Advisor.Helpers.AuthenticationHelpers;

public class JwtOptions
{
    [Required]
    public string Key { get; set; } = string.Empty;
    [Required]
    public string Issuer { get; set; } = string.Empty;
    [Required]
    public string Audience { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int ExpiryDays { get; set; }
}
