using Microsoft.EntityFrameworkCore;
 
namespace Dojo_League.Models
{
    public class DojoLeagueContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DojoLeagueContext(DbContextOptions<DojoLeagueContext> options) : base(options) { }

         public DbSet<Ninja> ninjas { get; set; }
         public DbSet<Dojo> dojos { get; set; }
    }
}