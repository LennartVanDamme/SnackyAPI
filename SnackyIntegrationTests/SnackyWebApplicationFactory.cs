using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SnackyAPI.Repositories;
using System;
using System.Data.Common;
using System.Linq;
using Testcontainers.MsSql;

namespace SnackyAPIIntegrationTests
{
    public class SnackyWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer msSqlContainer = new MsSqlBuilder()
            .Build();

        public async Task InitializeAsync()
        {
            await msSqlContainer.StartAsync();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services => 
            {
                services.RemoveAll(typeof(SnackyDbContext));

                services.AddDbContext<SnackyDbContext>((container, options) =>
                {
                    options.UseSqlServer(msSqlContainer.GetConnectionString());
                });

                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope()) 
                {
                    var scopedServices = scope.ServiceProvider;
                    using(var dbContext = scopedServices.GetRequiredService<SnackyDbContext>())
                    {
                        dbContext.Database.EnsureDeleted();
                        dbContext.Database.EnsureCreated();
                        dbContext.Database.Migrate();
                    }
                }

            });

            builder.UseEnvironment("Development");
        }

        public new async Task DisposeAsync()
        {
            await msSqlContainer.StopAsync();
        }
    }
}
