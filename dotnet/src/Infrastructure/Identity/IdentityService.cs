using Dotland.DotCapital.WebApi.Application.Common.Interfaces;
using Dotland.DotCapital.WebApi.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Dotland.DotCapital.WebApi.Infrastructure.Identity;

public class IdentityService(
    // UserManager<ApplicationUser> userManager,
    // IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
    // IAuthorizationService authorizationService
    )
    : IIdentityService
{
    public Task<string> GetUserNameAsync(string userId)
    {
        // var user = await userManager.FindByIdAsync(userId);
        //
        // return user?.UserName;
        
        // if(string.IsNullOrWhiteSpace(userId)) return Task.FromResult<string?>(null);
        
        return Task.FromResult<string>("Test");
    }

    public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        // var user = new ApplicationUser
        // {
        //     UserName = userName,
        //     Email = userName,
        // };
        //
        // var result = await userManager.CreateAsync(user, password);
        //
        // return (result.ToApplicationResult(), user.Id);
        
        return Task.FromResult((Result.Success(), userName));
    }

    public Task<bool> IsInRoleAsync(string userId, string role)
    {
        // var user = await userManager.FindByIdAsync(userId);
        //
        // return user != null && await userManager.IsInRoleAsync(user, role);
        
        return Task.FromResult(true);
    }

    public Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        // var user = await userManager.FindByIdAsync(userId);
        //
        // if (user == null)
        // {
        //     return false;
        // }
        //
        // var principal = await userClaimsPrincipalFactory.CreateAsync(user);
        //
        // var result = await authorizationService.AuthorizeAsync(principal, policyName);
        //
        // return result.Succeeded;
        
        return Task.FromResult(true);
    }

    public Task<Result> DeleteUserAsync(string userId)
    {
        // var user = await userManager.FindByIdAsync(userId);
        //
        // return user != null ? await DeleteUserAsync(user) : Result.Success();
        
        return Task.FromResult(Result.Success());
    }

    public Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        // var result = await userManager.DeleteAsync(user);
        //
        // return result.ToApplicationResult();
        return Task.FromResult(Result.Success());
    }
}
