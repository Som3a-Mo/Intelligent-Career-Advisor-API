using Intelligent_Career_Advisor.Contracts.JobApplication;

namespace Intelligent_Career_Advisor.Services;

public interface IJobApplicationService
{
    Task<List<JobApplicationRespons>> GetJobApplicationsAsync(string userId);
    Task DeleteJobApplicationAsync(int jobApplicationId, CancellationToken cancellationToken);
    Task<JobApplicationRespons> AddJobApplicationAsync(string userId, JobApplicationRequest jobApplicationRequest, CancellationToken cancellationToken);
    Task UpdateJobApplicationAsync(int Id, JobApplicationRequest jobApplication, CancellationToken cancellationToken);
    Task<JobApplicationRespons?> GetJobApplicationByIdAsync(string userId, int id, CancellationToken cancellationToken);
}
