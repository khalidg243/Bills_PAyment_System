using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BPS_API.Database
{
    public class BPS_dbcontextFactory : IDesignTimeDbContextFactory<BPS_dbcontext>
    {
        public BPS_dbcontext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BPS_dbcontext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BPS_Database;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BPS_dbcontext(optionsBuilder.Options);
        }
    }
}
