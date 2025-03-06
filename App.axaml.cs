using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tiket_Penerbangan_n_Kereta;

public class App : Application
{
    public IHost? AppHost { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) => { config.AddJsonFile("appsettings.json", true, true); })
            .ConfigureServices((context, services) =>
            {
                services.AddDatabase(@"DataSource=D:\Tiket_Penerbangan_n_Kereta_Avalonia\Penerbangan.db")
                    .AddServices()
                    .AddViewModels()
                    .AddApplication()
                    .AddView();
            }).Build();

        var dataValidationPluginsRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        foreach (var plugin in dataValidationPluginsRemove) BindingPlugins.DataValidators.Remove(plugin);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = AppHost.Services.GetRequiredService<LoginView>();

        base.OnFrameworkInitializationCompleted();
    }
}