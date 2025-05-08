namespace Intelligent_Career_Advisor.Contracts.JobApplication;

public record JobApplicationRespons
(
    int Id,
    string JobTitle,
    string CompanyName,
    DateTime ApplicationDate,
    ApplicationStatus Status,
    string ApplicationSource,
    string Notes,
    string? AttachmentUrl
);