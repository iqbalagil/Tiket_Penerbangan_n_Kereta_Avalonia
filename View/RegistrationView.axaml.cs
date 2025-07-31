using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta;

public partial class RegistrationView : ReactiveUserControl<RegisterViewModel>
{
    public RegistrationView()
    {
        InitializeComponent();
    }
}