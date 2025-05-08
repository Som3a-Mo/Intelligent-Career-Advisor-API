namespace Intelligent_Career_Advisor.Contracts.Users;

public record AddProfileDataRequest
(
    IFormFile? ProfilePicture,
    UserGender Gender,
    DateTime DateOfBirth,
    int ExperienceYears,
    string PhoneNumber,
    string City,
    string Country,
    string Degree,
    string University,
    int? GraduationYear,
    string JobTitle,
    string Company,
    decimal? SalaryExpectations,
    IFormFile? ResumeFile,
    List<string> HardSkills,
    List<string> SoftSkills
);
