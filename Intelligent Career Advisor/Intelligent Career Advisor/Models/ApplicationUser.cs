
namespace Intelligent_Career_Advisor.Models;

public class ApplicationUser: IdentityUser
{
    
    public string FullName { get; set; } = string.Empty;
    public UserGender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }

    // Navigation property for one-to-one relationship with UserProfile.
    public virtual UserProfile Profile { get; set; }

    // Other Identity-specific properties can remain here.
    // Additionally, the navigation properties for related collections can still be included:

    public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
    
    public ICollection<JobApplication> JobApplications { get; set; } = [];
  
}
