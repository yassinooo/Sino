using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FishingApp.Data;
using Microsoft.EntityFrameworkCore;
using FishingApp.Business;

namespace FishingApp.UI
{
    public partial class App : Application
    {
        internal IHost _host;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, cfg) =>
                {
                    cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var conn = context.Configuration.GetConnectionString("DefaultConnection");
                    services.AddDbContext<FishingDbContext>(options => options.UseSqlServer(conn));

                    // Repositories
                    services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

                    // Business services
                    services.AddScoped<IBidService, BidService>();
                    services.AddScoped<ICatchService, CatchService>();
                    services.AddScoped<IBuyerService, BuyerService>();

                    // ViewModels and Windows
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<BuyersViewModel>();
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<BuyersWindow>();
                })
                .Build();

            _host.Start();

            // Initialize DB and seed data so app works without manual migrations
            DbInitializer.Initialize(_host.Services);

            var main = _host.Services.GetRequiredService<MainWindow>();
            main.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host?.Dispose();
            base.OnExit(e);
        }
    }
}
