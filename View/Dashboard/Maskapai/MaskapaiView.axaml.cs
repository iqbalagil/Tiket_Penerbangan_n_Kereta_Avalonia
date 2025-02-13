using Avalonia;
using Avalonia.Controls;
using Avalonia.Diagnostics;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard;

public partial class MaskapaiView : UserControl
{
    public MaskapaiView()
    {
        InitializeComponent();
        DataContext = ((App)Application.Current).AppHost.Services.GetRequiredService<MaskapaiViewModel>();
    }
}