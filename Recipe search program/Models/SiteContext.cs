using Microsoft.EntityFrameworkCore;

namespace Recipe_search_program.Models
{
    public class SiteContex : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public SiteContex(DbContextOptions<SiteContex> options)
            : base(options)
        {

        }
    }
}
