using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<UserData>> GetUsersAsync()
        {
            return await _context.UserData.ToListAsync();
        }

        public async Task AddUserAsync(UserData userData)
        {
            userData.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);
            _context.UserData.Add(userData);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(UserData userData)
        {
            userData.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);
            _context.Entry(userData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.UserData.FindAsync(id);
            if (user != null)
            {
                _context.UserData.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public async Task<UserData> LoginAsync(string username, string password)
        {
            var user = await _context.UserData.SingleOrDefaultAsync(u => u.Username == username);
            if (user != null && VerifyPassword(password, user.Password))
            {
                return user;
            }
            return null;
        }
    }
}
