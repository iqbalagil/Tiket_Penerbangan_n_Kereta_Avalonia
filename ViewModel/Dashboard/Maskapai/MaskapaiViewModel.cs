using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Maskapai;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class MaskapaiViewModel : PageViewModelBase
{
    private ApplicationDbContext _context;

    [ObservableProperty] [Required(ErrorMessage = "Kode is reuqired")]
    private string _kode;

    [ObservableProperty] [Required(ErrorMessage = "Jumlah Kursi is required")]
    private int _jumlahKursi;

    [ObservableProperty] [Required(ErrorMessage = "Description is required")]
    private string desc;

    [ObservableProperty] [Required(ErrorMessage = "Image is required")]
    private byte[] _imageData;

    [ObservableProperty] [Required(ErrorMessage = "Type Transportasi is required")]
    private string _selectedItem;

    [ObservableProperty] private ViewModelBase _createMaskapaiPage;

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
    private void CreateMasakapaiShow()
    {
        CreateMaskapaiPage = new CreateMaskapaiViewModel(DashboardViewModel._context);
    }

    [RelayCommand]
    private async Task<bool> SubmitData()
    {

        if (ImageData == null || ImageData.Length == 0)
        {
            Console.WriteLine("Image data is required");
            return false;
        }

        var typeTransportasi = _context.TypeTransportasi
            .FirstOrDefault(t => t.NamaType == SelectedItem);

        if (typeTransportasi == null) return false;

        var transport = new Transportasi
        {
            Kode = Kode,
            Keterangan = Desc,
            JumlahKursi = JumlahKursi,
            Imagedata = ImageData,
            NamaType = SelectedItem,
            IdTypeTransportasi = typeTransportasi.IdTypeTransportasi
        };

        ValidateAllProperties();
        if (!HasErrors)
        {
            try
            {
                _context.Transportasi.Add(transport);
                await _context.SaveChangesAsync();
                NavigationState.IsSucces = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        return false;

    }

    [RelayCommand]
    private async Task UploadImage()
    {
        var window = (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;

        if (window is null || window.StorageProvider == null) return;

        var files = await window.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select an image",
                AllowMultiple = false,
                FileTypeFilter = new[]
                {
                    new FilePickerFileType("Image Files")
                    {
                        Patterns = new[] { "*.png", "*.jpg" }
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
        else
        {
            Console.WriteLine("No Image Selected");
            ImageData = null;
        }
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
