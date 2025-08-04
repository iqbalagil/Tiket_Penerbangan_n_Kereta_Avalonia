using System;
using System.Reactive;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using Splat;
using Tiket_Penerbangan_n_Kereta.Services;

namespace Tiket_Penerbangan_n_Kereta.ViewModel;

public partial class RegisterViewModel : ReactiveValidationObject, IRoutableViewModel, IValidatableViewModel
{
    AuthState _authState;
    public IScreen HostScreen { get; }
    public string UrlPathSegment => "Register";
    public ReactiveCommand<Unit, IRoutableViewModel> NavigateBack { get; }

    public ValidationContext validationContext { get; } = new ValidationContext();

    private string _email = string.Empty;

    private string _password = string.Empty;

    private string _username = string.Empty;

    private string _verifyPassword = string.Empty;


    public RegisterViewModel(IScreen screen, AuthState auth)
    {
        _authState = auth;

        HostScreen = screen;

        NavigateBack = ReactiveCommand.CreateFromObservable( () =>
        
             HostScreen!.Router.NavigateBack.Execute()
        );
    }

    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }
    public string Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    public string VerifyPassword
    {
        get => _verifyPassword;
        set => this.RaiseAndSetIfChanged(ref _verifyPassword, value);
    }


    [RelayCommand]
    public async Task RegisterAsync()
    {
        this.ValidationRule(
              vm => vm.Username,
              username => !string.IsNullOrWhiteSpace(username),
              "Username is required."
          );
        this.ValidationRule(
            vm => vm.Email,
            email => !string.IsNullOrWhiteSpace(email) && MyRegex.EmailRegex().IsMatch(email) ,
            "Email is required and must be a valid email address.");

        this.ValidationRule(
            vm => vm.Password,
            Password => !string.IsNullOrWhiteSpace(Password),
            "Password is required and must match the verify password.");

        IObservable<bool> passwordConfirm =
            this.WhenAnyValue(
                x => x.Password,
                x => x.VerifyPassword,
                (password, confirmation) => !string.IsNullOrWhiteSpace(confirmation) &&
                password == confirmation);

        this.ValidationRule(
            vm => vm.VerifyPassword,
            passwordConfirm,
            "Verify Password is required and must match the password.");


        if (validationContext.IsValid)
        {
            //var result = await _authState.RegisterAsync(_username, _email, _password);

            //if (result != null)
            //{
            //    HostScreen.Router.Navigate.Execute(App.AppHost.Services.GetRequiredService<LoginViewModel>());
            //}

        }


    }
}