
namespace Intelligent_Career_Advisor.Abstractions;

public static class ResultExtensions
{
    public static ObjectResult ToProblem(this Result result)
    {
        var code = result.Error.StatusCodes;
        var problem = Results.Problem(statusCode: code);
        var problemDetails = problem.GetType().GetProperty(nameof(ProblemDetails))!.GetValue(problem) as ProblemDetails;

        problemDetails!.Extensions = new Dictionary<string, object?>
        {
            {
                "errors",
                new[]
                {
                    result.Error.Code,
                    result.Error.Description
                }
            }
        };
        return new ObjectResult(problemDetails);
    }
}
