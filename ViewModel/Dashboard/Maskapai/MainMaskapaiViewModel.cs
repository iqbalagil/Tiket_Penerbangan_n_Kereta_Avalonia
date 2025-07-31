using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData;
using ReactiveUI;
using Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Maskapai;

public partial class MainMaskapaiViewModel : ViewModelBase
{
    private readonly PageViewModelBase[] Pages =
    {
        new MaskapaiViewModel(DashboardViewModel._context),
        new CreatePemesananViewModel(DashboardViewModel._context)
    };

    [ObservableProperty] private int _currentIndex = 1;


    private PageViewModelBase _currentPage;

    public MainMaskapaiViewModel()
    {
        CurrentPage = Pages[0];

        NavigateNextPage = ReactiveCommand.Create(NavigateNext, this.WhenAnyValue(
            x => x.CurrentPage.CanNavigateNext));
        NavigatePreviousPage = ReactiveCommand.Create(NavigatePrevious, this.WhenAnyValue(
            x => x.CurrentPage.CanNavigatePrevious));
        SubmitAndNavigateNextPage = ReactiveCommand.CreateFromTask(SubmitAndNavigateNext);
    }

    public IEnumerable<string> Steps { get; } =
        ["First Step", "Second Step", "Third Step"];

    public PageViewModelBase CurrentPage
    {
        get => _currentPage;
        set => SetProperty(ref _currentPage, value);
    }

    public ICommand NavigateNextPage { get; }
    public ICommand NavigatePreviousPage { get; }
    public ICommand SubmitAndNavigateNextPage { get; }

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