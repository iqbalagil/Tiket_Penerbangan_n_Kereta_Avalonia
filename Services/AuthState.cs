using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Services;

public class AuthState
{
    public Penumpang? CurrentUser { get; private set; }
    public void SetCurrentUser(Penumpang user) => CurrentUser = user;
    public void Logout() => CurrentUser = null;
    public bool IsAuthenticated => CurrentUser != null;

    private ApplicationDbContext _context;
    public AuthState(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Penumpang> RegisterAsync(string username, string email, string password)
    {
        var userRole = await _context.Role.FirstOrDefaultAsync(r => r.RoleName == "User");
        if (userRole == null) throw new Exception("User role not found");

        if (await _context.Penumpang.AnyAsync(u => u.Email == email)) throw new Exception("Email already exists");
        else
        {
            var user = new Penumpang
            {
                Username = username,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Role = userRole
            };

            _context.Penumpang.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
    public async Task<Penumpang?> LoginAsync(string email, string password)
    {
        var user = await _context.Penumpang
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            SetCurrentUser(user);
            return user;
        }

        return null;
    }
}
