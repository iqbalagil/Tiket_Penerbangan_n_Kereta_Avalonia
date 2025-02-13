using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Tiket_Penerbangan_n_Kereta.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.ViewModel;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

public partial class PemesananPesawatViewModel : ViewModelBase
{
    private readonly ApplicationDbContext _context;
    [ObservableProperty] private ObservableCollection<PemesananViewModel> _pemesananList;
    public PemesananPesawatViewModel(ApplicationDbContext context)
    {
        _context = context;
        LoadDummyDataAsync();
    }

    public async Task LoadDummyDataAsync()
    {
        await Task.Delay(500);

        PemesananList = new ObservableCollection<PemesananViewModel>
        {
            new PemesananViewModel
            {
                _namaPesawat = "Garuda Indonesia",
                _imagePesawat = new byte[] { }, // Dummy empty image data
                _hargaPesawat = 500000,
                _jamBerangkat = "08:00",
                _jamTiba = "10:00",
                _tempatSekarang = "Jakarta (CGK)",
                _tempatTiba = "Surabaya (SUB)",
                _tempatTujuan = "Surabaya"
            },
            new PemesananViewModel
            {
                _namaPesawat = "Batik Air",
                _imagePesawat = new byte[] { },
                _hargaPesawat = 750000,
                _jamBerangkat = "12:30",
                _jamTiba = "14:45",
                _tempatSekarang = "Jakarta (CGK)",
                _tempatTiba = "Denpasar (DPS)",
                _tempatTujuan = "Bali"
            },
            new PemesananViewModel
            {
                _namaPesawat = "Lion Air",
                _imagePesawat = new byte[] { },
                _hargaPesawat = 300000,
                _jamBerangkat = "15:00",
                _jamTiba = "17:30",
                _tempatSekarang = "Jakarta (CGK)",
                _tempatTiba = "Yogyakarta (YIA)",
                _tempatTujuan = "Yogyakarta"
            }
        };
    }

    public async Task LoadDataAsync()
    {
        var pesawat = await _context.Pemesanan
            .Include(p => p.Tujuan)
            .ThenInclude(p => p.Transportasi)
            .ToListAsync();

        PemesananList = new ObservableCollection<PemesananViewModel>(
            pesawat.Select(p => new PemesananViewModel
            {
                _namaPesawat = p.Tujuan.Transportasi.NamaType,
                _imagePesawat = p.Tujuan.Transportasi.Imagedata,
                _hargaPesawat = p.TotalBayar,
                _jamBerangkat = p.JamBerangkat.ToString("HH:mm"),
                _jamTiba = p.JamTiba.ToString("HH:mm"),
                _tempatSekarang = p.Tujuan.RuteAwal,
                _tempatTiba = p.Tujuan.RuteAkhri,
                _tempatTujuan = p.Tujuan.Tujuan
            }));

    }
    

}

public class PemesananViewModel
{
    public string _namaPesawat { get; set; }
    public byte[] _imagePesawat { get; set; }
    public decimal _hargaPesawat { get; set; }
    public string _jamBerangkat { get; set; }
    public string _jamTiba { get; set; }
    public string _tempatSekarang { get; set; }
    public string _tempatTiba { get; set; }
    public string _tempatTujuan { get; set; }
}