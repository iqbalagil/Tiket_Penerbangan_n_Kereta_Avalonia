using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class CreateMaskapaiViewModel : PageViewModelBase
{
    private readonly ApplicationDbContext _context;
    [ObservableProperty] private string _descMaskapai;
    [ObservableProperty] private string _maskapaiName;

    public CreateMaskapaiViewModel(ApplicationDbContext context)
    {
        _context = context;
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
}