using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Reactive;
using System.Windows.Input;
using Tiket_Penerbangan_n_Kereta.Models;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        DataContext = ((App)Application.Current).AppHost.Services.GetRequiredService<MainWindowViewModel>();
        //LoadUsers();
    }

    private async void LoadUsers()
    {
        var userService = ((App)Application.Current).AppHost.Services.GetRequiredService<DataServicesApp>();
        var users = await userService.GetUsersAsync();
    }

}

