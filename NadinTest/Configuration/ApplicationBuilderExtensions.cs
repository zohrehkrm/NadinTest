using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NadinTest.Configuration.DataInitializer;
using NadinTest.Data;

namespace NadinTest.Configuration
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseHsts(this IApplicationBuilder app, IWebHostEnvironment env)
        {
              app.UseHsts();
        }

        public static void IntializeDatabase(this IApplicationBuilder app)
        {
            //Use C# 8 using variables
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>(); //Service locator

      
            dbContext.Database.Migrate();

            var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>().ToList();

            foreach (var dataInitializer in dataInitializers.OrderBy(x => x.order))
                dataInitializer.InitializeData();
        }
    }
}
