using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore6App.Models;
using System.Data;

namespace MVCCore6App.Controllers
{
	public class ProductController : Controller
	{
		private readonly ShoppingListDbContext _context;
		public ProductController(ShoppingListDbContext context)
		{
			_context = context;
		}

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
		{
			List<Product> productsWithCategories = _context.Products.Include(p => p.Category).ToList();
			return View(productsWithCategories);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			List<Category> categories = _context.Categories.ToList();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public IActionResult Create(Product model)
		{
			if (ModelState.IsValid)
			{
				_context.Products.Add(model);
				_context.SaveChanges();
				return RedirectToAction("Index", "Product");
			}
			return View(model);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult Edit(int id)
		{

			var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			// Get the list of categories from your database or wherever you're storing them
			List<Category> categories = _context.Categories.ToList(); // Replace this with your actual logic to get categories

			ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);

			return View(product);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public IActionResult Edit(int id, Product model)
		{
			if (id != model.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_context.Update(model);
				_context.SaveChanges();
				return RedirectToAction("Index", "Product");
			}

			return View(model);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult Delete()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var product = await _context.Products.FindAsync(id);

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Product");
		}

	}
}
