using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.ViewModel;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard;

public partial class PemesananPesawatView : UserControl
{
    public PemesananPesawatView()
    {
        InitializeComponent();

        DataContext = ((App)Application.Current).AppHost.Services.GetRequiredService<PemesananPesawatViewModel>();
    }
}