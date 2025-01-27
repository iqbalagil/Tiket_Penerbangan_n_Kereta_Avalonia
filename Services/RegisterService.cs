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
    public interface IRegisterService
    {
        Task<bool> RegisterAsync(string username, string email, string password);
    }
    internal class RegisterService : IRegisterService
    {
        private readonly ApplicationDbContext _data;

        public RegisterService(ApplicationDbContext data)
        {
            _data = data;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            if (await _data.UserData.AnyAsync(x => x.Username == username || x.Email == email))
            {
                return false;
            }
            var user = new UserData
            {
                Username = username,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Role = "User"
            };

            _data.UserData.Add(user);
            await _data.SaveChangesAsync();
            return true;
        }
    }
}
