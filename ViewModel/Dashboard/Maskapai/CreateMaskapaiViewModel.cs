using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Maskapai;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class CreateMaskapaiViewModel : PageViewModelBase
{
    [ObservableProperty] private string _maskapaiName;
    [ObservableProperty] private string _descMaskapai;

    private ApplicationDbContext _context;

    public CreateMaskapaiViewModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [RelayCommand]
    private async Task<bool> CreateMaskapai()
    {
        var newMaskapai = new TypeTransportasi
        {
            NamaType = MaskapaiName,
            Keterangan = DescMaskapai
        };

        _context.TypeTransportasi.Add(newMaskapai);

        await _context.SaveChangesAsync();
        return true;
    }

    public override bool CanNavigateNext
    {
        get => true;
        set => throw new NotSupportedException();
    }

    public override bool CanNavigatePrevious
    {
        get => false;
        set => throw new NotSupportedException();
    }

}