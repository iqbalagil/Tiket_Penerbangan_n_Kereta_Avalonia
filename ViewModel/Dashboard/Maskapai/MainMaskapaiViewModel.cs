using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public interface IPageViewModel
{
    bool CanNavigateNext { get; }
    bool CanNavigatePrevious { get; }
}

public partial class MainMaskapaiViewModel : ViewModelBase
{
    private readonly IServiceProvider _service;
    [ObservableProperty] private int _currentIndex = 1;

    public IEnumerable<string> Steps { get; } =
        ["First Step", "Second Step", "Third Step"];
    
    
    private ViewModelBase _currentPage;

    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => SetProperty(ref _currentPage, value);
    }

    public ObservableCollection<ListPageModel> Models { get; } = new()
    {
        new ListPageModel(typeof(MaskapaiViewModel), "Buat Maskapai"),
        new ListPageModel(typeof(CreatePemesananViewModel), "Buat Model Pemesanan")
    };

    public ICommand NavigateNextPage { get; }
    public ICommand NavigatePreviousPage { get; }

    public MainMaskapaiViewModel(IServiceProvider service)
    {
        _service = service;

        CurrentPage = GetPageViewModel(0);

        NavigateNextPage = new RelayCommand(NavigateNext, CanNavigateNext);
        NavigatePreviousPage = new RelayCommand(NavigatePrevious, CanNavigatePrevious);
    }

    private ViewModelBase GetPageViewModel(int index)
    {
        if (index < 0 || index >= Models.Count) return _currentPage;
       var viewModel = _service.GetRequiredService(Models[index].ModelType) as ViewModelBase;
       if (viewModel == null) return _currentPage;

       return viewModel;
    }

    private void NavigateNext()
    {
        if (CanNavigateNext())
        {
            _currentIndex++;
            CurrentPage = GetPageViewModel(_currentIndex);
            ((RelayCommand)NavigateNextPage).NotifyCanExecuteChanged();
            ((RelayCommand)NavigatePreviousPage).NotifyCanExecuteChanged();
        }
    }

    private void NavigatePrevious()
    {
        if (CanNavigatePrevious())
        {
            _currentIndex--;
            CurrentPage = GetPageViewModel(_currentIndex);
            ((RelayCommand)NavigateNextPage).NotifyCanExecuteChanged();
            ((RelayCommand)NavigatePreviousPage).NotifyCanExecuteChanged();
        }
    }

    private bool CanNavigateNext() => _currentIndex < Models.Count - 1 && NavigationState.IsSucces;

    private bool CanNavigatePrevious() => _currentIndex > 0;

}

public class ListPageModel
{
    public ListPageModel(Type type, string label)
    {
        ModelType = type;
        Label = type.Name.Replace(type.Name, label);
    }
    
    public Type ModelType { get; }
    public string Label { get; }
}