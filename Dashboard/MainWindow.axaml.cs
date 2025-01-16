using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using System.Reactive;
using System.Windows.Input;

namespace Tiket_Penerbangan_n_Kereta.Dashboard;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        this.DataContext = new MainWindowViewModel();
    }

}

