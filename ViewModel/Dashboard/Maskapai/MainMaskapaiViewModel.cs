using System;
using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public partial class MainMaskapaiViewModel : ViewModelBase
{

    public MainMaskapaiViewModel()
    {
        _pageCurrent = Pages[0];

        var canNext = this.WhenAnyValue(x => x.PageCurrent.CanNavigateNext);
        var canPrevious = this.WhenAnyValue(x => x.PageCurrent.CanNavigatePrevious);

        NavigationNextPage = ReactiveCommand.Create(NavigationNext, canNext);
    }
    
    private readonly PageViewModelBase[] Pages =
    {
        new MaskapaiViewModel(),
        new CreateMaskapaiViewModel()
    };

    private PageViewModelBase _pageCurrent;

    public PageViewModelBase PageCurrent
    {
        get => _pageCurrent;
        private set => SetProperty(ref _pageCurrent, value); 
    }
    private ICommand NavigationNextPage { get; }

    private void NavigationNext()
    {
        var index = Pages.IndexOf(PageCurrent) + 1;
        PageCurrent = Pages[index];
    }
    
    public ICommand NavigatePreviousPage { get; }

    private void NavigationPrevious()
    {
        var index = Pages.IndexOf(PageCurrent) - 1;
        PageCurrent = Pages[index];
    }
}