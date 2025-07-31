using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Reactive;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta.Services;

public interface INavigationService
{
    IObservable<Unit> NavigateTo(IRoutableViewModel viewModel);
}