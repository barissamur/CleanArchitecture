using CleanArchitecture.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static CustomResult ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? CustomResult.Success()
            : CustomResult.Failure(result.Errors.Select(e => e.Description));
    }
}
