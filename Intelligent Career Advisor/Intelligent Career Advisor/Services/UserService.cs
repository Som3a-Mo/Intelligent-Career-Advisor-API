

namespace Intelligent_Career_Advisor.Services;

public class UserService(
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor accessor,
    IWebHostEnvironment env,
    ApplicationContext context) : IUserService
    
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IHttpContextAccessor _accessor = accessor;
    private readonly IWebHostEnvironment _env = env;
    private readonly ApplicationContext _context = context;

    public async Task<Result<UserProfileResponse>> GetProfileAsync(string userId)
    {
        var user = await _userManager.Users
            .Where(x => x.Id == userId)
            .Include(x => x.Profile)
            .ProjectToType<UserProfileResponse>()
            .SingleAsync();
            
        return Result.Success(user);
    }

    public async Task AddProfileDataAsync(string userId, AddProfileDataRequest request)
    {
        var user = await _userManager.FindByIdAsync(userId);

        user.PhoneNumber = request.PhoneNumber;
        user.DateOfBirth = request.DateOfBirth;
        user.Gender = request.Gender;

        var profile = new UserProfile
        {
            City = request.City,
            Country = request.Country,
            Degree = request.Degree,
            University = request.University,
            GraduationYear = request.GraduationYear,
            JobTitle = request.JobTitle,
            ExperienceYears = request.ExperienceYears,
            Company = request.Company,
            HardSkills = request.HardSkills,
            SoftSkills = request.SoftSkills,
            SalaryExpectations = request.SalaryExpectations,
            ResumeFileUrl = await FileHelpers.SaveFileAsync(request.ResumeFile, "files", _accessor, _env),
            ProfilePictureUrl = await FileHelpers.SaveFileAsync(request.ProfilePicture, "images", _accessor, _env)
        };

        user.Profile = profile;

        await _userManager.UpdateAsync(user!);
    }



    public async Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request)
    {
        //var user = await _userManager.FindByIdAsync(userId);

        //user = request.Adapt(user);

        //await _userManager.UpdateAsync(user!);

        using var transaction = await _context.Database.BeginTransactionAsync();
        // Get the user including the profile in one query
        var user = await _userManager.Users
            .Include(x => x.Profile)
            .FirstOrDefaultAsync(x => x.Id == userId);

        // Save old URLs before updating
        var oldImageUrl = user.Profile?.ProfilePictureUrl;
        var oldResumeUrl = user.Profile?.ResumeFileUrl;

        // Update basic user properties
        user.FullName = request.FullName;
        user.PhoneNumber = request.PhoneNumber;
        user.DateOfBirth = request.DateOfBirth;
        user.Gender = request.Gender;

        await _userManager.UpdateAsync(user);

        // Upload new files first
        var newImageUrl = await FileHelpers.SaveFileAsync(request.ProfilePicture, "images", _accessor, _env);
        var newResumeUrl = await FileHelpers.SaveFileAsync(request.ResumeFile, "files", _accessor, _env);
        user.Profile.City = request.City;
        user.Profile.Country = request.Country;
        user.Profile.Degree = request.Degree;
        user.Profile.University = request.University;
        user.Profile.GraduationYear = request.GraduationYear;
        user.Profile.JobTitle = request.JobTitle;
        user.Profile.Company = request.Company;
        user.Profile.SalaryExpectations = request.SalaryExpectations;
        user.Profile.ExperienceYears = request.ExperienceYears;
        user.Profile.ProfilePictureUrl = (newImageUrl is null ? oldImageUrl : newImageUrl);
        user.Profile.ResumeFileUrl = (newResumeUrl is null ? oldResumeUrl: newResumeUrl);
        user.Profile.HardSkills = request.HardSkills;
        user.Profile.SoftSkills = request.SoftSkills;
        _context.UserProfiles.Update(user.Profile);

        //// Update skills
        //await _context.UserSkills
        //    .Where(x => x.ApplicationUserId == userId)
        //    .ExecuteDeleteAsync();

        //var userSkills = request.SkillNames.Zip(request.SkillTypes, (name, type) => new UserSkill
        //{
        //    ApplicationUserId = userId,
        //    SkillName = name,
        //    SkillType = type
        //}).ToList();

        //_context.UserSkills.AddRange(userSkills);

        // Save all changes
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        // Delete old files AFTER successful DB commit
        if (newImageUrl != null)
            FileHelpers.DeleteFile(oldImageUrl, "images", _env);
        if (newResumeUrl != null)
            FileHelpers.DeleteFile(oldResumeUrl, "files", _env);

        return Result.Success();
    }

    public async Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        var user = await _userManager.FindByIdAsync(userId);

        var result = await _userManager.ChangePasswordAsync(user!, request.CurrentPassword, request.NewPassword);

        if(result.Succeeded)
            return Result.Success();

        var error = result.Errors.First();

        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }
}