using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class MaskapaiViewModel : ViewModelBase
{
    [ObservableProperty] private string _kode;
    [ObservableProperty] private string _jumlahKursi;
    [ObservableProperty] private string desc;
    [ObservableProperty] private byte[] _imageData;
    [ObservableProperty] private TypeTransportasi _selectedTypeTransportasi;
    

    private Bitmap ImageBitmap { get; set; }
    
    [RelayCommand]
    private async void UploadImage(Window owner)
    {
        var dialog = new OpenFileDialog
        {
            Title = "Select Image",
            Filters = new List<FileDialogFilter>
            {
                new FileDialogFilter{ Name = "Image Files", Extensions = new List<string> { "jpg", "png", "jpeg", "bmp" } }
            }
        };

        var result = await dialog.ShowAsync(owner);
        if (result != null && result.Length > 0)
        {
            string _selectedFile = result[0];
            _imageData = await File.ReadAllBytesAsync(_selectedFile);

            using (var stream = File.OpenRead(_selectedFile))
            {
                ImageBitmap = new Bitmap(stream);
            }
        }
    }
    
    public void  SearchFileAndUpload(string directory, string extension = "png")
    {
        var files = Directory.GetFiles(directory, $".{extension}");
        if (files.Length > 0)
        {
            _imageData = File.ReadAllBytes(files.First());

            using (var stream = File.OpenRead(files.First()))
            {
                ImageBitmap = new Bitmap(stream);
            }
        }
    }

    [ObservableProperty] private ViewModelBase _currentPage;
    private IServiceProvider _service;
    private int _currentPageIndex;
    private readonly List<Type> _page;

    public MaskapaiViewModel(IServiceProvider service)
    {
        _service = service;
        _page = new List<Type>
        {
            typeof(MaskapaiViewModel),
            typeof(CreateMaskapaiViewModel)
        };
        _currentPageIndex = 0;
        CurrentPage = (ViewModelBase)_service.GetRequiredService(_page[_currentPageIndex]);
    }

    [RelayCommand]
    private void CreateMaskapaiPage()
    {
        if (_currentPageIndex < _page.Count - 1)
        {
            _currentPageIndex++;
            CurrentPage = (ViewModelBase)_service.GetRequiredService(_page[_currentPageIndex]);
        }
    }
}
