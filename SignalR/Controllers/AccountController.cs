using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.Models;

namespace SignalR.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> CreateAdminUser()
        {
            var user = new IdentityUser { Email = "admin@cc.com", UserName = "admin" };
            var result = await userManager.CreateAsync(user, "QWE@rty123");
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            var command = new LoginCommand { ReturnUrl = returnUrl };
            return View(command);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {

            var result = await signInManager.PasswordSignInAsync(command.UserName, command.Password, true, false);
            if (result.Succeeded)
            {
                return Redirect(command.ReturnUrl ?? "/Home/Index");
            }
            ViewBag.Error = "Incorrect user name or password";
            return View(command);
        }

        public async Task<IActionResult> Signout()
        {

            await signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
