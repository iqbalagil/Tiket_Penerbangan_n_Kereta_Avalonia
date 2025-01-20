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
    public partial class RegisterViewModels : ObservableObject
    {
        private readonly IRegisterService _registerService;
        [ObservableProperty] private string _username;
        [ObservableProperty] private string _password;
        [ObservableProperty] private string _email;
        [ObservableProperty] private string _verifyPassword;
        [ObservableProperty] private string _registerMessage;

        public RegisterViewModels(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [RelayCommand]
        public async Task RegisterAsync()
        {
            if (Password != VerifyPassword) return;
            var result = await _registerService.RegisterAsync(Username, Email, Password);
        }
    }
}
