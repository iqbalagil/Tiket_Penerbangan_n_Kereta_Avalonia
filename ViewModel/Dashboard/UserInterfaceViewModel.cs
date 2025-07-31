using System.Collections.ObjectModel;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public class UserInterfaceViewModel : ViewModelBase
{
    private readonly ApplicationDbContext _context;
    private ObservableCollection<Penumpang> _data;

    public UserInterfaceViewModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public ObservableCollection<Penumpang> Data
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }
}