using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using PolarisDesk.Models.Days;
using PolarisDesk.Models.Requests;
using PolarisDesk.Models.Stampings;
using PolarisDesk.Models.Users;
using stampingApi.Models.Users;

namespace PolarisDesk.API.Data
{
    public class PolarisDeskContext : DbContext
    {
        public PolarisDeskContext(DbContextOptions<PolarisDeskContext> options)
            : base(options)
        {
        }

        public DbSet<Stamping> Stampings { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Request> Requests { get; set; }
        public DbSet<StampingType> StampingTypes { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<UserProfile> UsersProfile { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }



    }
}