using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization;

public class AuthorizationAge : AuthorizationHandler<MinAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
    {
        var DateOfBirthClaim = context
            .User
            .FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
        
        if (DateOfBirthClaim == null) return Task.CompletedTask;
        var DateOfBirth = Convert.ToDateTime(DateOfBirthClaim.Value);
        var UserAge = DateTime.Today.Year - DateOfBirth.Year;
        if(DateOfBirth > DateTime.Today.AddYears(-UserAge)) UserAge--;
        
        if(UserAge >= requirement.Age) context.Succeed(requirement);
        return Task.CompletedTask;
    }
}