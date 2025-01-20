using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.Models;

namespace Tiket_Penerbangan_n_Kereta;

public partial class RegisterView : UserControl
{
    public RegisterView()
    {
        InitializeComponent();
        DataContext = ((App)Application.Current).AppHost.Services.GetRequiredService<RegisterViewModels>();
    }
}