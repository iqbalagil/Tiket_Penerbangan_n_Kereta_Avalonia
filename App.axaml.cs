using System.Linq;
using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Splat;
namespace Tiket_Penerbangan_n_Kereta;

public partial class App : Application
{

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

    }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
         .ConfigureAppConfiguration((context, config) =>
         {
             config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
         })

         .ConfigureServices((context, services) =>
         {
             services.AddDatabase(@"DataSource=E:\Project\PenerbanganApplication\Penerbangan.db")
                 .AddServices()
                 .AddViewModels()
                 .AddApplication()
                 .AddView();

         }).Build();
    }

    public override void OnFrameworkInitializationCompleted()
    {

        var dataValidationPluginsRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        foreach (var plugin in dataValidationPluginsRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }

        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainAppView
            {
                DataContext = AppHost.Services.GetRequiredService<ViewModel.MainAppViewModel>()
            };
        }
        
        base.OnFrameworkInitializationCompleted();

    }
    public static IHost AppHost { get; set; }

}