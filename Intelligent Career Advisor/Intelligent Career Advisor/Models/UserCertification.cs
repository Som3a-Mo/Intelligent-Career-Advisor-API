namespace Intelligent_Career_Advisor.Models;

public class UserCertification
{
    public int Id { get; set; }
    public string CertificationName { get; set; }
    public string IssuingOrganization { get; set; }
    public DateTime? DateObtained { get; set; }
    public string CertificateUrl { get; set; } // For uploaded file path or online link

    // Foreign key to ApplicationUser
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}
