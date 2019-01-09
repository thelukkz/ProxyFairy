using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProxyFairy.Core.Model.Configuration;

namespace ProxyFairy.Core.Model
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppParameterConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<AppParameter> AppParameters { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
