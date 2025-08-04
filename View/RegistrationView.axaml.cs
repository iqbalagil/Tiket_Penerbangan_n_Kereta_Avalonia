using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive.Disposables;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta;

public partial class RegistrationView : ReactiveUserControl<RegisterViewModel>
{
    public RegistrationView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            //this.BindCommand(ViewModel, vm => vm.NavigateBack, view => view.NavigateButtonBack)
            //    .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.Username, view => view.Username.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.Email, view => view.Email.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.Password, view => view.Password.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.VerifyPassword, view => view.VeifyPassword.Text)
                .DisposeWith(disposables);
            //this.BindValidation(ViewModel, vm => vm.Username, view => view.UsernameError.Text)
            //    .DisposeWith(disposables);
            //this.BindValidation(ViewModel, vm => vm.Email, view => view.EmailError.Text)
            //    .DisposeWith(disposables);
            //this.BindValidation(ViewModel, vm => vm.Password, view => view.PasswordError.Text)
            //    .DisposeWith(disposables);
        });
    }
}