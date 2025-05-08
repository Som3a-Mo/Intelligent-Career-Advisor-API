namespace Intelligent_Career_Advisor.Models;

public class InterviewSessionFeedback
{
    public int Id { get; set; }
    public DateTime InterviewDate { get; set; }
    public int InterviewScore { get; set; } // E.g., score out of 100
    public string Strengths { get; set; } = string.Empty;
    public string Weaknesses { get; set; } = string.Empty;
    public string Suggestions { get; set; } = string.Empty;

    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}
