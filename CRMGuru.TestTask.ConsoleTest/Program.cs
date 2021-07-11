using AutoMapper;
using CRMGuru.TestTask.DAL.Context;
using CRMGuru.TestTask.DAL.Repositories;
using CRMGuru.TestTask.Implementations.Profiles;
using CRMGuru.TestTask.Implementations.Services;
using CRMGuru.TestTask.Interfaces.Repositories;
using CRMGuru.TestTask.Interfaces.Services;
using CRMGuru.TestTask.WebApiClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
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
            services.AddDbContext<EFContext>(options => options.UseSqlServer(
                host.Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("CRMGuru.TestTask.DAL.MSSQL")));

            services.AddScoped<IDbRepository, EFRepositoty>();
            services.AddHttpClient<IWebRepository, WebRepository>(client => client.BaseAddress = new Uri(host.Configuration["RestCountries"]));

            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new CountryProfile()));

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
         
            services.AddScoped<IAddCountryService, AddCountryService>();
            services.AddScoped<ILoadContryService, LoadContryService>();
        }




        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();

           
            var loadContry = Hosting.Services.GetRequiredService<ILoadContryService>();

            var addCountry = Hosting.Services.GetRequiredService<IAddCountryService>();

            var country = loadContry.LoadContryWebApi("Poland").Result;

            //await addCountry.AddCountryDb(country);

           var i = await loadContry.LoadContryDb();


            Console.ReadKey();
        }
    }
}
