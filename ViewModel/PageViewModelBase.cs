namespace Tiket_Penerbangan_n_Kereta.ViewModel;

public abstract class PageViewModelBase : ViewModelBase
{
    public abstract bool CanNavigateNext { get; set; }
    public abstract bool CanNavigatePrevious { get; set; }
}