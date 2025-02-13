using System;
using System.Threading.Tasks;
using Azure.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class CreateMaskapaiViewModel : ViewModelBase, IPageViewModel
{
    [ObservableProperty] private string _maskapaiName = string.Empty;
    [ObservableProperty] private string _descMaskapai = string.Empty;

    private ApplicationDbContext _context;

    [RelayCommand]
    private async Task<bool> CreateMaskapai()
    {
        var newMaskapai = new TypeTransportasi
        {
            NamaType = _maskapaiName,
            Keterangan = _descMaskapai
        };

        _context.TypeTransportasi.Add(newMaskapai);

        await _context.SaveChangesAsync();
        return true;
    }

    [ObservableProperty] private MainMaskapaiViewModel _mainMaskapaiViewModel;

    public bool CanNavigateNext => true;
    public bool CanNavigatePrevious => false;

}