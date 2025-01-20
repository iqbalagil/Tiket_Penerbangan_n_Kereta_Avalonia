using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.Services;

namespace Tiket_Penerbangan_n_Kereta.Dashboard;

public partial class UserInterface : Window
{
    private readonly DataServicesApp _data;
    public UserInterface()
    {
        InitializeComponent();
        //_data = ((App)Application.Current).AppHost.Services.GetRequiredService<DataServicesApp>();
        //this.DataContext = _data;
        //LoadUsers();
    }

    private async void LoadUsers()
    {
        var users = await _data.GetUsersAsync();
    }
}