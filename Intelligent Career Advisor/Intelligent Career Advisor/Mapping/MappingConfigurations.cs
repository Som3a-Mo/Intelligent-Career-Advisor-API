

namespace Intelligent_Career_Advisor.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, ApplicationUser>()
            .Map(dest => dest.UserName, src => src.Email);

        config.NewConfig<ApplicationUser, UserProfileResponse>()
    .Map(dest => dest.ProfilePictureUrl, src => src.Profile != null ? src.Profile.ProfilePictureUrl : null)
    .Map(dest => dest.University, src => src.Profile != null ? src.Profile.University : "")
    .Map(dest => dest.City, src => src.Profile != null ? src.Profile.City : "")
    .Map(dest => dest.Country, src => src.Profile != null ? src.Profile.Country : "")
    .Map(dest => dest.Degree, src => src.Profile != null ? src.Profile.Degree : "")
    .Map(dest => dest.GraduationYear, src => src.Profile != null ? src.Profile.GraduationYear : null)
    .Map(dest => dest.ExperienceYears, src => src.Profile != null ? src.Profile.ExperienceYears : 0)
    .Map(dest => dest.JobTitle, src => src.Profile != null ? src.Profile.JobTitle : "")
    .Map(dest => dest.Company, src => src.Profile != null ? src.Profile.Company : "")
    .Map(dest => dest.SalaryExpectations, src => src.Profile != null ? src.Profile.SalaryExpectations : null)
    .Map(dest => dest.ResumeFileUrl, src => src.Profile != null ? src.Profile.ResumeFileUrl : null)
    .Map(dest => dest.HardSkills, src => src.Profile != null ? src.Profile.HardSkills : new List<string>())
    .Map(dest => dest.SoftSkills, src => src.Profile != null ? src.Profile.SoftSkills : new List<string>());





    }
}