using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class MaskapaiViewModel : PageViewModelBase
{
    private readonly ApplicationDbContext _context;

    [ObservableProperty] private ViewModelBase _createMaskapaiPage;

    private byte[] _imageData;

    private int _jumlahKursi;

    private string _kode;

    private string _selectedItem;

    [ObservableProperty] private ObservableCollection<string> _selectedTypeTransportasi;

    private string desc;

    [ObservableProperty] private string nameFile;

    public MaskapaiViewModel(ApplicationDbContext context)
    {
        _context = context;
        LoadDataAsync();
    }

    [Required(ErrorMessage = "Kode is required")]
    public string Kode
    {
        get => _kode;
        set => SetProperty(ref _kode, value);
    }

    [Required(ErrorMessage = "Description is required")]
    public string Desc
    {
        get => desc;
        set => SetProperty(ref desc, value);
    }

    [Required(ErrorMessage = "Jumlah Kursi is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Jumlah kursi must be greater then 0")]
    public int JumlahKursi
    {
        get => _jumlahKursi;
        set => SetProperty(ref _jumlahKursi, value);
    }

    [Required(ErrorMessage = "Type Transportasi is required")]
    public string SelectedItem
    {
        get => _selectedItem;
        set => SetProperty(ref _selectedItem, value);
    }

    [Required(ErrorMessage = "Image is required")]
    public byte[] Image
    {
        get => _imageData;
        set => SetProperty<byte[]>(ref _imageData, value, true);
    }

    public ObservableCollection<int> AvailableNumbers { get; } = new(Enumerable.Range(1, 34));

    public ValidationUsingDataAnnotationsViewModel ValidationUsingDataAnnotationsViewModel { get; } = new();

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
        if (Image == null || Image.Length == 0)
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
            Keterangan = desc,
            JumlahKursi = JumlahKursi,
            Imagedata = Image,
            NamaType = SelectedItem,
            IdTypeTransportasi = typeTransportasi.IdTypeTransportasi
        };

        ValidateAllProperties();
        if (!HasErrors)
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
            Image = memoryStream.ToArray();
        }
        else
        {
            Console.WriteLine("No Image Selected");
            Image = null;
        }
    }
}