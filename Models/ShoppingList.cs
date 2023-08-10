namespace MVCCore6App.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted{ get; set; }
        public int AppUserId { get; set; }
        public ICollection<ShoppingListItem>? Items { get; set; }
    }
}
