using System.Net.Http.Headers;

namespace MVCCore6App.Models
{
    public class ShoppingListItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? Note { get; set; }
        public bool IsPurchased { get; set; }
        public int ShoppingListId { get; set; }
        public Product Product { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
