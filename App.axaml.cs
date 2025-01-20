using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tiket_Penerbangan_n_Kereta.Dashboard;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.Models;
using Tiket_Penerbangan_n_Kereta.Services;
using Material.Icons.Avalonia;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;

namespace Tiket_Penerbangan_n_Kereta;

public partial class App : Application
{
    public IHost AppHost { get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        AppHost = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            services.AddDatabase(@"Server=(local)\TIKEXPRESS;database=tiketPenerbangan;User ID=iqbal;Password=akuiqbal;
            TrustServerCertificate=True;Trusted_Connection=true")
            .AddServices()
            .AddViewModels()
            .AddApplication();

        }).Build();


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            desktop.MainWindow.DataContext = AppHost.Services.GetRequiredService<DataServicesApp>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}