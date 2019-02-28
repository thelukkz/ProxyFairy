using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProxyFairy.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()                   
                    .BuildServiceProvider();

                services.AddDbContext<Core.Model.AppIdentityDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryAppDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var builtServiceProvider = services.BuildServiceProvider();

                using (var scope = builtServiceProvider.CreateScope())
                {                  
                    var scopedServices = scope.ServiceProvider;                   
                    var appDb = scopedServices.GetRequiredService<Core.Model.AppIdentityDbContext>();

                    appDb.Database.EnsureCreated();
                }
            });
        }
    }
}
