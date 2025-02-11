using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class MaskapaiViewModel : PageViewModelBase
{
    private Transportasi _transportasi;
    private ApplicationDbContext _context;
    
    [ObservableProperty] private string _kode;
    [ObservableProperty] private int _jumlahKursi;
    [ObservableProperty] private string desc;
    [ObservableProperty] private byte[] _imageData;
    [ObservableProperty] private List<string> _selectedTypeTransportasi;
    [ObservableProperty] private string nameFile;

    public MaskapaiViewModel()
    {
        SelectedTypeTransportasi = _context.Set<TypeTransportasi>().Select(t => t.NamaType).ToList();
    }
    
    [RelayCommand]
    private void SubmitData()
    {
        _transportasi.Kode = Kode;
        _transportasi.JumlahKursi = JumlahKursi;
        _transportasi.Keterangan = Desc;
        _transportasi.Imagedata = _imageData;
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

    [ObservableProperty] private MainMaskapaiViewModel _mainMaskapaiViewModel;

    public override bool CanNavigateNext
    {
        get => true;
        set => throw new NotSupportedException();
    }

    public override bool CanNavigatePrevious
    {
        get => true;
        set => throw new NotSupportedException();
    }
}
