using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Maskapai;


public partial class MainMaskapaiViewModel : ViewModelBase
{
    [ObservableProperty] private int _currentIndex = 1;

    public IEnumerable<string> Steps { get; } =
        ["First Step", "Second Step", "Third Step"];
    
    
    private PageViewModelBase _currentPage;

    public PageViewModelBase CurrentPage
    {
        get => _currentPage;
        set => SetProperty(ref _currentPage, value);
    }


    private readonly PageViewModelBase[] Pages =
    {
        new MaskapaiViewModel(DashboardViewModel._context),
        new CreatePemesananViewModel(DashboardViewModel._context)
    };

    public ICommand NavigateNextPage { get; }
    public ICommand NavigatePreviousPage { get; }
    public ICommand SubmitAndNavigateNextPage { get; }

    public MainMaskapaiViewModel()
    {
        CurrentPage = Pages[0];

        NavigateNextPage = ReactiveCommand.Create(NavigateNext, this.WhenAnyValue(
            x => x.CurrentPage.CanNavigateNext));
        NavigatePreviousPage = ReactiveCommand.Create(NavigatePrevious, this.WhenAnyValue(
            x => x.CurrentPage.CanNavigatePrevious));
        SubmitAndNavigateNextPage = ReactiveCommand.CreateFromTask(SubmitAndNavigateNext);
    }

    private async Task SubmitAndNavigateNext()
    {
        if (CurrentPage is MaskapaiViewModel maskapaiViewModel)
        { 
            await maskapaiViewModel.SubmitDataCommand.ExecuteAsync(true);
            NavigateNext();
        }
    }
    
    private void NavigateNext()
    {

        var index = Pages.IndexOf(CurrentPage) + 1;
        CurrentPage = Pages[index];
    }

    private void NavigatePrevious()
    {
        var index = Pages.IndexOf(CurrentPage) - 1;
        CurrentPage = Pages[index];
    }

}
