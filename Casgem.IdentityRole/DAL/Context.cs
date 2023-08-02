using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Casgem.IdentityRole.DAL
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = DESKTOP-13123BI; Initial Catalog = CasgemDbRole; Integrated Security = true;");
		}

        public DbSet<Product> Products { get; set; }
    }
}