using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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

*/