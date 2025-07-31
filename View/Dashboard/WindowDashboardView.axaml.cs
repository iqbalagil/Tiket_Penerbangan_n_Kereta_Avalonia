using System;
using Avalonia;
using FluentAvalonia.UI.Windowing;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard;

public partial class WindowDashboardView : AppWindow
{
    public WindowDashboardView()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        var app = (App)Application.Current;
    }
}