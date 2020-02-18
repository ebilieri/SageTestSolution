using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Sage.Repository.Context;
using Sage.API;

namespace Sage.App.TestIntegration.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class TestingWebAppFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                var descriptor = services.SingleOrDefault(
                  d => d.ServiceType ==
                     typeof(DbContextOptions<SageContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                //var connectionString = "server=remotemysql.com;userid=iR0NzkGBth;password=CnwDkICNhl;database=iR0NzkGBth";

                //// Configurar context banco de dados
                //services.AddDbContext<SageContext>(option =>
                //        option.UseLazyLoadingProxies()
                //            .UseMySql(connectionString, m =>
                //                m.MigrationsAssembly("Sage.Repository")));

                var serviceProvider = new ServiceCollection()
                  .AddEntityFrameworkInMemoryDatabase()
                  .BuildServiceProvider();

                services.AddDbContext<SageContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<SageContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureCreated();
                        }
                        catch (Exception)
                        {
                            //Log errors or do anything you think it's needed
                            throw;
                        }
                    }
                }
            });
        }
    }
}
