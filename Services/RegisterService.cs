using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Avalonia.Controls.Documents;
using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Services
{
    public interface IRegisterService
    {
        Task<bool> RegisterAsync(string username, string email, string password);
        Task<bool> UsernameExists(string username);
    }
    internal class RegisterService : IRegisterService
    {
        private readonly ApplicationDbContext _context;

        public RegisterService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> UsernameExists(string username)
        {
            return await _context.Penumpang.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            var userRole =  _context.Role.FirstOrDefault(r => r.RoleName == "User");
            if (userRole == null)
            {
                userRole = new Roles { RoleName = "User" };
                _context.Role.Add(userRole);
            } 
            
            var user = new Penumpang
            {
                Username = username,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Role = userRole
            };

            _context.Penumpang.Add(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


    }
}
