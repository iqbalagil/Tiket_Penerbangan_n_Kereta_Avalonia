using System;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

public partial class CreatePemesananViewModel : PageViewModelBase
{
    private ApplicationDbContext _context;

    public CreatePemesananViewModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreatePemesanan()
    {
        
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