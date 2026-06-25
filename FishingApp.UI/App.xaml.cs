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
        private IHost _host;

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

                    // ViewModels and MainWindow
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();

            _host.Start();

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
