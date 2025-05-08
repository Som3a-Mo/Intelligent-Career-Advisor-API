

namespace Intelligent_Career_Advisor.Contracts.Users;

public record UserProfileResponse(
    string Email,
    string FullName,
    string? ProfilePictureUrl,
    string PhoneNumber,
    int ExperienceYears,
    UserGender Gender,
    DateTime DateOfBirth,
    string City,
    string Country,
    string Degree,
    string University,
    int? GraduationYear,
    ICollection<string> HardSkills,
    ICollection<string> SoftSkills,
    string JobTitle,
    string Company,
    decimal SalaryExpectations,
    string? ResumeFileUrl
    //string LinkedInUrl,
    //string GitHubUrl
);