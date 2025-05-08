

namespace Intelligent_Career_Advisor.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, ApplicationUser>()
            .Map(dest => dest.UserName, src => src.Email);

        config.NewConfig<ApplicationUser, UserProfileResponse>()
        .Map(dest => dest.ProfilePictureUrl, src => src.Profile.ProfilePictureUrl)
        .Map(dest => dest.University, src => src.Profile.University)
        .Map(dest => dest.City, src => src.Profile.City)
        .Map(dest => dest.Country, src => src.Profile.Country)
        .Map(dest => dest.Degree, src => src.Profile.Degree)
        .Map(dest => dest.GraduationYear, src => src.Profile.GraduationYear)
        .Map(dest => dest.ExperienceYears, src => src.Profile.ExperienceYears)
        .Map(dest => dest.JobTitle, src => src.Profile.JobTitle)
        .Map(dest => dest.Company, src => src.Profile.Company)
        .Map(dest => dest.SalaryExpectations, src => src.Profile.SalaryExpectations)
        .Map(dest => dest.ResumeFileUrl, src => src.Profile.ResumeFileUrl)
        .Map(dest => dest.HardSkills, src => src.Profile.HardSkills)
        .Map(dest => dest.SoftSkills, src => src.Profile.SoftSkills);




    }
}