using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApplicationUser = Jlw.Extensions.Identity.Stores.ModularBaseUser<long>;

namespace TestMvcWebApp.Controllers
{
    public class ImpersonateController : Controller
    {
        private readonly ILogger<ImpersonateController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ImpersonateController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<ImpersonateController> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("~/impersonate/{userId}")]
        public async Task<IActionResult> ImpersonateUser(string userId)
        {
            //var currentUserId = User.GetUserId();

            var impersonatedUser = await _userManager.FindByIdAsync(userId);

            if (impersonatedUser == null)
                return Redirect("~/Identity/Account/Login");

            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(impersonatedUser);

            //userPrincipal.Identities.First().AddClaim(new Claim("IsImpersonating", "true"));

            // sign out the current user
            await _signInManager.SignOutAsync();

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, userPrincipal);


            return RedirectToAction("Index", "Home");
        }

    }
}
