using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class MaskapaiViewModel : ViewModelBase, IPageViewModel
{
    private ApplicationDbContext _context;
    
    [ObservableProperty] private string _kode;
    [ObservableProperty] private int _jumlahKursi;
    [ObservableProperty] private string desc;
    [ObservableProperty] private byte[] _imageData;
    [ObservableProperty] private string _selectedItem;

    [ObservableProperty] private ObservableCollection<string> _selectedTypeTransportasi;
    
    [ObservableProperty] private string nameFile;
    public ObservableCollection<int> AvailableNumbers { get; } = new(Enumerable.Range(1, 34));

    public MaskapaiViewModel(ApplicationDbContext context)
    {
        _context = context;
        LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var typeTransportasi = await _context.TypeTransportasi
            .Select(t => t.NamaType)
            .ToListAsync();
            SelectedTypeTransportasi = new ObservableCollection<string>(typeTransportasi);
    }
    
    [RelayCommand]
    private async Task<bool> SubmitData()
    {
        var transport = new Transportasi();

        transport.Kode = Kode;
        transport.Keterangan = Desc;
        transport.JumlahKursi = JumlahKursi;
        transport.Imagedata = ImageData;
        transport.NamaType = SelectedItem;

        try
        {
            _context.Transportasi.Add(transport);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    
    [RelayCommand]
    private async Task UploadImage()
    {
        var window = (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;

        if (window is null || window.StorageProvider is null) return;
        
        var files = await window.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select an image",
                AllowMultiple = false,
                FileTypeFilter = new[]
                {
                    new FilePickerFileType("Image Files")
                    {
                        Patterns = new[] {"*.png","*.jpg"}
                    }
                }
                
            });

        if (files.Count > 0)
        {
            var file = files[0];
            NameFile = file.Name;
            
            await using var stream = await file.OpenReadAsync();
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream); 
            ImageData = memoryStream.ToArray();
        }
    }



    public bool CanNavigateNext => true;

    public bool CanNavigatePrevious => false;
}
