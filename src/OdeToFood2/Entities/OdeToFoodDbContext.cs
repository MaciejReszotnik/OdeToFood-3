using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdeToFood2.Models;
using System.Linq;


namespace OdeToFood2.Entities
{
    public class OdeToFoodDbContext : IdentityDbContext<User>
    {
        public OdeToFoodDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
