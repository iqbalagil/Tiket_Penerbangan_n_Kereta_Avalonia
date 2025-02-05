using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

namespace Tiket_Penerbangan_n_Kereta
{
    public static class DependencyService
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>

                options.UseSqlite(connectionString), ServiceLifetime.Scoped);
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<DataServicesApp>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ViewLocator>();
            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {            
            services.AddScoped<ViewModelBase>();
            services.AddScoped<PemesananPesawatViewModel>();
            services.AddScoped<DashboardViewModel>();
            services.AddScoped<RegisterViewModels>();
            services.AddScoped<LoginViewModel>();
            services.AddScoped<UserInterfaceViewModel>();
            return services;
        }

        public static IServiceCollection AddView(this IServiceCollection services)
        {
            services.AddScoped<PemesananPesawatView>();
            services.AddScoped<UserInterfaceView>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<WindowDashboardView>();
            return services;
        }
    }
}
