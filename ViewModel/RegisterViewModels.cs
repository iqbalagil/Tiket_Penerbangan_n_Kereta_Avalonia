using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Services;

namespace Tiket_Penerbangan_n_Kereta.ViewModel
{
    public partial class RegisterViewModels : ValidationUsingDataAnnotationsViewModel
    {
        private readonly IRegisterService _registerService;
        private string _username;
        
        [Required]
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value, true);
        }
        
        private string _verifyPassword;

        [Required]
        public string VerifyPassword
        {
            get => _verifyPassword;
            set
            {
                if (string.IsNullOrEmpty(value)) ValidateProperty(_verifyPassword);
                else SetProperty(ref _verifyPassword, value, true);

            }
        }

        private string _registerMessage;

         public string RegisterMessage
         {
             get => _registerMessage;
             set => SetProperty(ref _registerMessage, value);
         }

         public IEnumerable<ValidationResult> GetValidationErrors()
         {
             return GetErrors();
         }

         public RegisterViewModels(IRegisterService registerService)
        {
            _registerService = registerService;
            GetValidationErrors();
        }

        [RelayCommand]
        public async Task RegisterAsync()
        {
            if (Password != VerifyPassword)
            {
                RegisterMessage = "Password and Verify Password must be the same";
            }

            if (await _registerService.UsernameExists(Username))
            {
                RegisterMessage = "Username already exists";
            }
            
            var result = await _registerService.RegisterAsync(Username, Email, Password);
            RegisterMessage = result ? "Registration Succed" : "Registration Failed";
        }

    }
}
