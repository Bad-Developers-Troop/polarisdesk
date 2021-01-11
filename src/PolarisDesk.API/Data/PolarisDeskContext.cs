
using Microsoft.EntityFrameworkCore;

namespace PolarisDesk.API.Data
{
    public class PolarisDeskContext : DbContext
    {
        public PolarisDeskContext(DbContextOptions<PolarisDeskContext> options) : base(options)
        {
        }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }



    }
}