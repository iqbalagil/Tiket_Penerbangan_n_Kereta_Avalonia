using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

public class CreatePemesananViewModel : PageViewModelBase
{
    private ApplicationDbContext _context;

    private string _selectedTempatAwal;

    private string _selectedTempatTujuan;

    public CreatePemesananViewModel(ApplicationDbContext context)
    {
        _context = context;
    }


    public ObservableCollection<string> TempatAwalTujuanList { get; }
        = new() { "Jakarta", "Bandung", "Surabaya", "Tanggerang", "Yogyakarta" };

    public ObservableCollection<string> TempatAkhirTujuanList { get; }
        = new() { "Jakarta", "Bandung", "Surabaya", "Tanggerang", "Yogyakarta" };

    public string SelectedTempatAwal
    {
        get => _selectedTempatAwal;
        set => SetProperty(ref _selectedTempatAwal, value);
    }

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

    private static string GenerateCode(int length = 5)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var kode = new char[length];

        for (var i = 0; i < kode.Length; i++) kode[i] = chars[new Random().Next(chars.Length)];

        return new string(kode);
    }

    public async Task CreatePemesanan()
    {
        var pemesanan = new Data.Pemesanan();
    }
}