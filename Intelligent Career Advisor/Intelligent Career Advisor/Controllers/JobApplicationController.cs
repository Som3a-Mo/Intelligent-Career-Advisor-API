
using Intelligent_Career_Advisor.Contracts.JobApplication;

namespace Intelligent_Career_Advisor.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize]
public class JobApplicationController(IJobApplicationService jobApplication) : ControllerBase
{
    private readonly IJobApplicationService _jobApplication = jobApplication;

    [HttpGet("")]
    public async Task<IActionResult> GetAllJobApplication()
    {
        var userId = User.GetUserId();
        var jobApplications = await _jobApplication.GetJobApplicationsAsync(userId!);
        return Ok(jobApplications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobApplicationById(int id, CancellationToken cancellation)
    {
        var userId = User.GetUserId();
        var jobApplication = await _jobApplication.GetJobApplicationByIdAsync(userId!, id, cancellation);
        return Ok(jobApplication);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateJobApplication([FromForm] JobApplicationRequest jobApplicationRequest, CancellationToken cancellation)
    {
       var jobApplication =  await _jobApplication.AddJobApplicationAsync(User.GetUserId()!, jobApplicationRequest, cancellation);
        return CreatedAtAction(nameof(GetJobApplicationById), new {id = jobApplication.Id}, jobApplication);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJobApplication(int id, [FromForm] JobApplicationRequest jobApplication, CancellationToken cancellation)
    {
        await _jobApplication.UpdateJobApplicationAsync(id, jobApplication, cancellation);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobApplication(int id, CancellationToken cancellation)
    {
        await _jobApplication.DeleteJobApplicationAsync(id, cancellation);
        return NoContent();
    }
}
