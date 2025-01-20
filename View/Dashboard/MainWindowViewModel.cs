using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Reactive;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard
{

    public class MainWindowViewModel : ReactiveObject
    {
        WindowState _windowState;
        public ICommand MinimizeCommand { get; }
        public ICommand MaximizeCommand { get; }
        public ICommand ClosedCommand { get; }

        public ICommand ColorDynamic { get; }

        public MainWindowViewModel()
        {
            MinimizeCommand = ReactiveCommand.Create(() => WindowState = WindowState.Minimized);
            MinimizeCommand = ReactiveCommand.Create(() => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized);
            ClosedCommand = ReactiveCommand.Create(() => Environment.Exit(0));
            ColorDynamic = ReactiveCommand.Create(DynamicColor);

        }
        public WindowState WindowState
        {
            get => _windowState;
            set => this.RaiseAndSetIfChanged(ref _windowState, value);
        }

        public void DynamicColor()
        {
            Application.Current.Resources["PrimaryColor"] = new SolidColorBrush(Color.FromRgb(251, 251, 251));
            Application.Current.Resources["SecondayColor"] = new SolidColorBrush(Color.FromRgb(55, 140, 231));
            Application.Current.Resources["PrimaryColor2"] = new SolidColorBrush(Color.FromRgb(5, 117, 237));
            Application.Current.Resources["SecondaryColor2"] = new SolidColorBrush(Color.FromRgb(14, 16, 18));
            Application.Current.Resources["DarkenColorBlue"] = new SolidColorBrush(Color.FromRgb(6, 102, 204));
        }
    }
}
