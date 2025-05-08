

namespace Intelligent_Career_Advisor.Controllers;

[Route("me")]
[ApiController]
[Authorize]
public class AccountController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("")]
    public async Task<IActionResult> Info()
    {
        var result = await _userService.GetProfileAsync(User.GetUserId()!);

        return Ok(result.Value);
    }

    [HttpPost("add-profile-data")]
    public async Task<IActionResult> AddProfileData([FromForm] AddProfileDataRequest request)
    {
        await _userService.AddProfileDataAsync(User.GetUserId()!, request);
        return NoContent();
    }

    [HttpPut("info")]
    public async Task<IActionResult> Info([FromForm] UpdateProfileRequest request)
    {
        await _userService.UpdateProfileAsync(User.GetUserId()!, request);

        return NoContent();
    }

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var result = await _userService.ChangePasswordAsync(User.GetUserId()!, request);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}