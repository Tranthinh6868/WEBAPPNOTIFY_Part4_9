
using System.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;
public class WebStoreContext : IdentityDbContext
{
    public WebStoreContext(DbContextOptions options) : base(options)    {
        
    }
}