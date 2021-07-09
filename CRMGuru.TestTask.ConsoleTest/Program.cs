using CRMGuru.TestTask.DAL.Context;
using CRMGuru.TestTask.DAL.Repositories;
using CRMGuru.TestTask.Interfaces.Repositories;
using CRMGuru.TestTask.WebApiClient;
using CRMGuru.TestTask.WebApiClient.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.ConsoleTest
{
    class Program
    {
        private static IHost _hosting;

        public static IHost Hosting => _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        private static IHostBuilder CreateHostBuilder(string[] Args) => Host
            .CreateDefaultBuilder(Args)
            .ConfigureServices(ConfigureServices);


        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            //services.AddDbContext<EFContext>(options => options.UseSqlServer(
            //    host.Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("CRMGuru.TestTask.DAL.MSSQL")));
           
            services.AddScoped<IDbRepository, EFRepositoty>();
            services.AddHttpClient<IWebRepository, WebRepository>(client => client.BaseAddress = new Uri(host.Configuration["RestCountries"]));
        }




        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();

            var web = Hosting.Services.GetRequiredService<IWebRepository>();

           var k = await web.GetArray<RestcountriesModel>("moscow");


            Console.ReadKey();
        }
    }
}
