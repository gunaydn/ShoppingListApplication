using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore6App.Models;
using MVCCore6App.ViewModels;

namespace MVCCore6App.Controllers
{
    public class ShoppingListItemController : Controller
    {
		private readonly ShoppingListDbContext _context;
        public ShoppingListItemController(ShoppingListDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public IActionResult Create(int id)
		{
            var viewModel = new ShoppingListItemCreateViewModel
            {
                ShoppingListId = id,
                AvailableProducts = _context.Products
            .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
            .ToList()
            };

            return View(viewModel);
        }

		[HttpPost]
        public IActionResult Create(ShoppingListItemCreateViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var shoppingListItem = new ShoppingListItem
                {
                    ShoppingListId = viewModel.ShoppingListId,
                    ProductId = viewModel.ProductId,
                    Quantity = viewModel.Quantity,
                    Note = viewModel.Note,
                    IsPurchased = false
                };

                _context.ShoppingListItems.Add(shoppingListItem);
                _context.SaveChanges();
                return RedirectToAction("Index","ShoppingList");
            }

            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }

            viewModel.AvailableProducts = _context.Products
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
                .ToList();

            return View(viewModel);
        }



    }
}
