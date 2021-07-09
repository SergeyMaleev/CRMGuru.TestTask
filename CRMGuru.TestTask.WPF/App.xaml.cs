﻿using CRMGuru.TestTask.DAL.Context;
using CRMGuru.TestTask.DAL.Repositories;
using CRMGuru.TestTask.Interfaces.Repositories;
using CRMGuru.TestTask.WebApiClient;
using CRMGuru.TestTask.WPF.ViewModels;
using CRMGuru.TestTask.WPF.Views.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace CRMGuru.TestTask.WPF
{
    
    public partial class App
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
            
            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<IDbRepository, EFRepositoty>();
            services.AddHttpClient<IWebRepository, WebRepository>(client => client.BaseAddress = new Uri(host.Configuration["RestCountries"]));
        }

        protected override async void OnStartup(StartupEventArgs e)
        {           
            var host = Hosting;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(true);                     
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Hosting;
            base.OnExit(e);
            await host.StopAsync().ConfigureAwait(false);
        }
    }
}