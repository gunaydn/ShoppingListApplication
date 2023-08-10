using System.ComponentModel.DataAnnotations;

namespace MVCCore6App.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[Display(Name = "Category")]
		public int CategoryId { get; set; }
		public decimal Price { get; set; }

		[Display(Name = "Icon")]
		public string? ImageUrl { get; set; }
		public ICollection<ShoppingListItem>? ShoppingListItems { get; set; }
		public Category? Category { get; set; }
	}
}
