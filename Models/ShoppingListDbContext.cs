using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCCore6App.Models
{
    public class ShoppingListDbContext : IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-72E80BJ;database=ShopListDB;integrated Security=true");
        }
        public DbSet<AppUser> appUsers{ get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
		public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
} 
