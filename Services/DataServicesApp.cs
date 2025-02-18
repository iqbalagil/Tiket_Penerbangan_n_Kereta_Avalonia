using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Services
{
    public class DataServicesApp
    {
        private readonly ApplicationDbContext _context;
    
        public DataServicesApp(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Penumpang?> LoginAsync(string email, string password)
        {
            var user = await _context.Penumpang.FirstOrDefaultAsync(u => u.Email ==
                email);
            if (user == null) return null;
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password)) return null;
            return user;
        }
    }
}
