
using Microsoft.EntityFrameworkCore;
using BPS_Shared.Models;

namespace BPS_API.Database
{
    public class BPS_dbcontext: DbContext
    {
        public BPS_dbcontext(DbContextOptions<BPS_dbcontext> options) : base(options)
        {
            //Database.EnsureDeleted();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}
