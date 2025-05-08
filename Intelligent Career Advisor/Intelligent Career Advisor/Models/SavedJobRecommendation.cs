namespace Intelligent_Career_Advisor.Models;

public class SavedJobRecommendation
{
    public int Id { get; set; }
    public string JobTitle { get; set; }
    public string CompanyName { get; set; }
    public string JobType { get; set; } // e.g., Full-time, Part-time, Contract
    public string Location { get; set; }
    public string JobLevel { get; set; } // For example: Entry-Level, Mid-Level, Senior, etc.
    public string SalaryRange { get; set; } // This could be formatted as needed
    public string CompanyType { get; set; }  // Examples: Startup, Corporation, Government, etc.
    public string ApplicationLink { get; set; }
    public DateTime SavedDate { get; set; }

    // Foreign key to ApplicationUser
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}
