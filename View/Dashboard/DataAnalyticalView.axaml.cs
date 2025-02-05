using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.View.Dashboard;

public partial class DataAnalyticalView : UserControl
{
    public DataAnalyticalView()
    {
        InitializeComponent();
        DataContext = new DataAnalyticalViewModel();
    }
}