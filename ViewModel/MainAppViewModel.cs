using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Tiket_Penerbangan_n_Kereta.ViewModel
{
    public class MainAppViewModel : ViewModels, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();

        public MainAppViewModel()
        {
            Locator.CurrentMutable.Register(() => new AppViewLocator(), typeof(IViewLocator));

            Router.Navigate.Execute(new LoginViewModel(this));
        }

    }
}
