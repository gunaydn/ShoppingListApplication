using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCore6App.Models;

namespace MVCCore6App.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly ShoppingListDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ShoppingListController(UserManager<AppUser> userManager,ShoppingListDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var shoppingLists = _context.ShoppingLists.Where(sl => sl.AppUserId.ToString() == userId).ToList();
            return View(shoppingLists);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ShoppingList model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                model.AppUserId = user.Id;
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult ToggleCompletionStatus(int listId, bool completed)
        {
            var shoppinglist = _context.ShoppingLists.Find(listId);

            shoppinglist.IsCompleted = !completed;
            _context.SaveChanges();

            return RedirectToAction("Index", "ShoppingList");
        }
    }
}
