
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel
{
    public partial class LoginViewModel : ValidationUsingDataAnnotationsViewModel
    {
        private readonly AuthState _authState;
        private readonly ILoginService _loginService;
        private readonly INavigationService _navigation;

        public Penumpang? LoggedInUser => _authState.CurrentUser;
        
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
                OnPropertyChanged(nameof(LoggedInUser));
                _navigation.NavigateToAny(new WindowDashboardView());
            }
        }

        [RelayCommand]
        public void Register()
        {
            _navigation.NavigateToAny(new RegisterView());
        }

    }
}
