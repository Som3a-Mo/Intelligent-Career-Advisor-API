namespace Intelligent_Career_Advisor.Models;

public class JobApplicationReminder
{
    public int Id { get; set; }
    public DateTime ReminderDate { get; set; }
    public string Message { get; set; }

    // Foreign key to JobApplication
    public int JobApplicationId { get; set; }
    public JobApplication JobApplication { get; set; }
}
