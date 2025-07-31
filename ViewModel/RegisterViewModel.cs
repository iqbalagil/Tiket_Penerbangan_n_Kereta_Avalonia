using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;
using Splat;
using Tiket_Penerbangan_n_Kereta.Services;

namespace Tiket_Penerbangan_n_Kereta.ViewModel;

public partial class RegisterViewModel : ViewModels, IRoutableViewModel
{
    AuthState _authState;
    public IScreen HostScreen { get; }
    public string UrlPathSegment => "Register";
    public ReactiveCommand<Unit, IRoutableViewModel> NavigateBack { get; }

    public string _email;

    public string _password;

    private string _username;

    private string _verifyPassword;


    public RegisterViewModel(IScreen screen, AuthState auth)
    {
        _authState = auth;

        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        if (HostScreen == null) throw new Exception("Host screen is null");

        NavigateBack = ReactiveCommand.CreateFromObservable( () =>
        
             HostScreen.Router.NavigateBack.Execute()
        );
    }

    [Required]
    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    [Required]
    public string Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }

    [Required]
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Password and Confirmation Password must match.")]
    public string VerifyPassword
    {
        get => _verifyPassword;
        set => this.RaiseAndSetIfChanged(ref _verifyPassword, value);
    }


    [RelayCommand]
    public async Task RegisterAsync()
    {
        
            var result = await _authState.RegisterAsync(_username, _email, _password);
            if (result != null)
            {
               
            }

    }
}