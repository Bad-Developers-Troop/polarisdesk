//using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using PolarisDesk.DataAccessLayer.Configurations;
using PolarisDesk.Models;
using PolarisDesk.Models.Days;
using PolarisDesk.Models.Requests;
using PolarisDesk.Models.Stampings;
using PolarisDesk.Models.Users;
using stampingApi.Models.Users;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisDesk.DataAccessLayer
{
    public class PolarisDeskContext : DbContext, IPolarisDeskContext
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
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public IQueryable<T> GetData<T>(bool trackingChanges = false) where T : class
        {
            var set = Set<T>();
            return trackingChanges ? set.AsTracking() : set.AsNoTracking();
        }

        public void Insert<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public Task SaveAsync()
        {
            return SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PolarisDeskContext).Assembly);
        }
    }
}