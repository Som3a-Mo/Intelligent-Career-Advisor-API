namespace Intelligent_Career_Advisor.Models;

public class ResumeFeedback
{
    public int Id { get; set; }
    public int ResumeScore { get; set; } // E.g., score out of 100
    public string FeedbackDetails { get; set; }
    public DateTime FeedbackDate { get; set; }

    // Foreign key to ApplicationUser
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}
