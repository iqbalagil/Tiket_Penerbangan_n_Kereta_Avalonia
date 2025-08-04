using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using System.Reactive.Disposables;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta;

public partial class LoginView : ReactiveUserControl<LoginViewModel>
{
    public LoginView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            this.BindCommand(ViewModel, vm=> vm.NavigateToRegister, vm=> vm.NavigateButtonRegister)
            .DisposeWith(disposables);

            this.Bind(ViewModel, vm => vm.Email, view => view.Email.Text)
            .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.Password, view => view.Password.Text)
            .DisposeWith(disposables);

            //this.BindValidation(ViewModel, vm => vm.Email, view => view.EmailError.Text)
            //.DisposeWith(disposables);
            //this.BindValidation(ViewModel, vm => vm.Password, view => view.PasswordError.Text)
            //.DisposeWith(disposables);

        });
        AvaloniaXamlLoader.Load(this);
    }
}