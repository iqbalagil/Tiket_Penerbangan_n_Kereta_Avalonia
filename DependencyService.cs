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
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

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
            services.AddScoped<DataServicesApp>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ViewLocator>();
            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<MainMaskapaiViewModel>();
            services.AddScoped<DataAnalyticalViewModel>();
            services.AddScoped<ViewModelBase>();
            services.AddScoped<CreateMaskapaiViewModel>();
            services.AddScoped<MaskapaiViewModel>();
            services.AddScoped<PemesananPesawatViewModel>();
            services.AddScoped<DashboardViewModel>();
            services.AddScoped<RegisterViewModels>();
            services.AddScoped<LoginViewModel>();
            services.AddScoped<UserInterfaceViewModel>();
            return services;
        }

        public static IServiceCollection AddView(this IServiceCollection services)
        {
            services.AddScoped<MainMaskapaiView>();
            services.AddScoped<PemesananPesawatView>();
            services.AddScoped<DataAnalyticalView>();
            services.AddScoped<UserInterfaceView>();
            services.AddScoped<LoginView>();
            services.AddScoped<RegisterView>();
            services.AddScoped<MaskapaiView>();
            services.AddScoped<CreateMaskapaiView>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<WindowDashboardView>();
            return services;
        }
    }
}
