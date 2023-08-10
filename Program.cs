using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Extensions.DependencyInjection;
using MVCCore6App.Models;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShoppingListDbContext>();
builder.Services.AddIdentity<AppUser, IdentityRole<int>>().AddEntityFrameworkStores<ShoppingListDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireRole("Admin");
    });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    string roleAdmin = "Admin";
    if (!await roleManager.RoleExistsAsync(roleAdmin))
    {
        await roleManager.CreateAsync(new IdentityRole<int>(roleAdmin));
    }

    string roleUser = "User";
    if (!await roleManager.RoleExistsAsync(roleUser))
    {
        await roleManager.CreateAsync(new IdentityRole<int>(roleUser));
    }

}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
