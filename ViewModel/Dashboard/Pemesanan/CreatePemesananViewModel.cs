using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

public partial class CreatePemesananViewModel : PageViewModelBase
{
    private ApplicationDbContext _context;

    public CreatePemesananViewModel(ApplicationDbContext context)
    {
        _context = context;
    }

    private static string GenerateCode(int length = 5)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] kode = new char[length];

        for (int i = 0; i < kode.Length; i++)
        {
            kode[i] = chars[new Random().Next(chars.Length)];
        }

        return new string(kode);
    }

    public async Task CreatePemesanan()
    {
        var pemesanan = new Data.Pemesanan
        {
            
        };
    }

    
    public ObservableCollection<string> TempatAwalTujuanList { get; }
        = new() { "Jakarta", "Bandung", "Surabaya", "Tanggerang", "Yogyakarta" };
    public ObservableCollection<string> TempatAkhirTujuanList { get; }
    = new() { "Jakarta", "Bandung", "Surabaya", "Tanggerang", "Yogyakarta" };

    private string _selectedTempatAwal;

    public string SelectedTempatAwal
    {
        get => _selectedTempatAwal;
        set => SetProperty(ref _selectedTempatAwal, value);
    }

    private string _selectedTempatTujuan;

    public string SelectedTempatTujuan
    {
        get => _selectedTempatTujuan;
        set => SetProperty(ref _selectedTempatTujuan, value);
    }

    public DateTime TanggalBerangkat { get; set; } = DateTime.Today;
    public TimeSpan JamBerangkat { get; set; }
    public TimeSpan JamTiba { get; set; }
    
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