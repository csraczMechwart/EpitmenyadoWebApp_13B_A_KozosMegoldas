using EpitmenyadoWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EpitmenyadoWebApp.Data
{
	public class EpitmenyadoDbContext : DbContext
	{
        public EpitmenyadoDbContext(DbContextOptions<EpitmenyadoDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Epitmeny> Epitmenyek { get; set; }
    }
}
