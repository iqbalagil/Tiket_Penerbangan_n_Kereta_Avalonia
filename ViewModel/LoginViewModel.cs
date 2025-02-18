
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.ViewModel
{
    public partial class LoginViewModel : ValidationUsingDataAnnotationsViewModel
    {
        private readonly ILoginService _loginService;
        private string _email;
        private string _password;
        private Window? _currentWindow;
        
        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            var result = await _loginService.Auth(Email, Password);
            if (result.IsAuthenticated)
            {
                if (Avalonia.Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApplication)
                {
                    Window? window = desktopApplication.Windows.FirstOrDefault(w => w.IsActive);
                    window?.Hide();
                    var windows = new WindowDashboardView();
                    windows.Show();
                }
            }
        }

        [RelayCommand]
        public void Register()
        {
            if (Avalonia.Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApplication)
            {
                Window? windows = desktopApplication.Windows.FirstOrDefault(w => w.IsActive);
                windows?.Hide();
                var window = new RegisterView();
                window.Show();
            }

        }



    }
}
