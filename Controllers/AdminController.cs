using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCore6App.Models;

namespace MVCCore6App.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShoppingListDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AdminController(ShoppingListDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppAdminRegister model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };

                if(!PasswordReq(model.Password))
                {
                    ModelState.AddModelError("Password", "Password must be at least 8 characters long and contains uppercased and lowercased letters, and numbers");
                    return View(model);
                }

                var result = await _userManager.CreateAsync(appUser,model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "Admin");
                    return RedirectToAction("RegisterSucceeded", "Admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult RegisterSucceeded()
        {
            return View();
        }

        private bool PasswordReq(string password)
        {
            return password.Length >= 8 &&
                password.Any(char.IsUpper) &&
                password.Any(char.IsLower) &&
                password.Any(char.IsDigit);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppAdminLogin model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                var admin = await _userManager.FindByNameAsync(model.UserName);
                if (admin != null && await _userManager.IsInRoleAsync(admin, "Admin"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "You do not have permission to log in.");
                    await _signInManager.SignOutAsync();
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
