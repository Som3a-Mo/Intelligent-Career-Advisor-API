namespace Intelligent_Career_Advisor.Contracts.JobApplication;

public record JobApplicationRequest
(
    string JobTitle,
    string CompanyName,
    DateTime ApplicationDate,
    ApplicationStatus Status,
    string ApplicationSource,
    string Notes,
    IFormFile? Attachment
);
