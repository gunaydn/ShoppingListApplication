using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore6App.ViewModels
{
    public class ShoppingListItemCreateViewModel
    {
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public List<SelectListItem>? AvailableProducts { get; set; }
    }
}
