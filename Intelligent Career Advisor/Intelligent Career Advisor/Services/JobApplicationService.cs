using Intelligent_Career_Advisor.Contracts.JobApplication;

namespace Intelligent_Career_Advisor.Services;

public class JobApplicationService(ApplicationContext context, IHttpContextAccessor accessor, IWebHostEnvironment env) : IJobApplicationService
{

    private readonly ApplicationContext _context = context;
    private readonly IHttpContextAccessor _accessor = accessor;
    private readonly IWebHostEnvironment _env = env;

    public async Task<JobApplicationRespons> AddJobApplicationAsync(string userId, JobApplicationRequest jobApplicationRequest, CancellationToken cancellationToken)
    {
        var jobApplication = jobApplicationRequest.Adapt<JobApplication>();
        jobApplication.ApplicationUserId = userId;
        jobApplication.AttachmentUrl = await FileHelpers.SaveFileAsync(jobApplicationRequest.Attachment, "files", _accessor, _env);

        await _context.JobApplications.AddAsync(jobApplication, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return jobApplication.Adapt<JobApplicationRespons>();
    }
    public async Task<JobApplicationRespons?> GetJobApplicationByIdAsync(string userId, int id, CancellationToken cancellationToken)
    {
        var jobApplication = await _context.JobApplications
            .Include(ja => ja.ApplicationUser)
            .FirstOrDefaultAsync(ja => ja.Id == id && ja.ApplicationUserId == userId, cancellationToken);

        return jobApplication?.Adapt<JobApplicationRespons>();
    }

    public async Task<List<JobApplicationRespons>> GetJobApplicationsAsync(string userId)
    {
        return await _context.JobApplications
            .Where(ja => ja.ApplicationUserId == userId)
            .ProjectToType<JobApplicationRespons>()
            .ToListAsync();
    }

    public async Task DeleteJobApplicationAsync(int jobApplicationId, CancellationToken cancellationToken)
    {
        var jobApplication = await _context.JobApplications.FindAsync(jobApplicationId);
        if (jobApplication != null)
        {
            var Url = jobApplication.AttachmentUrl;
            FileHelpers.DeleteFile(Url, "files", _env);
            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task UpdateJobApplicationAsync(int Id, JobApplicationRequest jobApplicationRequest, CancellationToken cancellationToken)
    {
        var jobApplication = _context.JobApplications.FirstOrDefault(j => j.Id == Id);

        FileHelpers.DeleteFile(jobApplication.AttachmentUrl, "files", _env);
        jobApplication.AttachmentUrl = await FileHelpers.SaveFileAsync(jobApplicationRequest.Attachment, "files", _accessor, _env);
        jobApplication.Status = jobApplicationRequest.Status;
        jobApplication.ApplicationDate = jobApplicationRequest.ApplicationDate;
        jobApplication.ApplicationSource = jobApplicationRequest.ApplicationSource;
        jobApplication.CompanyName = jobApplicationRequest.CompanyName;
        jobApplication.JobTitle = jobApplicationRequest.JobTitle;
        jobApplication.Notes = jobApplicationRequest.Notes;

        await _context.SaveChangesAsync(cancellationToken);
    }

}
