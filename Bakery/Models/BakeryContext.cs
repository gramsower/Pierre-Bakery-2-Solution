using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Bakery.Models
{
  public class BakeryContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<FlavorItem> FlavorItems { get; set; }
    public BakeryContext(DbContextOptions options) : base(options) { }
  }
}