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
            builder.ApplyConfiguration(new ContractConfiguration());
            builder.ApplyConfiguration(new MobAppConfiguration());
            builder.ApplyConfiguration(new SlotConfiguration());
            builder.ApplyConfiguration(new LogGatewayConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<AppParameter> AppParameters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<MobApp> MobApps { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<LogGateway> LogsGateway { get; set; }
     }
}
