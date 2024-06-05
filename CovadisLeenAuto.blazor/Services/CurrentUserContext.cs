using DemoCovadis.Shared.Interfaces;
using DemoCovadis.Shared.Constants;
using DemoCovadis.Blazor.Services;

namespace DemoCovadis.Blazor.Services;

public class CurrentUserContext : ICurrentUserContext
{
    public ICurrentUserContext.CurrentUser User { get; set; }

    public bool IsAuthenticated { get; set; }

    public CurrentUserContext(DemoCovadisAuthenticationStateProvider authenticationStateProvider)
    {
        authenticationStateProvider.AuthenticationStateChanged += (state) =>
        {
            var authState = state.Result;
            IsAuthenticated = authState.User.Identity?.IsAuthenticated ?? false;
            if (IsAuthenticated == true)
            {
                var claims = authState.User;
                var id = claims.FindFirst(Claims.Id)!.Value;
                var naam = claims.FindFirst(Claims.Naam)!.Value;
                var email = claims.FindFirst(Claims.Email)!.Value;
                var roles = claims.FindAll(Claims.Role).Select(r => r.Value).ToList();
                User = new ICurrentUserContext.CurrentUser(int.Parse(id), naam, email, roles);
            }
        };
    }

    public bool IsInRole(string roleName)
    {
        return User.Roles.Contains(roleName);
    }
}