using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

namespace Tiket_Penerbangan_n_Kereta;

public partial class App : Application
{ 
    public IHost? AppHost { get;  private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            
            .ConfigureServices((context, services) =>
            {
                services.AddDatabase(@"DataSource=E:\Tiket_penerbangan_UKK\Tiket_Penerbangan_n_Kereta\Penerbangan.db")
                    .AddServices()
                    .AddViewModels()
                    .AddApplication()
                    .AddView();

            }).Build();

        var dataValidationPluginsRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        foreach (var plugin in dataValidationPluginsRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = AppHost.Services.GetRequiredService<LoginView>();
        }
        
        base.OnFrameworkInitializationCompleted();
    }
}