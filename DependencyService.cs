using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.Models;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;

namespace Tiket_Penerbangan_n_Kereta
{
    public static class DependencyService
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>

                options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<DataServicesApp>();
            services.AddSingleton<IRegisterService, RegisterService>();
            services.AddSingleton<ILoginService, LoginService>();
            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {

            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<RegisterViewModels>();
            services.AddSingleton<LoginViewModel>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<WindowDashboard>();
            return services;
        }
    }
}
