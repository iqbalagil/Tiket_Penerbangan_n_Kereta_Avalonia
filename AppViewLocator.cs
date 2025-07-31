using ReactiveUI;
using System;
using Splat;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta
{
    public class AppViewLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {
            MainAppViewModel context => new MainAppView { DataContext = context },
            LoginViewModel context => new LoginView { DataContext = context },
            RegisterViewModel context => new RegistrationView { DataContext = context},
            _ => throw new ArgumentNullException(nameof(viewModel))
           
        };

    }
}
