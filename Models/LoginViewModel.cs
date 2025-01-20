using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Services;

namespace Tiket_Penerbangan_n_Kereta.Models
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly ILoginService _loginService;
        [ObservableProperty] private string _username;
        [ObservableProperty] private string _password;
        [ObservableProperty] private string _loginMessage;

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            var result = await _loginService.Auth(Username, Password);

        }
    }
}
