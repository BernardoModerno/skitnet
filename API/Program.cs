using System;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try 
                {
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


/*Comandos Utilizados
dotnet new sln
dotnet new webapi -o API
dotnet sln add API
dotnet sln list
dotnet run
dotnet dev-certs https
dotnet dev-certs https -t
dotnet watch run
dotnet tool install --global dotnet-ef --version 3.1.6
foi adicionado o microsoft.entityframeworkcore.design no nuget
dotnet ef migrations add InicialCreate -o Data/Migrations
dotnet ef database update
dotnet watch run
dotnet new classlib -o Core
dotnet new classlib -o Infrastructure
dotnet sln add Core
dotnet sln add Infrastructure
cd API
dotnet add reference ../Infrastructure
cd ..
cd Infrastructure
dotnet add reference ../Core
cd ..
dotnet restore
dotnet build
cd API
dotnet watch run
dotnet ef database drop -p Infrastructure -s API
dotnet ef migrations remove -p Infrastructure -s API
dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations
dotnet watch run
ctrl shift p -> open database

*/