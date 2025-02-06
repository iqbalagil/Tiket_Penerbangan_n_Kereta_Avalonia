using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class CreateMaskapaiViewModel : ViewModelBase
{
    [ObservableProperty] private string _maskapaiName = string.Empty;
    [ObservableProperty] private string _descMaskapai = string.Empty;

    public ObservableCollection<TypeTransportasi> typeTransportasi;

    [RelayCommand]
    private void CreateMaskapai()
    {
        var newMaskapai = new TypeTransportasi
        {
            NamaType = _maskapaiName,
            Keterangan = _descMaskapai
        };
        
        typeTransportasi.Add(newMaskapai);
    }
}