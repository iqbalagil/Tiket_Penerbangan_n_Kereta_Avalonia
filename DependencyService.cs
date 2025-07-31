using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;
using Tiket_Penerbangan_n_Kereta.View.Dashboard.Maskapai;
using Tiket_Penerbangan_n_Kereta.View.Dashboard.Pemesanan;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;
//using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Maskapai;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;
using Tiket_Penerbangan_n_Kereta.View;
using ReactiveUI;

namespace Tiket_Penerbangan_n_Kereta
{
    public static class DependencyService
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            //services.AddScoped<ViewLocator>();
            services.AddScoped<ValidationUsingDataAnnotationsViewModel>();
            services.AddSingleton<IViewLocator, AppViewLocator>();
            services.AddSingleton<AuthState>();
            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            //services.AddScoped<MainMaskapaiViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<ViewModelBase>();
            services.AddTransient<CreateMaskapaiViewModel>();
            services.AddTransient<MaskapaiViewModel>();
            services.AddTransient<PemesananPesawatViewModel>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<UserInterfaceViewModel>();
            services.AddTransient<MainAppViewModel>();
            return services;
        }

        public static IServiceCollection AddView(this IServiceCollection services)
        {
            services.AddTransient<MainMaskapaiView>();
            services.AddTransient<PemesananPesawatView>();
            services.AddTransient<UserInterfaceView>();
            services.AddTransient<LoginView>();
            services.AddTransient<RegistrationView>();
            services.AddTransient<MaskapaiView>();
            services.AddTransient<CreateMaskapaiView>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<WindowDashboardView>();
            services.AddSingleton<IScreen, MainAppViewModel>();
            services.AddSingleton<MainAppView>();
            services.AddSingleton<App>();

            return services;
        }
    }
}
