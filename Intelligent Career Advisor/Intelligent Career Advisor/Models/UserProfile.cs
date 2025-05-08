namespace Intelligent_Career_Advisor.Models;

public class UserProfile
{
    public int Id { get; set; }

    public string ApplicationUserId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }

    public ICollection<string> SoftSkills { get; set; }
    public ICollection<string> HardSkills { get; set; }

    public string? ProfilePictureUrl { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int ExperienceYears { get; set; }

    public string Degree { get; set; }
    public string University { get; set; }
    public int? GraduationYear { get; set; }
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public decimal? SalaryExpectations { get; set; }

    public string? ResumeFileUrl{ get; set; }
    //public string LinkedInUrl { get; set; }
    //public string GitHubUrl { get; set; }
    //public string PersonalWebsiteUrl { get; set; }
}
