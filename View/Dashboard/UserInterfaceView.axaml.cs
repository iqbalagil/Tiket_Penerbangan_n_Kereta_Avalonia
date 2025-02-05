using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard;

public partial class UserInterfaceView : UserControl
{
    public UserInterfaceView()
    {
        InitializeComponent();
        // DataContext = ((App)Application.Current).AppHost.Services.GetRequiredService<UserInterfaceViewModel>();
    }
}