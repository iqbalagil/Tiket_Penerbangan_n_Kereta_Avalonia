
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive.Disposables;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta;

public partial class MainAppView : ReactiveWindow<MainAppViewModel>
{
    public MainAppView()
    {
        InitializeComponent();

        //ViewModel = new MainAppViewModel();

        this.WhenActivated((disposable) =>
        {
            this.OneWayBind(ViewModel, vm => vm.Router, vm => vm.RoutedViewHost.Router)
            .DisposeWith(disposable);
        });
    }
}