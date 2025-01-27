using Avalonia;
using FluentAvalonia.UI.Windowing;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tiket_Penerbangan_n_Kereta.ViewModel;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard;

public partial class WindowDashboardView : AppWindow  
{
    public WindowDashboardView()
    {
        InitializeComponent();
        TitleBar.ExtendsContentIntoTitleBar = true;
        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
#if DEBUG
        this.AttachDevTools();
#endif
        var app = (App)Application.Current;
        DataContext = app?.AppHost?.Services.GetRequiredService<DashboardViewModel>()
                      ?? throw new InvalidOperationException("AppHost or Services is not initialized.");

        //LoadUsers();
    }
    
    // private async void LoadUsers()
    // {
    //     var userService = ((App)Application.Current).AppHost.Services.GetRequiredService<DataServicesApp>();
    //     var users = await userService.GetUsersAsync();
    // }
    
    

}

