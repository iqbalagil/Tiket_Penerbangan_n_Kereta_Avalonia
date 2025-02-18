using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta;

public partial class LoginView : Window
{
    public LoginView()
    {
        InitializeComponent();
        DataContext = ((App)Application.Current).AppHost.Services.GetRequiredService<LoginViewModel>();
    }
}