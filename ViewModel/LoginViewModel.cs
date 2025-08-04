
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Services;
using ReactiveUI;
using System.Reactive;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using System.Text.RegularExpressions;
using ReactiveUI.Validation.States;
using System;
using System.Reactive.Linq;
using System.ComponentModel;
using System.Linq;
using System.Collections;
using System.Reactive.Disposables;

namespace Tiket_Penerbangan_n_Kereta.ViewModel
{
    public partial class LoginViewModel : ReactiveValidationObject, IRoutableViewModel, IValidatableViewModel
    {
        private  AuthState _authState;
        public IScreen HostScreen { get; }
        public string UrlPathSegment => "Login";

        public ValidationContext validationContext { get; } = new ValidationContext();

        private string _email = string.Empty;
        public string Email
        {
            get => _email; 
            set => this.RaiseAndSetIfChanged(ref _email, value); 
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToRegister { get; }

        public LoginViewModel(IScreen screen) 
        {
            _authState = App.AppHost.Services.GetRequiredService<AuthState>();

            HostScreen = screen;

            NavigateToRegister = ReactiveCommand.CreateFromObservable(() =>
            HostScreen!.Router.Navigate.Execute(new RegisterViewModel(HostScreen, _authState))
            );

        }


        [RelayCommand]
        public async Task LoginAsync()
        {

            this.ValidationRule(
                ViewModel => ViewModel.Email,
                email => !string.IsNullOrWhiteSpace(email),
                "Email field is required");

            this.ValidationRule(
                ViewModel => ViewModel.Email,
                email => !string.IsNullOrWhiteSpace(email) && MyRegex.EmailRegex().IsMatch(email),
                "Please enter a valid email address ('name@example.com')");

            this.ValidationRule(
                ViewModel => ViewModel.Password,
                password => !string.IsNullOrWhiteSpace(password),
                "Password field is required");

            if (validationContext.IsValid)
            {
                var result = await _authState.LoginAsync(Email, Password);

                if(result != null)
                {

                }

            }

        }

    }

    public static partial class MyRegex
    {
        [GeneratedRegex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase)]
        public static partial Regex EmailRegex();
    }

}
