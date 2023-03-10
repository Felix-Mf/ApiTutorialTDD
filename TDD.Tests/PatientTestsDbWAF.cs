using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

namespace TDD.Tests
{
    public class PatientTestsDbWAF<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
    {

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<TEntryPoint>();
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services =>
           {
               // Remove the app's DbContext registration.
               var descriptor = services.SingleOrDefault(
                      d => d.ServiceType ==
                          typeof(DbContextOptions<DataContext>));

               if (descriptor != null)
               {
                   services.Remove(descriptor);
               }

               // Add DbContext using an in-memory database for testing.
               services.AddDbContext<DataContext>(options =>
                  {
                      // Use in memory db to not interfere with the original db.
                      options.UseInMemoryDatabase("PatientTestsTDD.db");
                  });
           });
        }
    }
}