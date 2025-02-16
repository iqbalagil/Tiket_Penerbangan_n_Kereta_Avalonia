using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard.Pemesanan;

public partial class CreatePemesananViewModel : ViewModelBase
{
    private ApplicationDbContext _context;

    public CreatePemesananViewModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreatePemesanan()
    {
        
    }

}