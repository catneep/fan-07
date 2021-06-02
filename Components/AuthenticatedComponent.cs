using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using fan_07.Models;

namespace fan_07.Components
{
    public class AuthenticatedComponent : ComponentBase
    {
        [Inject] IAuthorizationService AuthorizationService { get; set; }
        [Inject] UserManager<ApplicationUser> UserManager { get; set; }
        [CascadingParameter] protected Task<AuthenticationState> authenticationStateTask { get; set;}

        protected ClaimsPrincipal _principal = null;
        protected ApplicationUser _currentUser = null;
        protected async override Task OnInitializedAsync()
        {
            _principal = (await authenticationStateTask).User;
            _currentUser = await UserManager.GetUserAsync(_principal);
        }
    }
}