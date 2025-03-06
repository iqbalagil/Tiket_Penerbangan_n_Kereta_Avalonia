using Avalonia;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard.Pemesanan;

public partial class PemesananPesawatView : UserControl
{
    public PemesananPesawatView()
    {
        InitializeComponent();

        DataContext = ((App)Application.Current).AppHost.Services.GetRequiredService<PemesananPesawatViewModel>();
    }
}