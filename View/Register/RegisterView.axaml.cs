using Avalonia;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta;

public partial class RegisterView : Window
{
    public RegisterView()
    {
        InitializeComponent();
        DataContext = ((App)Application.Current).AppHost.Services.GetRequiredService<RegisterViewModels>();
    }
}