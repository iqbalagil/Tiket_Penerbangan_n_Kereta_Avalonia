
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;
using Tiket_Penerbangan_n_Kereta.Services;
using System;
using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive;
using Microsoft.Extensions.DependencyInjection;
using DynamicData.Binding;
using Splat;

namespace Tiket_Penerbangan_n_Kereta.ViewModel
{
    public partial class LoginViewModel : ViewModels, IRoutableViewModel
    {
        private readonly AuthState _authState;
        public IScreen HostScreen { get; }
        public string UrlPathSegment => "Login";

        private string _email;
        
        [Required(ErrorMessage = "Email is required")]
        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        private string _password;

        [Required(ErrorMessage = "Password is required")]
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

       public ReactiveCommand<Unit, IRoutableViewModel> NavigateToRegister { get; }


        public LoginViewModel(IScreen screen) 
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            if(HostScreen == null) throw new Exception ("Host screen is null");

            NavigateToRegister = ReactiveCommand.CreateFromObservable(() =>
            HostScreen.Router.Navigate.Execute(new RegisterViewModel(HostScreen))
            );

        }


        [RelayCommand]
        public async Task LoginAsync()
        {
            
                var result = await _authState.LoginAsync(Email, Password);

                if (result != null)
                {

                }
        }

    }

    public class CurrentUser
    {
        public static int Id { get; set; }
    }
    
}
