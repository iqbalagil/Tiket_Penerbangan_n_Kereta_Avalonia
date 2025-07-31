using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
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
        });
        AvaloniaXamlLoader.Load(this);
    }
}