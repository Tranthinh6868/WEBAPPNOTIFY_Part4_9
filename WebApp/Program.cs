using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<SiteProvider>();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<IdentityOptions>(p=>{
    p.Password.RequireNonAlphanumeric = false;
    p.Password.RequireUppercase = false;
    p.Password.RequireLowercase = false;
    p.Password.RequiredLength = 3;
});
builder.Services.AddDbContext<WebStoreContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("WebStore")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<WebStoreContext>().AddDefaultTokenProviders();
builder.Services.AddMvc();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
